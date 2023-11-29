using System;
using System.Drawing;

namespace blank
{
    class ChartFH
    {
        int width;
        int height;
        float[] lowerH;
        float[] upperH;
        double z1, z2, x1, x2, step;
        double angleX, angleY, angleZ;
        Graphics graphics;
        Bitmap bitmap;
        Point3D center = new Point3D();
        Color backgroundColor = Color.Black;
        static Color chartColor = Color.Blue;
        Pen chartPen = new Pen(chartColor, 1.0f);

        public ChartFH(int _width, int _height, Color _chartColor, Color _backgroundColor)
        {
            width = _width;
            height = _width;
            bitmap = new Bitmap(width, _height);
            lowerH = new float[width];
            upperH = new float[width];
            chartColor = _chartColor;
            backgroundColor = _backgroundColor;
        }

        public void SetParameters(double _x1, double _x2, double _z1, double _z2, double _step, int _angleX, int _angleY, int _angleZ)
        {
            x1 = _x1;
            x2 = _x2;
            z1 = _z1;
            z2 = _z2;
            step = _step;
            SetAngleX(_angleX);
            SetAngleY(_angleY);
            SetAngleZ(_angleZ);
        }

        public void SetAngleX(int angle)
        {
            angleX = Math.PI * angle / 180;
        }
        public void SetAngleY(int angle)
        {
            angleY = Math.PI * angle / 180;
        }
        public void SetAngleZ(int angle)
        {
            angleZ = Math.PI * angle / 180;
        }

        public void Draw(Graphics _graphics, Func<double, double, double> func)
        {
            center.x = (x2 + x1) / 2;
            center.z = (z2 + z1) / 2;
            center.y = func(center.x, center.z);

            graphics = Graphics.FromImage(bitmap);
            graphics.Clear(backgroundColor);

            for (int i = 0; i < width; ++i)
            {
                lowerH[i] = height;
                upperH[i] = 0;
            }

            DrawHelper(func);
            _graphics.DrawImage(bitmap, 0, 0);
        }

        private void DrawHelper(Func<double, double, double> function)
        {
            for (double currentZ = z2; currentZ >= z1; currentZ -= step)
            {
                double y = function(x1, currentZ);
                Point2DV prevPoint = TransformView(x1, y, currentZ).ToPoint2DV();
                prevPoint.isVisible = IsVisibile(prevPoint);
                Point2DV currentPoint;
                for (double currentX = x1; currentX <= x2; currentX += step)
                {
                    y = function(currentX, currentZ);
                    currentPoint = TransformView(currentX, y, currentZ).ToPoint2DV();
                    currentPoint.isVisible = IsVisibile(currentPoint);
                    if (currentPoint.isVisible == prevPoint.isVisible) // VL->VL, VU->VU
                    {
                        if (currentPoint.isVisible == Point2DV.Visibile.VisibleAndLower || currentPoint.isVisible == Point2DV.Visibile.VisibleAndUpper)
                        {
                            graphics.DrawLine(chartPen, prevPoint.ToPointF(), currentPoint.ToPointF());
                            ChangeHorizon(prevPoint, currentPoint);
                        }
                    }
                    else
                    {
                        Point2D intersction;
                        if (currentPoint.isVisible == Point2DV.Visibile.Invisible)
                        {
                            if (prevPoint.isVisible == Point2DV.Visibile.VisibleAndUpper) // VU->I
                            {
                                intersction = GetIntersectionPoint(prevPoint, currentPoint, upperH);
                            }
                            else // VL->I
                            {
                                intersction = GetIntersectionPoint(prevPoint, currentPoint, lowerH);
                            }
                            graphics.DrawLine(chartPen, prevPoint.ToPointF(), intersction.ToPointF());
                            ChangeHorizon(prevPoint, intersction);
                        }
                        else
                        {
                            if (prevPoint.isVisible == Point2DV.Visibile.Invisible) // I->VU
                            {
                                intersction = GetIntersectionPoint(prevPoint, currentPoint, upperH);
                                graphics.DrawLine(chartPen, intersction.ToPointF(), currentPoint.ToPointF());
                                ChangeHorizon(intersction, currentPoint);
                            }
                            else
                            {
                                if (currentPoint.isVisible == Point2DV.Visibile.VisibleAndUpper) // VL->VU
                                {
                                    intersction = GetIntersectionPoint(prevPoint, currentPoint, lowerH);
                                }
                                else // VU->VL
                                {
                                    intersction = GetIntersectionPoint(prevPoint, currentPoint, upperH);
                                }
                                graphics.DrawLine(chartPen, prevPoint.ToPointF(), intersction.ToPointF());
                                ChangeHorizon(prevPoint, intersction);

                                if (currentPoint.isVisible == Point2DV.Visibile.VisibleAndUpper) // VL->VU
                                {
                                    intersction = GetIntersectionPoint(prevPoint, currentPoint, upperH);
                                }
                                else // VU->VL
                                {
                                    intersction = GetIntersectionPoint(prevPoint, currentPoint, lowerH);
                                }
                                graphics.DrawLine(chartPen, intersction.ToPointF(), currentPoint.ToPointF());
                                ChangeHorizon(intersction, currentPoint);
                            }
                        }
                    }
                    prevPoint = currentPoint;
                }
            }
        }

        private Point2D GetIntersectionPoint(Point2D firstPoint, Point2D secondPoint, float[] currentHorizon)
        {
            if (Math.Round(firstPoint.x) == Math.Round(secondPoint.x))
            {
                return new Point2D(secondPoint.x, currentHorizon[(int)Math.Round(secondPoint.x)]);
            }
            if (Math.Round(firstPoint.x) > Math.Round(secondPoint.x))
            {
                (firstPoint, secondPoint) = (secondPoint, firstPoint);
            }

            float lineCoef = (secondPoint.y - firstPoint.y) / (secondPoint.x - firstPoint.x);
            int currentX = (int)Math.Floor(firstPoint.x) + 1;
            float currentY = firstPoint.y + lineCoef;
            int prevSignY = Math.Sign(currentY - currentHorizon[currentX]);
            int currentSignY = prevSignY;

            while (prevSignY == currentSignY && currentX <= Math.Floor(secondPoint.x))
            {
                currentY += lineCoef;
                ++currentX;
                currentSignY = Math.Sign(currentY - currentHorizon[currentX]);
            }

            return new Point2D(currentX, currentY);
        }

        private Point2DV.Visibile IsVisibile(Point2D current)
        {
            if (current.y < upperH[(int)Math.Round(current.x)] && current.y > lowerH[(int)Math.Round(current.x)])
            {
                return Point2DV.Visibile.Invisible;
            }
            else if (current.y >= upperH[(int)Math.Round(current.x)])
            {
                return Point2DV.Visibile.VisibleAndUpper;
            }
            else
            {
                return Point2DV.Visibile.VisibleAndLower;
            }
        }

        private void ChangeHorizon(Point2D first, Point2D second)
        {
            int firstX = (int)Math.Round(first.x);
            int secondX = (int)Math.Round(second.x);
            if (firstX != secondX)
            {
                if (first.x > second.x)
                {
                    (first, second) = (second, first);
                    firstX = (int)Math.Round(first.x);
                    secondX = (int)Math.Round(second.x);
                }

                double angularCoef = (second.y - first.y) / (secondX - firstX);
                double currentY = first.y;
                for (int currentX = firstX; currentX <= secondX; ++currentX)
                {
                    currentY += angularCoef;
                    upperH[currentX] = (float)Math.Max(upperH[currentX], currentY);
                    lowerH[currentX] = (float)Math.Min(lowerH[currentX], currentY);
                }
            }
            else
            {
                int currentX = firstX;
                double maxY = Math.Max(first.y, second.y);
                double minY = Math.Min(first.y, second.y);
                upperH[currentX] = (float)Math.Max(upperH[currentX], maxY);
                lowerH[currentX] = (float)Math.Min(lowerH[currentX], minY);
            }
        }

        private Point3D TransformView(double x, double y, double z)
        {
            double scale = 1.5;
            double scaleRatio = Math.Min(width, height) / (Math.Max(x2 - x1, z2 - z1) * scale);
            x = center.x + (x - center.x) * scaleRatio;
            y = -(center.y + (y - center.y) * scaleRatio);
            z = center.z + (z - center.z) * scaleRatio;

            // y axis
            double temp = z * Math.Cos(angleY) + x * Math.Sin(angleY);
            x = -z * Math.Sin(angleY) + x * Math.Cos(angleY);
            z = temp;

            // x axis
            temp = y * Math.Cos(angleX) + z * Math.Sin(angleX);
            z = -y * Math.Sin(angleX) + z * Math.Cos(angleX);
            y = temp;

            // z axis
            temp = x * Math.Cos(angleZ) + y * Math.Sin(angleZ);
            y = -x * Math.Sin(angleZ) + y * Math.Cos(angleZ);
            x = temp;

            x += width / 2 - center.x;
            y += height / 3 - center.y;

            return new Point3D(x, y, z);
        }

        private Point3D TransformView2(double x, double y, double z)
        {
            double scale = 1.5;
            double scaleRatio = Math.Min(width, height) / (Math.Max(x2 - x1, z2 - z1) * scale);
            x = center.x + (x - center.x) * scaleRatio;
            y = -(center.y + (y - center.y) * scaleRatio);
            z = center.z + (z - center.z) * scaleRatio;

            Primitives.Vector4 vecPosition = new Primitives.Vector4((float)x, (float)y, (float)z);
            Primitives.Vector4 vecRotation = new Primitives.Vector4((float)angleX, (float)angleY, (float)angleZ);
            Primitives.Transform transform = new Primitives.Transform
            {
                position = vecPosition
            };
            transform.Rotate(vecRotation);

            return new Point3D(transform.position.x, transform.position.y, transform.position.z);
        }
    }
}
