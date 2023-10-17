using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blank
{
    internal class AffineTransformations
    {
        public static Matrix2D TranslationMatrix(double dx, double dy)
        {
            return new Matrix2D(new double[,]
            {
                { 1, 0, dx },
                { 0, 1, dy },
                { 0, 0, 1 }
            });
        }

        public static Matrix2D RotationMatrix(double angle, Point2D center)
        {
            double cosTheta = Math.Cos(angle);
            double sinTheta = Math.Sin(angle);

            double[,] rotationMatrix = new double[,]
            {
                { cosTheta, -sinTheta, center.x * (1 - cosTheta) + center.y * sinTheta },
                { sinTheta, cosTheta, center.y * (1 - cosTheta) - center.x * sinTheta },
                { 0, 0, 1 }
            };

            return new Matrix2D(rotationMatrix);
        }

        public static Matrix2D ScaleMatrix(double scaleX, double scaleY, Point2D center)
        {
            double[,] scaleMatrix = new double[,]
            {
                { scaleX, 0, center.x * (1 - scaleX) },
                { 0, scaleY, center.y * (1 - scaleY) },
                { 0, 0, 1 }
            };

            return new Matrix2D(scaleMatrix);
        }
    }
}
