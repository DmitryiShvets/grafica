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


        public Transform()
        {
            this.position = new Vector4();
            this.rotation = new Vector4();
            this.scale = new Vector4(1, 1, 1);
        }

        public Transform(Vector4 position, Vector4 rotation, Vector4 scale)
        {
            this.position = position;
            this.rotation = rotation;
            this.scale = scale;
        }

        //Возвращает model matrix для конкретной модели
        public Matrix3D ApplyTransform(Vector4 point3D)
        {
            Matrix3D result = Matrix3D.FromVector4(point3D);
            Matrix3D scale_matrix = Matrix3D.GetScaleMatrix(scale);
            Matrix3D rotation_matrix = Matrix3D.GetRotationMatrix(rotation);
            Matrix3D transform_matrix = Matrix3D.GetTranslationMatrix(position);

            result = transform_matrix * rotation_matrix * scale_matrix * result;
     
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
        }
        //Увеличение размена на dx,dy,dz
        public void Scale(Vector4 scale)
        {
            this.scale += scale;
        }

    }
}
