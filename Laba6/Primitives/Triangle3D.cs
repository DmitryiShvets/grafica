using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blank.Primitives
{
    internal class Triangle3D
    {
        private Point3D[] vertexes;
        private Point3D normal;

        public Triangle3D(Point3D v1, Point3D v2, Point3D v3)
        {
            this.vertexes = new Point3D[3];
            this.vertexes[0] = v1;
            this.vertexes[1] = v2;
            this.vertexes[2] = v3;
            this.normal = Point3D.CrossProduct(v2 - v1, v3 - v1);
            this.normal = normal * (float)(1.0 / normal.Length());
        }

        public Point3D this[int key]
        {
            get => vertexes[key];
        }

        internal Point3D Normal { get => normal; }
    }
}
