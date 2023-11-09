using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blank
{
    internal class Matrix2D
    {
        public double[,] Values { get; }

        public Matrix2D(double[,] values)
        {
            Values = values;
        }

        public static Matrix2D Multiply(Matrix2D a, Matrix2D b)
        {
            int rowsA = a.Values.GetLength(0);
            int colsA = a.Values.GetLength(1);
            int rowsB = b.Values.GetLength(0);
            int colsB = b.Values.GetLength(1);

            if (colsA != rowsB)
                throw new ArgumentException("Недопустимые размеры матрицы для умножения");

            double[,] result = new double[rowsA, colsB];

            for (int i = 0; i < rowsA; i++)
            {
                for (int j = 0; j < colsB; j++)
                {
                    double sum = 0.0;
                    for (int k = 0; k < colsA; k++)
                    {
                        sum += a.Values[i, k] * b.Values[k, j];
                    }
                    result[i, j] = sum;
                }
            }

            return new Matrix2D(result);
        }
    }
}