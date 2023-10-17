using blank.Primitives;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static blank.Utility.Matrix3D;
using static blank.Vertex2D;

namespace blank.Utility
{
    internal class Matrix3D
    {
        public float[,] Values { get; }

        public Matrix3D(float[,] values)
        {
            Values = values;
        }

        public Vector4 ToVector4()
        {
            int rows = Values.GetLength(0);

            if (rows == 4)
            {
                return new Vector4(Values[0, 0], Values[1, 0], Values[2, 0], Values[3, 0]);
            }
            else {
                return new Vector4();
            }
        }

        public static Matrix3D operator +(Matrix3D a, Matrix3D b)
        {
            int rowsA = a.Values.GetLength(0);
            int colsA = a.Values.GetLength(1);
            int rowsB = b.Values.GetLength(0);
            int colsB = b.Values.GetLength(1);

            if (colsA != rowsB)
                throw new ArgumentException("Недопустимые размеры матрицы для умножения");

            float[,] result = new float[rowsA, colsB];

            for (int i = 0; i < rowsA; i++)
            {
                for (int j = 0; j < colsB; j++)
                {
                    float sum = 0.0f;
                    for (int k = 0; k < colsA; k++)
                    {
                        sum += a.Values[i, k] + b.Values[k, j];
                    }
                    result[i, j] = sum;
                }
            }

            return new Matrix3D(result);
        }

        public static Matrix3D operator *(Matrix3D a, Matrix3D b)
        {
            int rowsA = a.Values.GetLength(0);
            int colsA = a.Values.GetLength(1);
            int rowsB = b.Values.GetLength(0);
            int colsB = b.Values.GetLength(1);

            if (colsA != rowsB)
                throw new ArgumentException("Недопустимые размеры матрицы для умножения");

            float[,] result = new float[rowsA, colsB];

            for (int i = 0; i < rowsA; i++)
            {
                for (int j = 0; j < colsB; j++)
                {
                    float sum = 0.0f;
                    for (int k = 0; k < colsA; k++)
                    {
                        sum += a.Values[i, k] * b.Values[k, j];
                    }
                    result[i, j] = sum;
                }
            }

            return new Matrix3D(result);
        }

        public static Matrix3D GetVector4(Vector4 point)
        {
            return new Matrix3D(new float[,] { { point.x }, { point.y }, { point.z }, { 1 } });
        }

        public static Matrix3D GetTranslationMatrix(Vector4 offset)
        {
            return new Matrix3D(new float[,]
            {
                { 1, 0, 0, offset.x },
                { 0, 1, 0, offset.y },
                { 0, 0, 1, offset.z },
                { 0, 0, 0, 1 }
            });
        }

        public static Matrix3D GetRotationMatrix(Vector4 rotation)
        {
            Matrix3D x = GetRotationMatrixAxis(rotation.x, AXIS_TYPE.X);
            Matrix3D y = GetRotationMatrixAxis(rotation.y, AXIS_TYPE.Y);
            Matrix3D z = GetRotationMatrixAxis(rotation.z, AXIS_TYPE.Z);
            return x * y * z;
        }

        private static Matrix3D GetRotationMatrixAxis(float angle, AXIS_TYPE axis)
        {
            float cos_theta = (float)Math.Cos(degreesToRadians(angle));
            float sin_theta = (float)Math.Sin(degreesToRadians(angle));

            switch (axis)
            {
                case AXIS_TYPE.X:
                    {
                        float[,] rotationMatrix = new float[,]
                           {
                                { 1, 0, 0, 0 },
                                { 0, cos_theta, -sin_theta, 0 },
                                { 0, sin_theta, cos_theta, 0 },
                                { 0, 0, 0, 1 }
                           };
                        return new Matrix3D(rotationMatrix);
                    }
                case AXIS_TYPE.Y:
                    {
                        float[,] rotationMatrix = new float[,]
                           {
                                { cos_theta, 0, sin_theta, 0 },
                                { 0, 1, 0, 0 },
                                { -sin_theta, 0, cos_theta, 0 },
                                { 0, 0, 0, 1 }
                           };
                        return new Matrix3D(rotationMatrix);
                    }
                case AXIS_TYPE.Z:
                    {
                        float[,] rotationMatrix = new float[,]
                           {
                                { cos_theta, -sin_theta, 0, 0 },
                                { sin_theta, cos_theta, 0, 0 },
                                { 0, 0, 1, 0 },
                                { 0, 0, 0, 1 }
                           };
                        return new Matrix3D(rotationMatrix);
                    }
                default: return GetIdentityMatrix();
            }
        }

        public static Matrix3D GetScaleMatrix(Vector4 scale)
        {
            float[,] scaleMatrix = new float[,]
            {
                { scale.x, 0, 0, 0 },
                { 0, scale.y, 0, 0 },
                { 0, 0, scale.z, 0 },
                { 0, 0, 0, 1 }
            };

            return new Matrix3D(scaleMatrix);
        }

        public static Matrix3D GetIdentityMatrix()
        {
            float[,] identity_matrix = new float[,]
                           {
                                { 1, 0, 0, 0 },
                                { 0, 1, 0, 0 },
                                { 0, 0, 1, 0 },
                                { 0, 0, 0, 1 }
                           };

            return new Matrix3D(identity_matrix);
        }

        public static float degreesToRadians(double angle)
        {
            return (float)(Math.PI * angle / 180.0);
        }

        public enum AXIS_TYPE
        {
            X, Y, Z
        }
    }
}
