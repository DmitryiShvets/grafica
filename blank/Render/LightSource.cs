using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blank.Render
{
    enum LIGHT_TYPE
    {
        AMBIENT,
        POINT,
        DIRECTIONAL
    }
    internal class LightSource
    {
        public LIGHT_TYPE type;
        public double intensity;
        public Vector4 position;

        public LightSource(LIGHT_TYPE type, double intensity, Vector4 position)
        {
            this.type = type;
            this.intensity = intensity;
            this.position = position;
        }
    }
}
