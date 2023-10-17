using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blank.Primitives
{
    internal class Triangle3D
    {
        private Vector4[] vertexes;
        private Vector4 normal;

        public Triangle3D(Vector4 v1, Vector4 v2, Vector4 v3)
        {
            this.vertexes = new Vector4[3];
            this.vertexes[0] = v1;
            this.vertexes[1] = v2;
            this.vertexes[2] = v3;
            this.normal = Vector4.CrossProduct(v2 - v1, v3 - v1);
            this.normal = normal * (float)(1.0 / normal.Length());
        }

        public Vector4 this[int key]
        {
            get => vertexes[key];
        }

        internal Vector4 Normal { get => normal; }
    }
}
