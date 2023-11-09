using blank.Primitives;
using blank.Utility;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blank.Shapes
{
    internal class Dodecahedron : Object3D
    {
        private static float phi = (float)((1 + Math.Sqrt(5)) / 2); // Золотое сечение

        private static float a = (float)(1.0 / Math.Sqrt(phi * phi + 1));
        private static float b = a * phi;
        private static float c = a;

        Vector4[] vertices = new Vector4[]
        {
            new Vector4(a, a, a),
            new Vector4(a, a, -a),
            new Vector4(a, -a, a),
            new Vector4(a, -a, -a),
            new Vector4(-a, a, a),
            new Vector4(-a, a, -a),
            new Vector4(-a, -a, a),
            new Vector4(-a, -a, -a),
            new Vector4(0, b, c),
            new Vector4(0, b, -c),
            new Vector4(0, -b, c),
            new Vector4(0, -b, -c),
            new Vector4(b, c, 0),
            new Vector4(b, -c, 0),
            new Vector4(-b, c, 0),
            new Vector4(-b, -c, 0),
            new Vector4(c, 0, b),
            new Vector4(c, 0, -b),
            new Vector4(-c, 0, b),
            new Vector4(-c, 0, -b)
        };

        public Dodecahedron() : base()
        {

            // Перечисляем треугольники
            mech.AddFace(vertices[0], vertices[8], vertices[4], Color.Orange);
            mech.AddFace(vertices[0], vertices[4], vertices[16], Color.Green);
            mech.AddFace(vertices[0], vertices[16], vertices[17], Color.Gray);
            mech.AddFace(vertices[0], vertices[17], vertices[12], Color.Lime);
            mech.AddFace(vertices[0], vertices[12], vertices[8], Color.Pink);

            mech.AddFace(vertices[1], vertices[9], vertices[5], Color.DarkBlue);
            mech.AddFace(vertices[1], vertices[5], vertices[14], Color.Purple);
            mech.AddFace(vertices[1], vertices[14], vertices[15], Color.Magenta);
            mech.AddFace(vertices[1], vertices[15], vertices[13], Color.Gold);
            mech.AddFace(vertices[1], vertices[13], vertices[9], Color.Fuchsia);

            mech.AddFace(vertices[2], vertices[6], vertices[10], Color.LightBlue);
            mech.AddFace(vertices[2], vertices[10], vertices[18], Color.Olive);
            mech.AddFace(vertices[2], vertices[18], vertices[19], Color.SeaGreen);
            mech.AddFace(vertices[2], vertices[19], vertices[11], Color.YellowGreen);
            mech.AddFace(vertices[2], vertices[11], vertices[6], Color.Tomato);

            mech.AddFace(vertices[3], vertices[7], vertices[13], Color.Silver);
            mech.AddFace(vertices[3], vertices[13], vertices[15], Color.RosyBrown);
            mech.AddFace(vertices[3], vertices[15], vertices[12], Color.Peru);
            mech.AddFace(vertices[3], vertices[12], vertices[17], Color.PaleGreen);
            mech.AddFace(vertices[3], vertices[17], vertices[7], Color.Moccasin);

            mech.AddFace(vertices[4], vertices[8], vertices[9], Color.Red);
            mech.AddFace(vertices[4], vertices[9], vertices[13], Color.Blue);
            mech.AddFace(vertices[4], vertices[13], vertices[7], Color.GreenYellow);
            mech.AddFace(vertices[4], vertices[7], vertices[16], Color.Yellow);
            mech.AddFace(vertices[4], vertices[16], vertices[8], Color.Orange);

            mech.AddFace(vertices[5], vertices[9], vertices[8], Color.Blue);
            mech.AddFace(vertices[5], vertices[8], vertices[12], Color.GreenYellow);
            mech.AddFace(vertices[5], vertices[12], vertices[15], Color.Yellow);
            mech.AddFace(vertices[5], vertices[15], vertices[14], Color.Orange);
            mech.AddFace(vertices[5], vertices[14], vertices[9], Color.Red);

            mech.AddFace(vertices[10], vertices[6], vertices[11], Color.GreenYellow);
            mech.AddFace(vertices[10], vertices[11], vertices[19], Color.Yellow);
            mech.AddFace(vertices[10], vertices[19], vertices[18], Color.Orange);
            mech.AddFace(vertices[10], vertices[18], vertices[14], Color.Red);
            mech.AddFace(vertices[10], vertices[14], vertices[6], Color.Blue);

            mech.AddFace(vertices[11], vertices[6], vertices[7], Color.Blue);
            mech.AddFace(vertices[11], vertices[7], vertices[17], Color.GreenYellow);
            mech.AddFace(vertices[11], vertices[17], vertices[16], Color.Yellow);
            mech.AddFace(vertices[11], vertices[16], vertices[18], Color.Orange);
            mech.AddFace(vertices[11], vertices[18], vertices[6], Color.Red);

        }

        public Dodecahedron(Transform transform) : this()
        {
            this.transform = transform;
        }
    }
}
