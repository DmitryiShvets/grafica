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
        Vector4 GetNormal(Vector4 p);
    }

    internal class Shape
    {
        public Vector4 position;
        public Color color;
        public Double Infinity = Double.MaxValue;
        public double specular;
        public double reflective;
        public double transparency;
        public bool visible = true;
        public Shape(Vector4 position, Color color, double specular, double reflective, double transparency)
        {
            this.position = position;
            this.color = color;
            this.specular = specular;
            this.reflective = reflective;
            this.transparency = transparency;
        }

        public Shape()
        {
            this.position = new Vector4(0,0,3);
            this.color = Color.Black;
            this.specular = 0;
            this.reflective = 0;
            this.transparency = 0;
        }
    }
}
