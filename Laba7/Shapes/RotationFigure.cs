using blank.Primitives;
using blank.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static blank.Utility.Matrix3D;
using System.Drawing;
namespace blank.Shapes
{
    internal class RotationFigure : Object3D
    {
        public Mech forming_mesh;
        public Mech partition_mesh;
        public Mech final_mesh;
        public List<Vector4> editor_points_mesh;
        private int partition_count = 1;
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

        public void BuildPartitionMesh(int count)
        {
            this.partition_count = count;
            if (partition_count > 1) {
                List<Mech> meches  = new List<Mech>();
                for (int i = 0; i < partition_count; i++)
                {

                }

            }
            Triangle3D forming = new Triangle3D(Color.Magenta);
            foreach (var point in editor_points_mesh)
            {
                forming.AddVertex(point);
            }
            base.mech = new Mech(forming);
        }

        public void BuildFormingMesh()
        {
            Triangle3D forming = new Triangle3D(Color.Magenta);
            foreach (var point in editor_points_mesh)
            {
                forming.AddVertex(point);
            }
            base.mech = new Mech(forming);
        }
    }
}
