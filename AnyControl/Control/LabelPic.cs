using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace AnyControl
{
    public partial class LabelPic : Label
    {
        public LabelPic()
        {
            InitializeComponent();
            SetStyle();
        }

        #region 方法

        /// <summary>
        /// 根据IsShowPic属性，设置标签显示样式
        /// </summary>
        public void SetStyle()
        {
            if (IsShowPic)
            {
                base.Text = "";
                base.Image = _image;
            }
            else
            {
                base.Text = _text;
                base.Image = null;
            }
        }

        #endregion

        #region 对外属性

        #region IsShowPic

        /// <summary>
        /// 设置显示文字还是图标
        /// </summary>
        [Browsable(true), Category("外观"), Description("显示文字还是图标")]
        public bool IsShowPic { get; set; }

        #endregion

        #region Text

        [Browsable(true)]
        private string _text;
        public new string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                base.Text = value;
            }
        }

        #endregion

        #region Image

        [Browsable(true)]
        private Image _image;
        public new Image Image
        {
            get { return _image; }
            set
            {
                _image = value;
                base.Image = value;
            }
        }

        #endregion

        #endregion
    }
}
