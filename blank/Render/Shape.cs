using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blank.Render
{
    internal class Shape
    {
        public Vector4 position;
        public Color color;

        public Shape(Vector4 position, Color color)
        {
            this.position = position;
            this.color = color;
        }

        public Shape()
        {
            this.position = new Vector4();
            this.color = Color.Red;
        }
    }
}
