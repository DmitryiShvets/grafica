using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blank.Render
{
    internal interface IIntersect
    {
        (double, double) Intersect(Vector4 origin, Vector4 direction);
    }

    internal class Shape 
    {
        public Vector4 position;
        public Color color;
        public Double Infinity = Double.MaxValue;

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
