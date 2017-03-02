using System.Windows.Forms;

namespace AnyControl
{
    public static class GridExt
    {
        public static void CreateIndex(this DataGridView dgv, string indexColName)
        {
            int rowIndex = 1;
            foreach (DataGridViewRow row in dgv.Rows)
            {
                row.Cells[indexColName].Value = rowIndex;
                rowIndex++;
            }
        }
    }
}
