using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using AnyExtend;

namespace AnyControl
{
    public partial class PanelForm : Form
    {
        // 记录最后一次按键时间
        protected Dictionary<Keys, DateTime> dicKeyTimer;
        
        public PanelForm()
        {
            InitializeComponent();

            dicKeyTimer = new Dictionary<Keys, DateTime>();
        }

        #region 对外属性

        #region CenterLocation

        /// <summary>
        /// 获取中心坐标
        /// </summary>
        [Browsable(false), Category("布局"), Description("中心坐标")]
        public Point CenterLocation
        {
            get { return new Point(Width / 2, Height / 2); }
        }

        #endregion

        #endregion

        #region 事件
        
        #endregion

        #region 私有方法

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // 记录按键时间，并计算两次按键时间间隔
            TimeSpan ts = new TimeSpan();
            DateTime now = DateTime.Now;

            ts = now - dicKeyTimer.SafeAdd(keyData, now);

            switch (keyData)
            {
                // 双击Esc键退出
                case Keys.Escape:
                    if (0 < ts.TotalSeconds && ts.TotalSeconds < 0.5)
                    {
                        this.Close();
                        return true;
                    }
                    break;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion
        
        #region 公共方法

        public void Show(string showAction, IWin32Window owner = null)
        {
            //int width = Width;
            //Width = 0;
            //while (Width < width)
            //{
            //    Width += 1;
            //}
            base.Show(owner);
        }

        #endregion
    }
}
