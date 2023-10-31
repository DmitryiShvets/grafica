using blank.Primitives;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static blank.Utility.Matrix3D;
using static blank.Vertex2D;
using static System.Windows.Forms.AxHost;

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
            else
            {
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

        public static Matrix3D operator /(Matrix3D a, float b)
        {
            int rowsA = a.Values.GetLength(0);
            int colsA = a.Values.GetLength(1);

            float[,] result = new float[rowsA, colsA];

            for (int i = 0; i < rowsA; i++)
            {
                for (int j = 0; j < colsA; j++)
                {
                    result[i, j] = a.Values[i, j] / b;
                }
            }

            return new Matrix3D(result);
        }

        public static Matrix3D operator *(float a, Matrix3D b)
        {
            int rows = b.Values.GetLength(0);
            int cols = b.Values.GetLength(1);

            float[,] result = new float[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result[i, j] = b.Values[i, j] * a;
                }
            }

            return new Matrix3D(result);
        }

        public static Matrix3D operator *(Matrix3D a, float b)
        {
            int rowsA = a.Values.GetLength(0);
            int colsA = a.Values.GetLength(1);

            float[,] result = new float[rowsA, colsA];

            for (int i = 0; i < rowsA; i++)
            {
                for (int j = 0; j < colsA; j++)
                {
                    result[i, j] = a.Values[i, j] * b;
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
        public Matrix3D ToVector3(PROJECTION_TYPE axis)
        {
            float[,] matrix = new float[3, 1];
            switch (axis)
            {
                case PROJECTION_TYPE.ORTHO_X_PLUS:
                case PROJECTION_TYPE.ORTHO_X_MINUS:
                    {
                        matrix = new float[,]
                        {
                                { Values[2,0] },
                                { Values[1,0] },
                                { Values[3,0] },
                                { 1, }
                        };

                        return new Matrix3D(matrix);
                    }
                case PROJECTION_TYPE.ORTHO_Y_PLUS:
                case PROJECTION_TYPE.ORTHO_Y_MINUS:
                    {
                        matrix = new float[,]
                        {
                                { Values[0,0] },
                                { Values[2,0] },
                                { Values[3,0] },
                                { 1,  }
                        };

                        return new Matrix3D(matrix);
                    }
                case PROJECTION_TYPE.ORTHO_Z_PLUS:
                case PROJECTION_TYPE.ORTHO_Z_MINUS:
                    {
                        matrix = new float[,]
                        {
                                { Values[0,0] },
                                { Values[1,0] },
                                { Values[3,0] },
                                { 1,  }
                        };

                        return new Matrix3D(matrix);
                    }
                case PROJECTION_TYPE.PERSPECTIVE:
                    {
                        matrix = new float[,]
                        {
                                { Values[0,0] },
                                { Values[1,0] },
                                { Values[3,0] },
                                { 1,  }
                        };

                        return new Matrix3D(matrix);
                    }
                default:
                    {
                        matrix = new float[,]
                       {
                                { Values[0,0] },
                                { Values[1,0] },
                                { Values[3,0] },
                                { 1,  }
                       };

                        return new Matrix3D(matrix);
                    }
            }
        }

        public static Matrix3D FromVector4(Vector4 point)
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

        public static Matrix3D GetRotationMatrixAxis(float angle, AXIS_TYPE axis)
        {
            float radians = ToRadians(angle);
            float cos_theta = (float)Math.Cos(radians);
            float sin_theta = (float)Math.Sin(radians);

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

        public static Matrix3D GetReflectionMatrix(Vector4 reflection)
        {
            float[,] reflectionMatrix = new float[,]
                
                {
                            { reflection.x, 0, 0, 0 },
                            { 0, reflection.y, 0, 0 },
                            { 0, 0, reflection.z, 0 },
                            { 0, 0, 0, 1 }
                };
            return new Matrix3D(reflectionMatrix);
        }

        public static Matrix3D GetLineRotationMatrix(Vector4 P1, Vector4 P2, float angle)
        {
            if ((P1 == P2) || (angle==0)) return GetIdentityMatrix();
            Vector4 v = P2 - P1;

            Vector4 center = (P1 + P2) * 0.5f; // Находим центр прямой
            Matrix3D translateToOrigin = GetTranslationMatrix(new Vector4(-center.x, -center.y, -center.z));

            v = v.Normalize();

            float theta = ToRadians(angle);

            float c = (float)Math.Cos(theta);
            float s = (float)Math.Sin(theta);
            float t = 1 - c;

            float x = v.x;
            float y = v.y;
            float z = v.z;

            float tx = t * x;
            float ty = t * y;
            float tz = t * z;

            float sx = s * x;
            float sy = s * y;
            float sz = s * z;

            float txy = tx * y;
            float tyz = ty * z;
            float txz = tx * z;

            float m11 = tx * x + c;
            float m12 = txy - sz;
            float m13 = txz + sy;
            float m21 = txy + sz;
            float m22 = ty * y + c;
            float m23 = tyz - sx;
            float m31 = txz - sy;
            float m32 = tyz + sx;
            float m33 = tz * z + c;

            var rotationMatrix = new float[,] {
                { m11, m12, m13, 0 },
                { m21, m22, m23, 0 },
                { m31, m32, m33, 0 },
                { 0, 0, 0, 1}
            };

            // Возвращаем систему координат в исходное положение
            Matrix3D translateBack = GetTranslationMatrix(new Vector4(center.x, center.y, center.z));

            // Комбинируем матрицы в правильном порядке
            Matrix3D finalMatrix = translateBack * new Matrix3D(rotationMatrix) * translateToOrigin;

            return finalMatrix;
        }

        public static Matrix3D GetOrtho(PROJECTION_TYPE axis)
        {
            float[,] ortho_matrix;

            switch (axis)
            {
                case PROJECTION_TYPE.ORTHO_X_PLUS:
                    {
                        ortho_matrix = new float[,]
                        {
                                { 0, 0, 0, 0 },
                                { 0, 1, 0, 0 },
                                { 0, 0, 1, 0 },
                                { 0, 0, 1, 1 }
                        };

                        return new Matrix3D(ortho_matrix);
                    }
                case PROJECTION_TYPE.ORTHO_X_MINUS:
                    {
                        ortho_matrix = new float[,]
                        {
                                { 0, 0, 0, 0 },
                                { 0, 1, 0, 0 },
                                { 0, 0, -1, 0 },
                                { 0, 0, 1, 1 }
                        };

                        return new Matrix3D(ortho_matrix);
                    }
                case PROJECTION_TYPE.ORTHO_Y_PLUS:
                    {
                        ortho_matrix = new float[,]
                        {
                                { 1, 0, 0, 0 },
                                { 0, 0, 0, 0 },
                                { 0, 0, -1, 0 },
                                { 0, 0, 1, 1 }
                        };

                        return new Matrix3D(ortho_matrix);
                    }
                case PROJECTION_TYPE.ORTHO_Y_MINUS:
                    {
                        ortho_matrix = new float[,]
                        {
                                { -1, 0, 0, 0 },
                                { 0, 0, 0, 0 },
                                { 0, 0, -1, 0 },
                                { 0, 0, 1, 1 }
                        };

                        return new Matrix3D(ortho_matrix);
                    }
                case PROJECTION_TYPE.ORTHO_Z_PLUS:
                    {
                        ortho_matrix = new float[,]
                        {
                                { 1, 0, 0, 0 },
                                { 0, 1, 0, 0 },
                                { 0, 0, 0, 0 },
                                { 0, 0, 1, 1 }
                        };

                        return new Matrix3D(ortho_matrix);
                    }
                case PROJECTION_TYPE.ORTHO_Z_MINUS:
                    {
                        ortho_matrix = new float[,]
                        {
                                { -1, 0, 0, 0 },
                                { 0, 1, 0, 0 },
                                { 0, 0, 0, 0 },
                                { 0, 0, 1, 1 }
                        };

                        return new Matrix3D(ortho_matrix);
                    }
                default:
                    {
                        ortho_matrix = new float[,]
                        {
                                { 1, 0, 0, 0 },
                                { 0, 1, 0, 0 },
                                { 0, 0, 0, 0 },
                                { 0, 0, 1, 1 }
                        };

                        return new Matrix3D(ortho_matrix);
                    }
            }
           
        }

        public static Matrix3D GetProjectionMatrix1()
        {
            float V = (float)Math.Abs(1.0 / 500);

            float[,] projection_matrix = new float[,]
         {
                { 1, 0, 0, 0 },
                { 0, 1, 0, 0 },
                { 0, 0, 1, V },
                { 0, 0, 0, 1 }
         };
            return new Matrix3D(projection_matrix);
        }

        public static Matrix3D GetProjectionMatrix(float fovy, float aspect, float n, float f)
        {
            float radians_fov = ToRadians(fovy);
            float ctg_fov = (float)(1.0 / Math.Tan(radians_fov / 2));
            float a = ctg_fov / aspect;
            float b = ctg_fov;
            float c = f + n / f - n;
            float d = (-2 * f * n) / (f - n);

            float[,] projection_matrix = new float[,]
         {
                { a, 0, 0, 0 },
                { 0, b, 0, 0 },
                { 0, 0, c, 1 },
                { 0, 0, d, 0 }
         };
            return new Matrix3D(projection_matrix);
        }

        public static Matrix3D LookAt(Vector4 position, Vector4 target, Vector4 world_up)
        {
            Vector4 x_axis, y_axis, z_axis;
            z_axis = Vector4.Normalize(position - target);
            x_axis = Vector4.Normalize(Vector4.CrossProduct(Vector4.Normalize(world_up), z_axis));
            y_axis = Vector4.CrossProduct(z_axis, x_axis);

            Matrix3D translation = GetIdentityMatrix();
            translation[3, 0] = -position.x;
            translation[3, 1] = -position.y;
            translation[3, 2] = -position.z;

            Matrix3D rotation = GetIdentityMatrix();
            rotation[0, 0] = x_axis.x; // First column, first row
            rotation[1, 0] = x_axis.y;
            rotation[2, 0] = x_axis.z;
            rotation[0, 1] = y_axis.x; // First column, second row
            rotation[1, 1] = y_axis.y;
            rotation[2, 1] = y_axis.z;
            rotation[0, 2] = z_axis.x; // First column, third row
            rotation[1, 2] = z_axis.y;
            rotation[2, 2] = z_axis.z;

            return rotation * translation;
        }

        public static Matrix3D LookAt1(Vector4 Eye, Vector4 Center, Vector4 Up)
        {
            Vector4 X, Y, Z;
            Z = Eye - Center;
            Z.Normalize();
            Y = Up;
            X = Vector4.CrossProduct(Y, Z);
            Y = Vector4.CrossProduct(Z, X);
            X.Normalize();
            Y.Normalize();

            float x_dot = Vector4.DotProduct(X, Eye);
            float y_dot = Vector4.DotProduct(Y, Eye);
            float z_dot = Vector4.DotProduct(Z, Eye);

            float[,] look_matrix = new float[,]
           {
                { X.x, Y.x, Z.x, 0 },
                { X.y, Y.y, Z.y, 0 },
                { X.z, Y.z, Z.z, 0 },
                { -x_dot, -y_dot, -z_dot, 1 }
           };
            return new Matrix3D(look_matrix);

        }

        public static Matrix3D GetViewPortMatrix(int zoom_x, int zoom_y, int x_center, int y_center)
        {
            float[,] identity_matrix = new float[,]
                          {
                                { zoom_x, 0, 0, x_center },
                                { 0, zoom_y, 0, y_center },
                                { 0, 0, 1, 0 },
                                { 0, 0, 0, 1 }
                          };

            return new Matrix3D(identity_matrix);
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

        public static float ToRadians(double angle)
        {
            return (float)(Math.PI * angle / 180.0);
        }

        public override string ToString()
        {
            int rows = Values.GetLength(0);
            int cols = Values.GetLength(1);
            StringBuilder sb = new StringBuilder();

            if (cols == 1)
            {
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        sb.Append(Values[i, j] + " ");
                    }
                }
                sb.Append('\n');
            }
            else
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    sb.Append(Values[i, j] + " ");
                }
                sb.Append('\n');
            }
            return sb.ToString();
        }

        public float this[int i, int j]
        {
            get { return Values[i, j]; }
            set { Values[i, j] = value; }
        }

        public enum AXIS_TYPE
        {
            X, Y, Z
        }
        public enum PROJECTION_TYPE
        {
            ORTHO_X_PLUS,
            ORTHO_Y_PLUS,
            ORTHO_Z_PLUS,
            ORTHO_X_MINUS,
            ORTHO_Y_MINUS,
            ORTHO_Z_MINUS,
            PERSPECTIVE,
        }
    }
}
