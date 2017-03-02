using System.Windows.Forms;

namespace AnyControl
{
    public static class MsgBox
    {
        public static void OK(string message)
        {
            MessageBox.Show(message, "提示", MessageBoxButtons.OK,
                MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        public static void Warning(string message)
        {
            MessageBox.Show(message, "提示", MessageBoxButtons.OK,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
        }

        public static bool YesNo(string message, bool defaultYes = true)
        {
            return MessageBox.Show(message, "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, 
                defaultYes ? MessageBoxDefaultButton.Button1 : MessageBoxDefaultButton.Button2) == DialogResult.Yes;
        }

        public static void Error(string message)
        {
            MessageBox.Show(message, "提示", MessageBoxButtons.OK, 
                MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        }

        public static bool ShowSaveDialog(ref string fileName)
        {
            var dialog = new SaveFileDialog
            {
                FileName = fileName
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                fileName = dialog.FileName;
                return true;
            }
            return false;
        }
    }
}
