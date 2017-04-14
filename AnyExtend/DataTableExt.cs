using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace AnyExtend
{
    public static class DataTableExt
    {
        public static void RemoveCol(this DataTable dt, string col)
        {
            if (dt.Columns.Contains(col))
            {
                dt.Columns.Remove(col);
            }
        }
    }
}
