using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using blank.Primitives;
namespace blank.Shapes
{
    internal class Cube : Object3D
    {
        public Cube() : base()
        {
            //плоскость X-Y
            mech.AddFace(new Vector4(-1, 1, 1), new Vector4(1, 1, 1), new Vector4(-1, -1, 1), Color.Orange);
            mech.AddFace(new Vector4(1, -1, 1), new Vector4(1, 1, 1), new Vector4(-1, -1, 1), Color.Orange);

            //плоскость Z+Y
            mech.AddFace(new Vector4(1, 1, -1), new Vector4(1, 1, 1), new Vector4(1, -1, -1), Color.Green);
            mech.AddFace(new Vector4(1, -1, 1), new Vector4(1, 1, 1), new Vector4(1, -1, -1), Color.Green);

            //плоскость Z-Y
            mech.AddFace(new Vector4(-1, 1, -1), new Vector4(-1, 1, 1), new Vector4(-1, -1, -1), Color.Gray);
            mech.AddFace(new Vector4(-1, -1, 1), new Vector4(-1, 1, 1), new Vector4(-1, -1, -1), Color.Gray);

            //плоскость Z+X
            mech.AddFace(new Vector4(-1, 1, 1), new Vector4(1, 1, 1), new Vector4(-1, 1, -1), Color.Red);
            mech.AddFace(new Vector4(1, 1, -1), new Vector4(1, 1, 1), new Vector4(-1, 1, -1), Color.Red);

            //плоскость Z-X
            mech.AddFace(new Vector4(-1, -1, 1), new Vector4(1, -1, 1), new Vector4(-1, -1, -1), Color.Pink);
            mech.AddFace(new Vector4(1, -1, -1), new Vector4(1, -1, 1), new Vector4(-1, -1, -1), Color.Pink);

            //плоскость X+Y
            mech.AddFace(new Vector4(-1, 1, -1), new Vector4(1, 1, -1), new Vector4(-1, -1, -1), Color.Blue);
            mech.AddFace(new Vector4(1, -1, -1), new Vector4(1, 1, -1), new Vector4(-1, -1, -1), Color.Blue);

        }
        public Cube(Transform transform) : this()
        {
            this.transform = transform;
        }
    }

    internal class Line : Object3D
    {
        public Line(Vector4 point1, Vector4 point2) : base()
        {
            mech.AddFace(point1, point2, point2, Color.Red);
        }
    }
}
