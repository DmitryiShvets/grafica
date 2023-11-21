using blank.Primitives;
using blank.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static blank.Utility.Matrix3D;
using System.Drawing;
using System.Reflection;

namespace blank.Shapes
{
    internal class RotationFigure : Object3D
    {
        public Mech forming_mesh;
        public Mech partition_mesh;
        public Mech final_mesh;
        public List<Vector4> editor_points_mesh_x;
        public List<Vector4> editor_points_mesh_y;
        public List<Vector4> editor_points_mesh_z;
        private int partition_count = 1;
        public AXIS_TYPE rotation_axis = AXIS_TYPE.Y;
        private int active_mesh = 0;

        public int PointCount { get => editor_points_mesh_x.Count; }
 
        public RotationFigure() : base()
        {
            forming_mesh = new Mech();
            partition_mesh = new Mech();
            final_mesh = new Mech();
            editor_points_mesh_x = new List<Vector4>();
            editor_points_mesh_y = new List<Vector4>();
            editor_points_mesh_z = new List<Vector4>();

        }

        public RotationFigure(Transform transform, int divisions, int active_mesh ,AXIS_TYPE axis) : this()
        {
            this.active_mesh = active_mesh;
            this.rotation_axis = axis;
            this.partition_count = divisions;
            this.transform = transform;
        }

        public void SetIndexActiveMesh(int index)
        {
            active_mesh = index;
            SetMesh();
        }

        public void SetDivisionsCount(int divisions)
        {
            partition_count = divisions;
        }

        private void SetMesh()
        {
            switch (active_mesh)
            {
                case 0:
                    mech = forming_mesh;
                    break;
                case 1:
                    mech = partition_mesh;
                    break;
                case 2:
                    mech = final_mesh;
                    break;
                default:
                    mech = forming_mesh;
                    break;
            }
        }

        public void Build()
        {
            BuildFormingMesh();
            BuildPartitionMesh();
            BuidFinalMesh();
            SetMesh();
        }

        private void BuidFinalMesh()
        {
            this.final_mesh = new Mech();
            if (partition_count > 2)
            {
                for (int i = 1; i < partition_count; i++)
                {
                    for (int j = 1; j < partition_mesh.faces[i].Size; j++)
                    {
                        Vector4 a1 = partition_mesh.faces[i - 1][j - 1];
                        Vector4 b1 = partition_mesh.faces[i][j - 1];

                        Vector4 a2 = partition_mesh.faces[i - 1][j];
                        Vector4 b2 = partition_mesh.faces[i][j];

                        final_mesh.AddFace(a1, b1, b2, Color.Orange);
                        final_mesh.AddFace(a1, a2, b2, Color.Orange);

                    }
                }
                int k = partition_count - 1;
                for (int j = 1; j < partition_mesh.faces[0].Size; j++)
                {
                    Vector4 a1 = partition_mesh.faces[0][j - 1];
                    Vector4 b1 = partition_mesh.faces[k][j - 1];

                    Vector4 a2 = partition_mesh.faces[0][j];
                    Vector4 b2 = partition_mesh.faces[k][j];

                    final_mesh.AddFace(a1, b1, b2, Color.Orange);
                    final_mesh.AddFace(a1, a2, b2, Color.Orange);

                }
            }
        }

        private void BuildPartitionMesh()
        {
            this.partition_mesh = new Mech();
            float angle = 360.0f / partition_count;

            for (int i = 0; i < partition_count; i++)
            {
                Transform cur_transform = new Transform();

                switch (rotation_axis)
                {
                    case AXIS_TYPE.X:
                        cur_transform.Rotate(new Vector4(i * angle, 0, 0));
                        break;
                    case AXIS_TYPE.Y:
                        cur_transform.Rotate(new Vector4(0, i * angle, 0));
                        break;
                    case AXIS_TYPE.Z:
                        cur_transform.Rotate(new Vector4(0, 0, i * angle));
                        break;
                }
                Triangle3D new_face = new Triangle3D(Color.Black);
                for (int j = 0; j < forming_mesh.faces[0].Size; j++)
                {
                    Matrix3D model = cur_transform.ApplyTransform(forming_mesh.faces[0][j]);
                    new_face.AddVertex(model.ToVector4());
                }
                partition_mesh.AddFace(new_face);
            }
        }

        private void BuildFormingMesh()
        {
            Triangle3D forming = new Triangle3D(Color.Magenta);
            List<Vector4> editor_points_mesh = new List<Vector4>();
            switch (rotation_axis)
            {
                case AXIS_TYPE.X:
                    editor_points_mesh = editor_points_mesh_x;
                    break;
                case AXIS_TYPE.Y:
                    editor_points_mesh = editor_points_mesh_y;
                    break;
                case AXIS_TYPE.Z:
                    editor_points_mesh = editor_points_mesh_z;
                    break;
            }

            foreach (var point in editor_points_mesh)
            {
                forming.AddVertex(point);
            }
            this.forming_mesh = new Mech(forming);
        }
    }
}
