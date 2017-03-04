using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using AnyExtend;
using System.Xml.Serialization;

namespace AnyControl
{
    /// <summary>
    /// 数据库连接控件
    /// </summary>
    public partial class DBConnect : AnyControl
    {
        private bool _isRefreshDB;
        private Dictionary<string, DataBase> _dicHistory;

        public DBConnect()
        {
            InitializeComponent();

            InitData();
        }

        #region 对外属性

        #region Server

        /// <summary>
        /// 服务器
        /// </summary>
        [Browsable(true), Category("外观"), Description("服务器")]
        public string Server
        {
            get { return txtServer.Text; }
            set { txtServer.Text = value; }
        }

        #endregion

        #region UserName

        /// <summary>
        /// 用户名
        /// </summary>
        [Browsable(true), Category("外观"), Description("用户名")]
        public string UserName
        {
            get { return txtUserName.Text; }
            set { txtUserName.Text = value; }
        }

        #endregion

        #region Password

        /// <summary>
        /// 密码
        /// </summary>
        [Browsable(true), Category("外观"), Description("密码")]
        public string Password
        {
            get { return txtPassword.Text; }
            set { txtPassword.Text = value; }
        }

        #endregion

        #region Database

        /// <summary>
        /// 数据库
        /// </summary>
        [Browsable(false)]
        public string Database
        {
            get { return Util.ConvertType<string>(cmbDatabase.SelectedValue); }
            set { cmbDatabase.SelectedValue = value; }
        }

        #endregion

        #region DB

        /// <summary>
        /// 数据库配置信息
        /// </summary>
        [Browsable(false)]
        public DBInfo DB
        {
            get
            {
                return new DBInfo
                (
                    Server,
                    Database,
                    UserName,
                    Password
                );
            }
            set
            {
                Server = value.Server;
                UserName = value.UserName;
                Password = value.Password;

                RefreshDB(value.Database);
            }
        }

        #endregion

        #region ConfigFolder

        /// <summary>
        /// 配置文件夹
        /// </summary>
        [Browsable(true), Category("数据"), Description("保存历史配置信息的文件夹名称")]
        private string _configFolder;
        public string ConfigFolder
        {
            get { return _configFolder; }
            set
            {
                // 确保ConfigFolder以“\”开头和结尾
                if (value[0] != '\\')
                {
                    value = @"\" + value;
                }
                if (value[value.Length - 1] != '\\')
                {
                    value += @"\";
                }

                _configFolder = IOExt.CheckFolderName(value) ? value : "";
            }
        }

        #endregion

        #region ConfigFilePath

        /// <summary>
        /// 配置文件路径
        /// </summary>
        [Browsable(false)]
        public string ConfigFilePath
        {
            get
            {
                string folder = ConfigFolder.IsEmpty() ? @"\" : ConfigFolder;
                return IOExt.ApplicationPath + $@"\DBConnect{folder}config.xml";
            }
        }

        #endregion

        #endregion

        #region 事件
        
        private void txtInfo_TextChanged(object sender, EventArgs e) => _isRefreshDB = true;

        private void cmbDatabase_DropDown(object sender, EventArgs e)
        {
            if (_isRefreshDB)
            {
                RefreshDB();
                _isRefreshDB = false;
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            if (TestDB(true))
            {
                SaveConfig();
                MsgBox.OK("测试连接成功！");
            }
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            LoadConfig();
            menuHistory.Show(this, PointToClient(MousePosition));
        }

        private void menuHistory_ItemClicked(object sender, EventArgs e)
        {
            var item = sender as ToolStripMenuItem;
            if (item != null)
            {
                DB = (DBInfo) _dicHistory[item.Text];
            }
        }

        private void btnClearHistory_Click(object sender, EventArgs e) => ClearHistory();

        #endregion

        #region 公共方法

        /// <summary>
        /// 校验填写的数据
        /// </summary>
        /// <param name="isShowTip">是否弹出提示</param>
        /// <returns></returns>
        public bool CheckData(bool isShowTip)
        {
            if (Server.IsEmpty())
            {
                if (isShowTip)
                {
                    MsgBox.OK("服务器不允许为空！");
                }
                return false;
            }

            if (UserName.IsEmpty())
            {
                if (isShowTip)
                {
                    MsgBox.OK("用户名不允许为空！");
                }
                return false;
            }

            if (Password.IsEmpty())
            {
                if (isShowTip)
                {
                    MsgBox.OK("密码不允许为空！");
                }
                return false;
            }

            if (Database.IsEmpty())
            {
                if (isShowTip)
                {
                    MsgBox.OK("数据库不允许为空！");
                }
                return false;
            }

            return true;
        }

        /// <summary>
        /// 测试数据库连接
        /// </summary>
        /// <param name="isShowTip">是否弹出提示</param>
        /// <returns></returns>
        public bool TestDB(bool isShowTip)
        {
            if (!CheckData(isShowTip))
            {
                return false;
            }

            Func<bool> error = () =>
            {
                if (isShowTip)
                {
                    MsgBox.Error("测试连接失败，请检查后重试！");
                }
                return false;
            };

            return LogExt.Exec(() =>
            {
                if (!DBExt.TestSqlServerDB(DB))
                {
                    return error();
                }
                return true;
            }, error);
        }

        /// <summary>
        /// 刷新数据库列表
        /// </summary>
        public async void RefreshDB(string defaultDB = null)
        {
            if (!CheckData())
            {
                cmbDatabase.DataSource = null;
                return;
            }

            // 记录默认值
            string defaultValue = defaultDB ?? Database;

            DataTable dtDBName = new DataTable();

            // 查询所有数据库
            await Task.Run(() =>
            {
                LogExt.Exec(() =>
                {
                    DBInfo dbMaster = new DBInfo(Server, "master", UserName, Password);

                    var adapter = new SqlDataAdapter(@"
                        SELECT '' AS name, 0 AS OrderID 
                        UNION 
                        SELECT name, 1
                        FROM master..sysdatabases 
				        WHERE dbid <= 4
				        UNION
				        SELECT name, 2
                        FROM master..sysdatabases 
				        WHERE dbid > 4
                        ORDER BY OrderID, name", dbMaster.Conn);

                    lock (adapter)
                    {
                        adapter.Fill(dtDBName);
                    }
                });
            });

            // 绑定数据源
            if (dtDBName.Rows.Count > 1)
            {
                cmbDatabase.DisplayMember = "name";
                cmbDatabase.ValueMember = "name";
                cmbDatabase.DataSource = dtDBName;

                cmbDatabase.SelectedValue = defaultValue;
            }
            else
            {
                cmbDatabase.DataSource = null;
            }
        }

        /// <summary>
        /// 设置默认数据库，默认取第一条历史记录
        /// </summary>
        public void SetDefaultDB()
        {
            RefreshHistoryDic();

            if (_dicHistory.Count > 0)
            {
                DB = (DBInfo)_dicHistory.First().Value;
            }
        }

        /// <summary>
        /// 获取历史数据库信息
        /// </summary>
        public void LoadConfig()
        {
            RefreshHistoryDic();

            // 绑定
            menuHistory.Items.Clear();
            _dicHistory.ForEach(db => menuHistory.Items.Add(db.Key, null, menuHistory_ItemClicked));

            // 清空按钮
            menuHistory.Items.Add(new ToolStripSeparator());
            menuHistory.Items.Add(new ToolStripMenuItem("清空历史记录", null, btnClearHistory_Click));
        }

        /// <summary>
        /// 保存填写的数据库信息
        /// </summary>
        public void SaveConfig()
        {
            RefreshHistoryDic();

            // 新增当前信息
            _dicHistory.SafeAdd($"{DB.Server}@{DB.Database}", (DataBase)DB);

            // 序列化保存
            List<DataBase> dbList = _dicHistory.Select(e => e.Value).ToList();
            LogExt.Exec(() =>
            {
                SerializeExt.ToXml(dbList, ConfigFilePath);
            });
        }

        public void ClearHistory()
        {
            IOExt.DeleteFile(ConfigFilePath);
            LoadConfig();
        }

        #endregion

        #region 私有方法

        private void InitData()
        {
            _dicHistory = new Dictionary<string, DataBase>();
        }

        private XmlDocument GetConfigXml()
        {
            IOExt.CreateXml(ConfigFilePath, "ArrayOfDataBase");
            return IOExt.ReadXml(ConfigFilePath);
        }

        private void RefreshHistoryDic()
        {
            // 反序列化
            var dbList = LogExt.Exec
            (
                () => SerializeExt.XmlTo<List<DataBase>>(GetConfigXml().InnerXml),
                () => new List<DataBase>()
            );

            // 绑定
            _dicHistory.Clear();
            if (dbList.Count > 0)
            {
                dbList.OrderByDescending(db => db.UpdateTime)
                    .Take(10)
                    .ForEach(db =>_dicHistory.Add($"{db.Server}@{db.Database}", db));
            }
        }

        /// <summary>
        /// 校验数据，供RefreshDB()使用
        /// </summary>
        private bool CheckData()
        {
            return !(Server.IsEmpty() || UserName.IsEmpty() || Password.IsEmpty());
        }

        #endregion
    }

    #region 序列化对象

    [Serializable]
    public class DataBase
    {
        [XmlAttribute]
        public string Server { get; set; }

        [XmlAttribute]
        public string UserName { get; set; }

        [XmlAttribute]
        public string Password { get; set; }

        [XmlAttribute]
        public string Database { get; set; }

        [XmlAttribute]
        public string UpdateTime { get; set; }
        
        public static explicit operator DBInfo(DataBase db)
        {
            return new DBInfo(db.Server,db.Database,db.UserName,db.Password);
        }

        public static explicit operator DataBase(DBInfo db)
        {
            return new DataBase
            {
                Server = db.Server,
                UserName = db.UserName,
                Password = db.Password,
                Database = db.Database,
                UpdateTime = DateTime.Now.ToString("yy-MM-dd hh:mm:ss")
            };
        }
    }

    #endregion
}
