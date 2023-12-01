using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blank.Render
{
    internal class Box : Shape,IIntersect
    {
        public Vector4[] bounds = new Vector4[2];
        public Box(Vector4 v1, Vector4 v2, Vector4 pos, Color color) : base(pos, color)
        {
            if (v1.Length() < v2.Length())
            {
                bounds[0] = pos + v1;
                bounds[1] = pos + v2;
            }
            else
            {
                bounds[0] = pos + v2;
                bounds[1] = pos + v1;
            }

        }

        public (double, double) Intersect(Vector4 origin, Vector4 direction)
        {
            double tmin = (bounds[0].x - origin.x) / direction.x;
            double tmax = (bounds[1].x - origin.x) / direction.x;

            if (tmin > tmax) (tmin, tmax) = (tmax, tmin);

            double tymin = (bounds[0].y - origin.y) / direction.y;
            double tymax = (bounds[1].y - origin.y) / direction.y;

            if (tymin > tymax) (tymin, tymax) = (tymax, tymin);

            if ((tmin > tymax) || (tymin > tmax)) return (Infinity, Infinity);

            if (tymin > tmin) tmin = tymin;
            if (tymax < tmax) tmax = tymax;

            double tzmin = (bounds[0].z - origin.z) / direction.z;
            double tzmax = (bounds[1].z - origin.z) / direction.z;

            if (tzmin > tzmax) (tzmin, tzmax) = (tzmax, tzmin);

            if ((tmin > tzmax) || (tzmin > tmax)) return (Infinity, Infinity);

            if (tzmin > tmin) tmin = tzmin;
            if (tzmax < tmax) tmax = tzmax;

            return (tmin, tmax);
        }
    }
}
