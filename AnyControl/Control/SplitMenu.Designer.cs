namespace AnyControl
{
    partial class SplitMenu
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlMenu = new System.Windows.Forms.TableLayoutPanel();
            this.lblSplitLine = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(100, 28);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "标题";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlMenu
            // 
            this.pnlMenu.ColumnCount = 1;
            this.pnlMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pnlMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pnlMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMenu.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.AddColumns;
            this.pnlMenu.Location = new System.Drawing.Point(100, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.RowCount = 1;
            this.pnlMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlMenu.Size = new System.Drawing.Size(200, 28);
            this.pnlMenu.TabIndex = 1;
            // 
            // lblSplitLine
            // 
            this.lblSplitLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.lblSplitLine.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblSplitLine.Location = new System.Drawing.Point(0, 28);
            this.lblSplitLine.Name = "lblSplitLine";
            this.lblSplitLine.Size = new System.Drawing.Size(300, 2);
            this.lblSplitLine.TabIndex = 2;
            this.lblSplitLine.Text = "label1";
            // 
            // SplitMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblSplitLine);
            this.Name = "SplitMenu";
            this.Size = new System.Drawing.Size(300, 30);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TableLayoutPanel pnlMenu;
        private System.Windows.Forms.Label lblSplitLine;
    }
}
