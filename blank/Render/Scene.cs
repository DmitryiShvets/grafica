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
            objects.Add(new Sphere(new Vector4(0, -1, 3), Color.Red, 1));
            objects.Add(new Sphere(new Vector4(2, 0, 4), Color.Blue, 1));
            objects.Add(new Sphere(new Vector4(-2, 0, 4), Color.Green, 1));
            objects.Add(new Box(new Vector4(0, 0, 0), new Vector4(1, 2, 1), new Vector4(0, 0, 5), Color.Yellow));

            light_sources = new List<LightSource>();
            light_sources.Add(new LightSource(LIGHT_TYPE.AMBIENT, 0.2, null));
            light_sources.Add(new LightSource(LIGHT_TYPE.POINT, 0.6, new Vector4(2, 1, 0)));
            light_sources.Add(new LightSource(LIGHT_TYPE.DIRECTIONAL, 0.2, new Vector4(-21, 4, 4)));
        }
    }
}
