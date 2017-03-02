using System.Windows.Forms;

namespace AnyControl
{
    partial class DBConnect
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnHistory = new System.Windows.Forms.Button();
            this.menuHistory = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClearHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.cmbDatabase = new System.Windows.Forms.ComboBox();
            this.tipInfo = new System.Windows.Forms.ToolTip(this.components);
            this.btnTest = new System.Windows.Forms.Button();
            this.lblDatabase = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblServer = new System.Windows.Forms.Label();
            this.menuHistory.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtServer
            // 
            this.txtServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtServer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtServer.Location = new System.Drawing.Point(47, 6);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(250, 29);
            this.txtServer.TabIndex = 4;
            this.txtServer.TextChanged += new System.EventHandler(this.txtInfo_TextChanged);
            // 
            // txtUserName
            // 
            this.txtUserName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserName.Location = new System.Drawing.Point(47, 48);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(250, 29);
            this.txtUserName.TabIndex = 5;
            this.txtUserName.TextChanged += new System.EventHandler(this.txtInfo_TextChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Location = new System.Drawing.Point(47, 90);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(250, 29);
            this.txtPassword.TabIndex = 6;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtInfo_TextChanged);
            // 
            // btnHistory
            // 
            this.btnHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHistory.Location = new System.Drawing.Point(302, 5);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(30, 30);
            this.btnHistory.TabIndex = 8;
            this.btnHistory.Text = "...";
            this.tipInfo.SetToolTip(this.btnHistory, "历史记录");
            this.btnHistory.UseVisualStyleBackColor = true;
            this.btnHistory.Click += new System.EventHandler(this.btnHistory_Click);
            // 
            // menuHistory
            // 
            this.menuHistory.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.btnClearHistory});
            this.menuHistory.Name = "menuHistory";
            this.menuHistory.Size = new System.Drawing.Size(153, 54);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // btnClearHistory
            // 
            this.btnClearHistory.Name = "btnClearHistory";
            this.btnClearHistory.ShowShortcutKeys = false;
            this.btnClearHistory.Size = new System.Drawing.Size(152, 22);
            this.btnClearHistory.Text = "清空历史记录";
            this.btnClearHistory.Click += new System.EventHandler(this.btnClearHistory_Click);
            // 
            // cmbDatabase
            // 
            this.cmbDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbDatabase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDatabase.FormattingEnabled = true;
            this.cmbDatabase.Location = new System.Drawing.Point(47, 131);
            this.cmbDatabase.Name = "cmbDatabase";
            this.cmbDatabase.Size = new System.Drawing.Size(250, 29);
            this.cmbDatabase.TabIndex = 10;
            this.cmbDatabase.DropDown += new System.EventHandler(this.cmbDatabase_DropDown);
            // 
            // btnTest
            // 
            this.btnTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTest.Image = global::AnyControl.Properties.Resources.Wifi_Black;
            this.btnTest.Location = new System.Drawing.Point(302, 131);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(30, 30);
            this.btnTest.TabIndex = 9;
            this.tipInfo.SetToolTip(this.btnTest, "测试连接");
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // lblDatabase
            // 
            this.lblDatabase.Image = global::AnyControl.Properties.Resources.List_Black;
            this.lblDatabase.Location = new System.Drawing.Point(6, 132);
            this.lblDatabase.Name = "lblDatabase";
            this.lblDatabase.Size = new System.Drawing.Size(35, 25);
            this.lblDatabase.TabIndex = 3;
            this.lblDatabase.Tag = "";
            this.lblDatabase.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tipInfo.SetToolTip(this.lblDatabase, "数据库");
            // 
            // lblPassword
            // 
            this.lblPassword.Image = global::AnyControl.Properties.Resources.Lock_Black;
            this.lblPassword.Location = new System.Drawing.Point(6, 89);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(35, 30);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Tag = "";
            this.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tipInfo.SetToolTip(this.lblPassword, "密码");
            // 
            // lblUserName
            // 
            this.lblUserName.Image = global::AnyControl.Properties.Resources.User_Black;
            this.lblUserName.Location = new System.Drawing.Point(6, 49);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(35, 25);
            this.lblUserName.TabIndex = 1;
            this.lblUserName.Tag = "";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tipInfo.SetToolTip(this.lblUserName, "用户名");
            // 
            // lblServer
            // 
            this.lblServer.Image = global::AnyControl.Properties.Resources.Cloud_Black;
            this.lblServer.Location = new System.Drawing.Point(6, 8);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(35, 25);
            this.lblServer.TabIndex = 0;
            this.lblServer.Tag = "";
            this.lblServer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tipInfo.SetToolTip(this.lblServer, "服务器");
            // 
            // DBConnect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.Controls.Add(this.cmbDatabase);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.btnHistory);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.txtServer);
            this.Controls.Add(this.lblDatabase);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.lblServer);
            this.MaximumSize = new System.Drawing.Size(400, 167);
            this.MinimumSize = new System.Drawing.Size(240, 167);
            this.Name = "DBConnect";
            this.Size = new System.Drawing.Size(343, 167);
            this.menuHistory.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblUserName;
        private Label lblPassword;
        private Label lblDatabase;
        private Label lblServer;
        private TextBox txtServer;
        private TextBox txtUserName;
        private TextBox txtPassword;
        private Button btnHistory;
        private Button btnTest;
        private ComboBox cmbDatabase;
        private ToolTip tipInfo;
        private ContextMenuStrip menuHistory;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem btnClearHistory;
    }
}
