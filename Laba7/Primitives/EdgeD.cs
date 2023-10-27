using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace blank
{
    internal class EdgeD : Edge
    {
        public EdgeD() : base() { }
        public EdgeD(Point2D origin, Point2D dest) : base(origin, dest) { }

        public override Point2D Point(double t)
        {
            Point2D p = origin + (float)t * (dest - origin);
            return p;
        }

        public ORIENTATION_EDGE Intersect(ref EdgeD e, ref double t)
        {

            Point2D a = origin;
            Point2D b = dest;
            Point2D c = e.origin;
            Point2D d = e.dest;
            Point2D n = new Point2D((d - c).y, (c - d).x);
            Console.WriteLine($"pointN = {n.x}, {n.y}");
            double denom = dotProduct(n, b - a);
            Console.WriteLine($"denom = {denom}");
            if (denom == 0.0)
            {
                int aclass = (int)origin.Classify(e);
                if ((aclass == (int)Point2D.ORIENTATION.LEFT) || (aclass == (int)Point2D.ORIENTATION.RIGHT))
                    return ORIENTATION_EDGE.PARALLEL;
            }
            else
            {
                return ORIENTATION_EDGE.COLLINEAR;
            }
            double num = dotProduct(n, a - c);
            Console.WriteLine($"num = {num}");
            t = -num / denom;
            Console.WriteLine($"t = {t}");
            return ORIENTATION_EDGE.SKEW;
        }

        double dotProduct(Point2D p, Point2D q)
        {
            return (p.x * q.x + p.y * q.y);
        }
        public ORIENTATION_EDGE Cross(ref EdgeD e, ref double t)
        {
            double s = 0.0;
            EdgeD eD = this;
            int crossType = (int)e.Intersect(ref eD, ref s);
            if ((crossType == (int)ORIENTATION_EDGE.COLLINEAR) || (crossType == (int)ORIENTATION_EDGE.PARALLEL))
            {
                return (ORIENTATION_EDGE)crossType;
            }
            if ((s < 0.0) || (s > 1.0))
            {
                return ORIENTATION_EDGE.SKEW_NO_CROSS;
            }
            Intersect(ref e, ref t);
            if ((0.0 <= t) && (t <= 1.0))
            {
                return ORIENTATION_EDGE.SKEW_CROSS;
            }
            else
            {
                return ORIENTATION_EDGE.SKEW_NO_CROSS;
            }
        }

    }
}
