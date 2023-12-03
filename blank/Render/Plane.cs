using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace blank.Render
{
    internal class Plane : Shape, IIntersect
    {
        Vector4 point;
        Vector4 normal;

        public Plane(Vector4 p, Vector4 normal, Color color, double specular, double reflective, double transparency)
             : base(p, color, specular, reflective, transparency)
        {
            this.point = p;
            this.normal = normal;
        }

        public Vector4 GetNormal(Vector4 p)
        {
            return normal;
        }

        public (double, double) Intersect(Vector4 origin, Vector4 direction)
        {
            var d = Vector4.DotProduct(point, -normal);
            var t = -(d + Vector4.DotProduct(origin, normal)) / Vector4.DotProduct(direction, normal);
            if (t <= 1e-4) return (Infinity, Infinity);
            else return (t, t);
        }
        public override string ToString()
        {
            return "Plane (" + color + ")";
        }
    }
}
