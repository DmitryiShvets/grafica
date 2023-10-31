using blank.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blank.Primitives
{
    internal class Transform
    {
        public Vector4 position;
        public Vector4 rotation;
        public Vector4 scale;
        public Vector4 reflection;

        public float line_rotation_angle;
        public Vector4 line_point1;
        public Vector4 line_point2;


        public Transform()
        {
            this.position = new Vector4();
            this.rotation = new Vector4();
            this.scale = new Vector4(1, 1, 1);
            this.reflection = new Vector4(1, 1, 1);

            this.line_point1 = new Vector4();
            this.line_point2 = new Vector4();
            this.line_rotation_angle = 0;
    }

        public Transform(Vector4 position, Vector4 rotation, Vector4 scale, Vector4 reflection)
        {
            this.position = position;
            this.rotation = rotation;
            this.scale = scale;
            this.reflection = reflection;

            this.line_point1 = new Vector4();
            this.line_point2 = new Vector4();
            this.line_rotation_angle = 0;
        }

        //Возвращает model matrix для конкретной модели
        public Matrix3D ApplyTransform(Vector4 point3D)
        {
            Matrix3D result = Matrix3D.FromVector4(point3D);
            Matrix3D scale_matrix = Matrix3D.GetScaleMatrix(scale);
            Matrix3D rotation_matrix = Matrix3D.GetRotationMatrix(rotation);
            Matrix3D transform_matrix = Matrix3D.GetTranslationMatrix(position);
            Matrix3D line_rotation_matrix = Matrix3D.GetLineRotationMatrix(line_point1, line_point2, line_rotation_angle);
            Matrix3D reflection_matrix = Matrix3D.GetReflectionMatrix(reflection);

            result = reflection_matrix*transform_matrix * rotation_matrix * line_rotation_matrix * scale_matrix * result;
     
            return result;
        }

        //Смещение позиции по dx,dy,dz
        public void Translate(Vector4 delta)
        {
            this.position += delta;
        }
        //Поворот угла по осям x,y,z 
        public void Rotate(Vector4 rotation)
        {
            this.rotation += rotation;
            //Console.WriteLine(this.rotation + " ");
        }
        //Увеличение размена на dx,dy,dz
        public void Scale(Vector4 scale)
        {
            this.scale += scale;
        }
        //Отражение относительно координатной плоскости
        public void Reflection(Vector4 reflection)
        {
            this.reflection.x *= reflection.x;
            this.reflection.y *= reflection.y;
            this.reflection.z *= reflection.z;
        }

        public void RotateRelativeLine(Vector4 point1, Vector4 point2, float angle)
        {
            if (point1!=this.line_point1 || point2!=this.line_point2)
            {
                this.line_rotation_angle = 0;
            }
            this.line_point1 = point1;
            this.line_point2 = point2;
            this.line_rotation_angle += angle;
        }
    }
}
