using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace AnyControl
{
    /// <summary>
    ///  单按钮下拉框
    /// </summary>
    public partial class SingleCombox : AnyControl
    {
        private int _spaceHeight = 5;
        private PanelForm dataForm = new PanelForm();

        public SingleCombox()
        {
            InitializeComponent();
            
            InitControl();
            InitData();
        }

        #region 方法

        private void InitControl()
        {
            this.Size = sgcbButton.Size;

            dataForm.Hide();
            dataForm.StartPosition = FormStartPosition.Manual;
            dataForm.ShowInTaskbar = false;

            dataForm.Controls.Add(sgcbData);
            sgcbData.Dock = DockStyle.Fill;
        }

        private void InitData()
        {

        }

        #endregion

        #region 事件

        private void sgcbButton_Click(object sender, EventArgs e)
        {
            bool isDataShow = !dataForm.Visible;
            
            // 设置下拉框
            if (isDataShow)
            {
                Rectangle rec = RectangleToScreen(this.ClientRectangle);
                dataForm.Location = new Point(rec.X + this.Size.Width - DataPanelSize.Width, rec.Y + this.Size.Height + _spaceHeight);
                dataForm.BringToFront();
            }
            dataForm.Visible = !dataForm.Visible;
        }

        #endregion

        #region 对外属性

        #region DataPanelSize

        /// <summary>
        /// 获取或设置下拉框的大小
        /// </summary>
        [Browsable(true), Category("布局"), Description("下拉框的大小")]
        public Size DataPanelSize
        {
            get { return dataForm.Size; }
            set { dataForm.Size = value; }
        }

        public bool ShouldSerializeDataPanelSize()
        {
            return DataPanelSize != new Size(330, 165);
        }

        public void ResetDataPanelSize()
        {
            DataPanelSize = new Size(330, 165);
        }

        #endregion

        #region DataSource

        /// <summary>
        /// 获取或设置下拉框绑定的数据源
        /// </summary>
        [Browsable(true), Category("数据"), Description("下拉框的数据源")]
        public object DataSource
        {
            get { return sgcbData.DataSource; }
            set { sgcbData.DataSource = value; }
        }
      
        #endregion

        #endregion

        #region 对外事件

        #endregion
    }
}
