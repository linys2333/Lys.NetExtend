using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace AnyControl
{
    public partial class AnyControl : UserControl
    {
        public AnyControl()
        {
            InitializeComponent();
        }

        #region 方法

        #endregion

        #region 事件

        #endregion

        #region 对外属性

        #region EndLocation

        /// <summary>
        /// 获取控件右下角坐标
        /// </summary>
        [Browsable(false), Category("布局"), Description("控件右下角坐标")]
        public Point EndLocation
        {
            get { return this.Location + this.Size; }
        }
        
        #endregion

        #endregion

        #region 对外事件

        #endregion
    }
}
