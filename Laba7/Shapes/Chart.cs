using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using blank.Primitives;
namespace blank.Shapes
{
    internal class Chart : Object3D
    {
        public Chart(List<Triangle3D> triangles) : base()
        {
            foreach (var t in triangles)
            {
                mech.AddFace(t);
            }
        }

        public Chart(Transform transform, List<Triangle3D> triangles) : this(triangles)
        {
            this.transform = transform;
        }
    }
}
