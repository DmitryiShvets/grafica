using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blank.Render
{
    internal class Sphere : Shape
    {
        public int radius;

        public Sphere(int radius)
        {
            this.radius = radius;
        }

        public Sphere(Vector4 pos, Color color, int radius) : base(pos, color)
        {
            this.radius = radius;
        }
    }
}
