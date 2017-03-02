using System.Drawing;

namespace AnyControl
{
    partial class AnyForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.pnlTitleMenu = new System.Windows.Forms.Panel();
            this.lblMin = new System.Windows.Forms.Label();
            this.lblMax = new System.Windows.Forms.Label();
            this.lblClose = new System.Windows.Forms.Label();
            this.lblTitleText = new System.Windows.Forms.Label();
            this.tip = new System.Windows.Forms.ToolTip(this.components);
            this.pnlTitle.SuspendLayout();
            this.pnlTitleMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTitle
            // 
            this.pnlTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.pnlTitle.Controls.Add(this.pnlTitleMenu);
            this.pnlTitle.Controls.Add(this.lblTitleText);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitle.ForeColor = System.Drawing.Color.White;
            this.pnlTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(300, 30);
            this.pnlTitle.TabIndex = 0;
            // 
            // pnlTitleMenu
            // 
            this.pnlTitleMenu.Controls.Add(this.lblMin);
            this.pnlTitleMenu.Controls.Add(this.lblMax);
            this.pnlTitleMenu.Controls.Add(this.lblClose);
            this.pnlTitleMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTitleMenu.Location = new System.Drawing.Point(55, 0);
            this.pnlTitleMenu.Name = "pnlTitleMenu";
            this.pnlTitleMenu.Size = new System.Drawing.Size(245, 30);
            this.pnlTitleMenu.TabIndex = 1;
            this.pnlTitleMenu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTitle_MouseDown);
            this.pnlTitleMenu.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlTitle_MouseMove);
            // 
            // lblMin
            // 
            this.lblMin.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblMin.Location = new System.Drawing.Point(125, 0);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(40, 30);
            this.lblMin.TabIndex = 3;
            this.lblMin.Text = "—";
            this.lblMin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tip.SetToolTip(this.lblMin, "最小化");
            this.lblMin.Click += new System.EventHandler(this.lblMin_Click);
            this.lblMin.MouseEnter += new System.EventHandler(this.titleBtn_MouseEnter);
            this.lblMin.MouseLeave += new System.EventHandler(this.titleBtn_MouseLeave);
            // 
            // lblMax
            // 
            this.lblMax.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblMax.Location = new System.Drawing.Point(165, 0);
            this.lblMax.Name = "lblMax";
            this.lblMax.Size = new System.Drawing.Size(40, 30);
            this.lblMax.TabIndex = 2;
            this.lblMax.Text = "口";
            this.lblMax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tip.SetToolTip(this.lblMax, "最大化");
            this.lblMax.Click += new System.EventHandler(this.lblMax_Click);
            this.lblMax.MouseEnter += new System.EventHandler(this.titleBtn_MouseEnter);
            this.lblMax.MouseLeave += new System.EventHandler(this.titleBtn_MouseLeave);
            // 
            // lblClose
            // 
            this.lblClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblClose.Location = new System.Drawing.Point(205, 0);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(40, 30);
            this.lblClose.TabIndex = 1;
            this.lblClose.Text = "X";
            this.lblClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tip.SetToolTip(this.lblClose, "关闭");
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
            this.lblClose.MouseEnter += new System.EventHandler(this.titleBtn_MouseEnter);
            this.lblClose.MouseLeave += new System.EventHandler(this.titleBtn_MouseLeave);
            // 
            // lblTitleText
            // 
            this.lblTitleText.AutoSize = true;
            this.lblTitleText.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTitleText.Location = new System.Drawing.Point(0, 0);
            this.lblTitleText.Name = "lblTitleText";
            this.lblTitleText.Padding = new System.Windows.Forms.Padding(3, 3, 10, 0);
            this.lblTitleText.Size = new System.Drawing.Size(55, 24);
            this.lblTitleText.TabIndex = 0;
            this.lblTitleText.Text = "标题";
            this.lblTitleText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitleText.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTitle_MouseDown);
            this.lblTitleText.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlTitle_MouseMove);
            // 
            // AnyForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Controls.Add(this.pnlTitle);
            this.Name = "AnyForm";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.LysForm_Paint);
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            this.pnlTitleMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.Panel pnlTitleMenu;
        private System.Windows.Forms.Label lblTitleText;
        private System.Windows.Forms.Label lblClose;
        private System.Windows.Forms.Label lblMin;
        private System.Windows.Forms.Label lblMax;
        private System.Windows.Forms.ToolTip tip;
    }
}