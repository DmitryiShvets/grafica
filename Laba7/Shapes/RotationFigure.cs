using blank.Primitives;
using blank.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static blank.Utility.Matrix3D;

namespace blank.Shapes
{
    internal class RotationFigure : Object3D
    {
        private Mech forming_mesh;
        private Mech partition_mesh;
        private Mech final_mesh;
        public List<Vector4> editor_points_mesh;

        public AXIS_TYPE rotation_axis = AXIS_TYPE.Y;

        public RotationFigure() : base()
        { 
            forming_mesh = new Mech();
            partition_mesh = new Mech();
            final_mesh = new Mech();
            editor_points_mesh = new List<Vector4>();

        }

        public RotationFigure(Transform transform) : this()
        {
            this.transform = transform;
        }
    }
}
