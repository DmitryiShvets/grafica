using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blank.Primitives
{
    internal class Triangle3D
    {
        private List<Vector4> vertexes;
        private Vector4 normal;
        public Color color;

        public Triangle3D(Color color)
        {
            this.vertexes = new List<Vector4>();
            this.normal = new Vector4();
            this.color = color;
        }

        public Triangle3D(Vector4 v1, Vector4 v2, Vector4 v3)
        {
            this.vertexes = new List<Vector4>(3) { v1, v2, v3 };

            this.normal = Vector4.CrossProduct(v2 - v1, v3 - v1);
            this.normal = normal * (float)(1.0 / normal.Length());
            this.color = Color.Black;
        }

        public Triangle3D(Vector4 v1, Vector4 v2, Vector4 v3, Color color)
        {
            this.vertexes = new List<Vector4>(3) { v1, v2, v3 };

            this.normal = Vector4.CrossProduct(v2 - v1, v3 - v1);
            this.normal = normal * (float)(1.0 / normal.Length());
            this.color = color;
        }

        public void AddVertex(Vector4 v)
        {
            this.vertexes.Add(v);
        }


        public Vector4 this[int key]
        {
            get => vertexes[key];
        }
        public int Size { get => this.vertexes.Count; }
        public Vector4 Normal { get => normal; }
    }
}
