using blank.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blank.Shapes
{
    internal class RotationFigure : Object3D
    {
        public RotationFigure() : base()
        { 
        }

        public RotationFigure(Transform transform) : this()
        {
            this.transform = transform;
        }
    }
}
