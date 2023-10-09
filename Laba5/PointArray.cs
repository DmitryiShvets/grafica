using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba5
{
    public class PointArray
    {
        private int index = 0;
        private Point[] points;

        public Point[] Points { get => points; }

        public PointArray(int points_count)
        {
            if (points_count <= 0) points_count = 2;
            points = new Point[points_count];
        }

        public void SetPoint(int x, int y)
        {
            if (index >= points.Length)
            {
                index = 0;
            }
            points[index] = new Point(x, y);
            index++;
        }

        public void Clear()
        {
            index = 0;
        }

        public int Count()
        {
            return index;
        }
    }
}
