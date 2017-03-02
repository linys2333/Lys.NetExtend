namespace AnyControl
{
    // 分割栏菜单
    public partial class SplitMenu : AnyControl
    {
        public SplitMenu()
        {
            InitializeComponent();
        }

        #region 对外属性

        #region Title

        public string Title
        {
            get{ return lblTitle.Text; }
            set { lblTitle.Text = value; }
        }

        #endregion

        #endregion
    }
}
