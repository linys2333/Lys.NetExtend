using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using AnyExtend;

namespace AnyControl
{
    /// <summary>
    /// 带图标文本框
    /// </summary>
    public partial class TextBoxPic : AnyControl
    {
        private bool _isShowTipText = true;

        public TextBoxPic()
        {
            InitializeComponent();

            SetTextStyle();
        }
        
        #region 方法

        /// <summary>
        /// 设置文本框的样式，比如控制TipText
        /// </summary>
        protected void SetTextStyle()
        {
            txtpTipText.Visible = _isShowTipText;
        }

        #endregion

        #region 事件
        
        private void txtpPic_Resize(object sender, EventArgs e)
        {
            txtpPanel.Width = this.Height;
        }

        private void txtpText_Resize(object sender, EventArgs e)
        {
            txtpText.Width = this.Width - txtpPanel.Width;
        }

        private void txtpText_TextChanged(object sender, EventArgs e)
        {
            _isShowTipText = txtpText.Text.IsEmpty(true);

            SetTextStyle();

            this.TextChanged?.Invoke(sender, e);
        }

        private void txtpText_KeyUp(object sender, KeyEventArgs e) => this.OnKeyUp(e);

        #endregion

        #region 对外属性

        #region BackColor
        
        [Browsable(true)]
        public new Color BackColor
        {
            get { return txtpText.BackColor; }
            set
            {
                txtpText.BackColor = value;
                base.BackColor = value;
            }
        }

        #endregion
        
        #region Text

        [Browsable(true)]
        public override string Text
        {
            get { return txtpText.Text; }
            set { txtpText.Text = value; }
        }

        #endregion

        #region Font

        [Browsable(true)]
        public new Font Font
        {
            get { return txtpText.Font; }
            set
            {
                txtpText.Font = value;
                base.Font = value;
            }
        }

        #endregion

        #region TextReadOnly

        /// <summary>
        /// 获取或设置文本只读状态
        /// </summary>
        [Browsable(true), DefaultValue(false), Category("行为"), Description("控制文本是否只读")]
        public bool TextReadOnly
        {
            get { return txtpText.ReadOnly; }
            set { txtpText.ReadOnly = value; }
        }

        #endregion

        #region TipText

        /// <summary>
        /// 获取或设置提示文本
        /// </summary>
        [Browsable(true), Category("外观"), Description("输入前的提示文本")]
        public string TipText
        {
            get { return txtpTipText.Text; }
            set { txtpTipText.Text = value; }
        }

        #endregion

        #region ForeColor

        [Browsable(true)]
        public override Color ForeColor
        {
            get { return txtpText.ForeColor; }
            set { txtpText.ForeColor = value; }
        }

        #endregion

        #region PicPadding

        /// <summary>
        /// 获取或设置图像的内部间距
        /// </summary>
        [Browsable(true), Category("布局"), Description("图像的内部间距")]
        public Padding PicPadding
        {
            get { return txtpPanel.Padding; }
            set { txtpPanel.Padding = value; }
        }

        public bool ShouldSerializePicPadding()
        {
            return PicPadding != new Padding(2);
        }

        public void ResetPicPadding()
        {
            PicPadding = new Padding(2);
        }

        #endregion

        #region Image

        /// <summary>
        /// 获取或设置要显示的图像
        /// </summary>
        [Browsable(true), Category("外观"), Description("显示的图像")]
        public Image Image
        {
            get { return txtpPic.Image; }
            set { txtpPic.Image = value; }
        }

        #endregion

        #region UnderLineVisible

        /// <summary>
        /// 获取或设置底边显示状态
        /// </summary>
        [Browsable(true), DefaultValue(true), Category("行为"), Description("控制底边是否显示")]
        public bool UnderLineVisible
        {
            get { return txtpUnderLine.Visible; }
            set { txtpUnderLine.Visible = value; }
        }

        #endregion

        #endregion

        #region 对外事件
        
        #region TextChanged

        [Browsable(true)]
        public new event EventHandler TextChanged;

        #endregion

        #endregion
    }
}
