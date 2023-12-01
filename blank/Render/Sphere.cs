using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blank.Render
{
    internal class Sphere : Shape, IIntersect
    {
        public int radius;

        public Sphere(int radius)
        {
            this.radius = radius;
        }

        public Sphere(Vector4 pos, Color color, int radius) : base(pos, color)
        {
            this.radius = radius;
        }

        public (double, double) Intersect(Vector4 origin, Vector4 direction)
        {
            Vector4 oc = origin - position;

            double a = Vector4.DotProduct(direction, direction);
            double b = 2 * Vector4.DotProduct(oc, direction);
            double c = Vector4.DotProduct(oc, oc) - radius * radius;

            double discrminant = (b * b) - (4 * a * c);

            if (discrminant < 0)
            {
                return (Infinity, Infinity);
            }

            double t1 = (-b + Math.Sqrt(discrminant)) / (2 * a);
            double t2 = (-b - Math.Sqrt(discrminant)) / (2 * a);

            return (t1, t2);
        }

    }
}
