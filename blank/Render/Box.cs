using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blank.Render
{
    internal class Box : Shape, IIntersect
    {
        public Vector4[] bounds = new Vector4[2];
        private Vector4[] normals = new Vector4[6];

        public Box(Vector4 v1, Vector4 v2, Vector4 pos, Color color,int specular,double reflective) 
            : base(pos, color, specular, reflective)
        {
            bounds[0] = pos + v1;
            bounds[1] = pos + v2;
        }

        public Vector4 GetNormal(Vector4 point)
        {
            Vector4 center = (bounds[0] + bounds[1]) / 2;
            Vector4 p = point - center;
            Vector4 d = (bounds[0] - bounds[1]) / 2;
            double bias = 1.000001;

            int x = (int)(p.x / Math.Abs(d.x) * bias);
            int y = (int)(p.y / Math.Abs(d.y) * bias);
            int z = (int)(p.z / Math.Abs(d.z) * bias);

            return new Vector4(x, y, z).Normalize();
        }


        public Vector4 GetNormal1(Vector4 p)
        {
            foreach (Vector4 normal in normals)
            {
                double s = Vector4.DotProduct(p, normal);
                if (s == 0)
                {
                    //Console.WriteLine(normal);
                    return normal;
                }
            }
            return new Vector4();
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
