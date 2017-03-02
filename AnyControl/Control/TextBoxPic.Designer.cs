namespace AnyControl
{
    partial class TextBoxPic
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
            this.txtpPic = new System.Windows.Forms.PictureBox();
            this.txtpText = new System.Windows.Forms.TextBox();
            this.txtpPanel = new System.Windows.Forms.Panel();
            this.txtpTipText = new System.Windows.Forms.Label();
            this.txtpUnderLine = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtpPic)).BeginInit();
            this.txtpPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtpPic
            // 
            this.txtpPic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtpPic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtpPic.Location = new System.Drawing.Point(2, 2);
            this.txtpPic.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtpPic.Name = "txtpPic";
            this.txtpPic.Size = new System.Drawing.Size(24, 24);
            this.txtpPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.txtpPic.TabIndex = 5;
            this.txtpPic.TabStop = false;
            this.txtpPic.Resize += new System.EventHandler(this.txtpPic_Resize);
            // 
            // txtpText
            // 
            this.txtpText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtpText.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtpText.Location = new System.Drawing.Point(0, 6);
            this.txtpText.Name = "txtpText";
            this.txtpText.Size = new System.Drawing.Size(267, 22);
            this.txtpText.TabIndex = 0;
            this.txtpText.TextChanged += new System.EventHandler(this.txtpText_TextChanged);
            this.txtpText.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtpText_KeyUp);
            this.txtpText.Resize += new System.EventHandler(this.txtpText_Resize);
            // 
            // txtpPanel
            // 
            this.txtpPanel.Controls.Add(this.txtpPic);
            this.txtpPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.txtpPanel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtpPanel.Location = new System.Drawing.Point(272, 0);
            this.txtpPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtpPanel.Name = "txtpPanel";
            this.txtpPanel.Padding = new System.Windows.Forms.Padding(2);
            this.txtpPanel.Size = new System.Drawing.Size(28, 28);
            this.txtpPanel.TabIndex = 1;
            // 
            // txtpTipText
            // 
            this.txtpTipText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtpTipText.AutoSize = true;
            this.txtpTipText.BackColor = System.Drawing.Color.Transparent;
            this.txtpTipText.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtpTipText.ForeColor = System.Drawing.Color.Gray;
            this.txtpTipText.Location = new System.Drawing.Point(7, 7);
            this.txtpTipText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtpTipText.Name = "txtpTipText";
            this.txtpTipText.Size = new System.Drawing.Size(58, 21);
            this.txtpTipText.TabIndex = 2;
            this.txtpTipText.Text = "请输入";
            this.txtpTipText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtpUnderLine
            // 
            this.txtpUnderLine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtpUnderLine.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtpUnderLine.Location = new System.Drawing.Point(0, 28);
            this.txtpUnderLine.Name = "txtpUnderLine";
            this.txtpUnderLine.Size = new System.Drawing.Size(300, 2);
            this.txtpUnderLine.TabIndex = 3;
            // 
            // TextBoxPic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.txtpTipText);
            this.Controls.Add(this.txtpText);
            this.Controls.Add(this.txtpPanel);
            this.Controls.Add(this.txtpUnderLine);
            this.Name = "TextBoxPic";
            this.Size = new System.Drawing.Size(300, 30);
            ((System.ComponentModel.ISupportInitialize)(this.txtpPic)).EndInit();
            this.txtpPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox txtpPic;
        private System.Windows.Forms.TextBox txtpText;
        private System.Windows.Forms.Panel txtpPanel;
        private System.Windows.Forms.Label txtpTipText;
        private System.Windows.Forms.Label txtpUnderLine;
    }
}
