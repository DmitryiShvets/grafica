using blank.Primitives;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blank.Shapes
{
    internal class Icosahedron : Object3D
    {
        Vector4 GetPoint(int v)
        {
            switch(v)
            {
                case 1:
                    return new Vector4(-1, 0, 0.5f);
                case 2:
                    return new Vector4(-1, 0, -0.5f);
                case 3:
                    return new Vector4(-0.5f, 1, 0);
                case 4:
                    return new Vector4(0, 0.5f, 1);
                case 5:
                    return new Vector4(0, -0.5f, 1);
                case 6:
                    return new Vector4(-0.5f, -1, -0.5f);
                case 7:
                    return new Vector4(0.5f, 1, 0);
                case 8:
                    return new Vector4(1, 0, 0.5f);
                case 9:
                    return new Vector4(0.5f, -1, -0.5f);
                case 10:
                    return new Vector4(0, -0.5f, -1);
                case 11:
                    return new Vector4(0, 0.5f, -1);
                case 12:
                    return new Vector4(1, 0, -0.5f);
                default:
                    return new Vector4(0, 0, 0);
            }
        }

        public Icosahedron() : base()
        {
            // 1-2-3
            mech.AddFace(GetPoint(1), GetPoint(2), GetPoint(3), Color.Orange);
            // 1-3-4
            mech.AddFace(GetPoint(1), GetPoint(3), GetPoint(4), Color.Orange);
            // 1-4-5
            mech.AddFace(GetPoint(1), GetPoint(4), GetPoint(5), Color.Orange);
            // 1-5-6
            mech.AddFace(GetPoint(1), GetPoint(5), GetPoint(6), Color.Orange);
            // 1-6-2
            mech.AddFace(GetPoint(1), GetPoint(2), GetPoint(6), Color.Orange);

            // 12-11-10
            mech.AddFace(GetPoint(12), GetPoint(11), GetPoint(10), Color.Orange);
            // 12-10-9
            mech.AddFace(GetPoint(12), GetPoint(10), GetPoint(9), Color.Orange);
            // 12-9-8
            mech.AddFace(GetPoint(12), GetPoint(8), GetPoint(9), Color.Orange);
            // 12-8-7
            mech.AddFace(GetPoint(12), GetPoint(8), GetPoint(7), Color.Orange);
            // 12-7-11
            mech.AddFace(GetPoint(12), GetPoint(11), GetPoint(7), Color.Orange);


            // 2-3-7
            mech.AddFace(GetPoint(2), GetPoint(3), GetPoint(7), Color.Orange);
            // 3-7-8
            mech.AddFace(GetPoint(3), GetPoint(7), GetPoint(8), Color.Orange);
            // 3-4-8
            mech.AddFace(GetPoint(3), GetPoint(4), GetPoint(8), Color.Orange);
            // 4-8-9
            mech.AddFace(GetPoint(4), GetPoint(8), GetPoint(9), Color.Orange);
            // 4-5-9
            mech.AddFace(GetPoint(4), GetPoint(5), GetPoint(9), Color.Orange);
            // 5-9-10
            mech.AddFace(GetPoint(5), GetPoint(9), GetPoint(10), Color.Orange);
            // 5-6-10
            mech.AddFace(GetPoint(5), GetPoint(6), GetPoint(10), Color.Orange);
            // 6-10-11
            mech.AddFace(GetPoint(6), GetPoint(10), GetPoint(11), Color.Orange);
            // 2-6-11
            mech.AddFace(GetPoint(2), GetPoint(6), GetPoint(11), Color.Orange);
            // 2-7-11
            mech.AddFace(GetPoint(2), GetPoint(7), GetPoint(11), Color.Orange);

        }
        public Icosahedron(Transform transform) : this()
        {
            this.transform = transform;
        }

    }
}
