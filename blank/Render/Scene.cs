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
        public List<IIntersect> objects;
        public List<LightSource> light_sources;
        public Scene()
        {
            objects = new List<IIntersect>();
            objects.Add(new Sphere(new Vector4(0, 2, 3), Color.White, 0.1, 0.5, 0.2, 0.9));
            objects.Add(new Sphere(new Vector4(0, 1, 3), Color.Red, 0.5, 0.7, 0.2, 0.5));
            objects.Add(new Sphere(new Vector4(1, -2, 7), Color.Blue, 1, 0.5, 0.3, 0));
            objects.Add(new Sphere(new Vector4(-1.5, -2, 4), Color.Green, 0.7, 0.4, 1, 0.25));
            //objects.Add(new Sphere(new Vector4(0, -5001, 0), Color.Yellow, 5000, 1000, 0, 0));
            objects.Add(new Box(new Vector4(0, 0, 0), new Vector4(1, 3, 1), 
                new Vector4(1, -3, 4.5), Color.Yellow, 1, 0.2, 0));
            objects.Add(new Box(new Vector4(0, 0, 0), new Vector4(1, 1, 1),
                new Vector4(-1.5, -2, 4), Color.Orange, 1, 0.2, 0));

            objects.Add(new Plane(new Vector4(0, 0, 1000), new Vector4(0, 0, 1), Color.FromArgb(204,230,255), 5, 0, 0));
            objects.Add(new Plane(new Vector4(400, 0, 0), new Vector4(1, 0, 0), Color.Blue, 5, 0.1, 0));
            objects.Add(new Plane(new Vector4(-400, 0, 0), new Vector4(-1, 0, 0), Color.Red, 5, 0.1, 0));
            objects.Add(new Plane(new Vector4(0, -500, 0), new Vector4(0, -1, 0), Color.FromArgb(204, 230, 255), 5, 0, 0));
            objects.Add(new Plane(new Vector4(0, 500, 0), new Vector4(0, 1, 0), Color.FromArgb(204, 230, 255), 5, 0, 0));

            light_sources = new List<LightSource>();
            light_sources.Add(new LightSource(LIGHT_TYPE.AMBIENT, 0.2, new Vector4(0, 0, 0)));
            light_sources.Add(new LightSource(LIGHT_TYPE.POINT, 0.6, new Vector4(12, 29, -11)));
            light_sources.Add(new LightSource(LIGHT_TYPE.DIRECTIONAL, 0.3, new Vector4(0, 0, -1)));
        }
    }
}
