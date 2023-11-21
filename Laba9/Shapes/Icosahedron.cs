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
        private static float phi = (float)((1 + Math.Sqrt(5)) / 2); // Золотое сечение

        private List<Vector4> vertices = new List<Vector4>() {
                new Vector4(-1, phi, 0), // Вершина 0
                new Vector4(1, phi, 0), // Вершина 1
                new Vector4(-1, -phi, 0), // Вершина 2
                new Vector4(1, -phi, 0), // Вершина 3
                new Vector4(0, -1, phi), // Вершина 4
                new Vector4(0, 1, phi), // Вершина 5
                new Vector4(0, -1, -phi), // Вершина 6
                new Vector4(0, 1, -phi), // Вершина 7
                new Vector4(phi, 0, -1), // Вершина 8
                new Vector4(phi, 0, 1), // Вершина 9
                new Vector4(-phi, 0, -1), // Вершина 10
                new Vector4(-phi, 0, 1) // Вершина 11
            };

        public Icosahedron() : base()
        {
            // 0, 11, 5, Треугольник 0
            mech.AddFace(vertices[0], vertices[11], vertices[5], Color.Orange);

            // 0, 5, 1, Треугольник 1
            mech.AddFace(vertices[0], vertices[5], vertices[1], Color.Green);

            // 0, 1, 7, Треугольник 2
            mech.AddFace(vertices[0], vertices[1], vertices[7], Color.Gray);

            // 0, 7, 10, Треугольник 3
            mech.AddFace(vertices[0], vertices[7], vertices[10], Color.Lime);

            // 0, 10, 11, Треугольник 4
            mech.AddFace(vertices[0], vertices[10], vertices[11], Color.Pink);

            // 1, 5, 9, Треугольник 5
            mech.AddFace(vertices[1], vertices[5], vertices[9], Color.DarkBlue);

            // 5, 11, 4, Треугольник 6
            mech.AddFace(vertices[5], vertices[11], vertices[4], Color.Purple);

            // 11, 10, 2, Треугольник 7
            mech.AddFace(vertices[11], vertices[10], vertices[2], Color.Magenta);

            // 10, 7, 6, Треугольник 8
            mech.AddFace(vertices[10], vertices[7], vertices[6], Color.Gold);

            // 7, 1, 8, Треугольник 9
            mech.AddFace(vertices[7], vertices[1], vertices[8], Color.Fuchsia);

            // 3, 9, 4, Треугольник 10
            mech.AddFace(vertices[3], vertices[9], vertices[4], Color.LightBlue);

            // 3, 4, 2, Треугольник 11
            mech.AddFace(vertices[3], vertices[4], vertices[2], Color.Olive);

            // 3, 2, 6, Треугольник 12
            mech.AddFace(vertices[3], vertices[2], vertices[6], Color.SeaGreen);

            // 3, 6, 8, Треугольник 13
            mech.AddFace(vertices[3], vertices[6], vertices[8], Color.YellowGreen);

            // 3, 8, 9, Треугольник 14
            mech.AddFace(vertices[3], vertices[8], vertices[9], Color.Tomato);

            // 4, 9, 5, Треугольник 15
            mech.AddFace(vertices[4], vertices[9], vertices[5], Color.Silver);

            // 2, 4, 11, Треугольник 16
            mech.AddFace(vertices[2], vertices[4], vertices[11], Color.RosyBrown);

            // 6, 2, 10, Треугольник 17
            mech.AddFace(vertices[6], vertices[2], vertices[10], Color.Peru);

            // 8, 6, 7, Треугольник 18
            mech.AddFace(vertices[8], vertices[6], vertices[7], Color.PaleGreen);

            // 9, 8, 1 Треугольник 19
            mech.AddFace(vertices[9], vertices[8], vertices[1], Color.Moccasin);

        }

        public Icosahedron(Transform transform) : this()
        {
            this.transform = transform;
        }

    }
}
