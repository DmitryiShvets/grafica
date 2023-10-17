using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blank
{
    public class PointArray
    {
        private int index = 0;
        private Point2D[] points;

        public Point2D[] Points { get => points; }

        public PointF[] ToPoints()
        {
            PointF[] p = new PointF[Points.Length];
            for (int i = 0;i< Points.Length; i++)
            {
                p[i] = points[i].ToPointF();
            }
            return p;
        }

        public PointArray(int points_count)
        {
            if (points_count <= 0) points_count = 2;
            points = new Point2D[points_count];
        }

        public void SetPoint(int x, int y)
        {
            if (index >= points.Length)
            {
                index = 0;
            }
            points[index] = new Point2D(x, y);
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
