using System.Drawing;

namespace AnyControl
{
    public static class FormExt
    {
        /// <summary>
        /// a点相对于b点的偏差值
        /// </summary>
        /// <returns></returns>
        public static Point Diff(this Point a, Point b)
        {
            return new Point(a.X - b.X, a.Y - b.Y);
        }
    }
}
