using blank.Primitives;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blank.Shapes
{
    internal class Octahedron : Object3D
    {
        public Octahedron() : base()
        {
            //грань 1 (A-B'-C)
            mech.AddFace(new Vector4(0, 1, 0), new Vector4(1, 0, 0), new Vector4(0, 0, 1), Color.Orange);

            //грань 2 (A-B-C)
            mech.AddFace(new Vector4(0, 1, 0), new Vector4(-1, 0, 0), new Vector4(0, 0, 1), Color.Green);

            //грань 3 (A-B-C')
            mech.AddFace(new Vector4(0, 1, 0), new Vector4(-1, 0, 0), new Vector4(0, 0, -1), Color.Gray);

            //грань 4 (A-B'-C')
            mech.AddFace(new Vector4(0, 1, 0), new Vector4(1, 0, 0), new Vector4(0, 0, -1), Color.DarkBlue);

            //грань 5 ('A-B'-C)
            mech.AddFace(new Vector4(0, -1, 0), new Vector4(1, 0, 0), new Vector4(0, 0, 1), Color.Brown);

            //грань 6 (A'-B-C)
            mech.AddFace(new Vector4(0, -1, 0), new Vector4(-1, 0, 0), new Vector4(0, 0, 1), Color.Silver);

            //грань 7 (A'-B-C')
            mech.AddFace(new Vector4(0, -1, 0), new Vector4(-1, 0, 0), new Vector4(0, 0, -1), Color.Pink);

            //грань 8 (A'-B'-C')
            mech.AddFace(new Vector4(0, -1, 0), new Vector4(1, 0, 0), new Vector4(0, 0, -1), Color.Purple);
        }
        public Octahedron(Transform transform) : this()
        {
            this.transform = transform;
        }
    }
}
