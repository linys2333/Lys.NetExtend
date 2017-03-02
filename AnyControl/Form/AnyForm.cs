using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AnyExtend;

namespace AnyControl
{
    public partial class AnyForm : PanelForm
    {
        // 记录鼠标坐标
        protected Dictionary<MouseButtons, Point> dicMousePoint;
        
        public AnyForm()
        {
            InitializeComponent();
            
            dicMousePoint = new Dictionary<MouseButtons, Point>();
        }

        #region 对外属性
        
        #endregion

        #region 事件

        private void LysForm_Paint(object sender, PaintEventArgs e)
        {
            var borderColor = Color.FromArgb(0, 99, 177);
            var borderStyle = ButtonBorderStyle.Solid;
            var rect = new Rectangle(0, 0, Width, Height);

            ControlPaint.DrawBorder(e.Graphics, rect, 
                borderColor, 1, borderStyle,
                borderColor, 1, borderStyle,
                borderColor, 1, borderStyle,
                borderColor, 1, borderStyle);
        }

        #region 标题栏

        private void pnlTitle_MouseDown(object sender, MouseEventArgs e)
        {
            dicMousePoint.SafeAdd(e.Button, e.Location);
        }

        private void pnlTitle_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Location = MousePosition.Diff(dicMousePoint[e.Button]);
            }
        }

        private void titleBtn_MouseEnter(object sender, EventArgs e)
        {
            var titleBtn = sender as Label;
            titleBtn.BackColor = Color.FromArgb(26, 115, 185);
        }

        private void titleBtn_MouseLeave(object sender, EventArgs e)
        {
            var titleBtn = sender as Label;
            titleBtn.BackColor = pnlTitle.BackColor;
        }

        private void lblMin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void lblMax_Click(object sender, EventArgs e)
        {
            var titleBtn = sender as Label;

            if (WindowState == FormWindowState.Maximized)
            {
                titleBtn.Text = @"口";
                tip.SetToolTip(this.lblMax, "最大化");
                WindowState = FormWindowState.Normal;
            }
            else
            {
                titleBtn.Text = @"□";
                tip.SetToolTip(this.lblMax, "还原");
                WindowState = FormWindowState.Maximized;
            }
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #endregion

        #region 私有方法
        
        #endregion
        
        #region 公共方法

        #endregion
    }

    public class TitleBar
    {
        public string Title;
    }
}
