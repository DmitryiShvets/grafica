using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blank.Render
{
    internal class Scene
    {
        public List<Shape> objects;

        public Scene()
        {
            objects = new List<Shape>();
            objects.Add(new Sphere(new Vector4(0, -1, 3), Color.Red, 1));
            objects.Add(new Sphere(new Vector4(2, 0, 4), Color.Green, 1));
            objects.Add(new Sphere(new Vector4(-2, 0, 4), Color.Blue, 1));
        }
    }
}
