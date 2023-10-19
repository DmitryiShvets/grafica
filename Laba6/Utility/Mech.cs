using blank.Primitives;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blank.Utility
{
    internal class Mech
    {
        public List<Triangle3D> faces;

        public Mech()
        {
            faces = new List<Triangle3D>();
        }

        public void AddFace(Vector4 a, Vector4 b, Vector4 c , Color color)
        {
            faces.Add(new Triangle3D(a,b,c,color));
        }

        public void AddFace(Triangle3D face)
        {
            faces.Add(face);
        }

    }
}
