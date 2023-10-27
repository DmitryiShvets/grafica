using blank.Primitives;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blank.Shapes
{
    internal class Tetrahedron : Object3D
    {
        public Tetrahedron() : base()
        {

            //грань 1 (A-B-C)
            mech.AddFace(new Vector4(1, -1, -1), new Vector4(-1, 1, -1), new Vector4(-1, -1, 1), Color.Orange);

            //грань 2 (A-B-D)
            mech.AddFace(new Vector4(1, -1, -1), new Vector4(-1, 1, -1), new Vector4(1, 1, 1), Color.Green);

            //грань 3 (C-B-D)
            mech.AddFace(new Vector4(-1, -1, 1), new Vector4(-1, 1, -1), new Vector4(1, 1, 1), Color.Red);

            //грань 4 (A-C-D)
            mech.AddFace(new Vector4(1, -1, -1), new Vector4(-1, -1, 1), new Vector4(1, 1, 1), Color.Blue);
        }
        public Tetrahedron(Transform transform) : this()
        {
            this.transform = transform;
        }
    }
}
