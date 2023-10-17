using System;
using System.Collections.Generic;
using System.Drawing;

namespace blank.Primitives
{
    internal class Point3D
    {
        public float x;
        public float y;
        public float z;

        public Point3D()
        {
            this.x = 0.0f;
            this.y = 0.0f;
            this.z = 0.0f;
        }

        public Point3D(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public static Point3D operator +(Point3D lhs, Point3D rhs)
        {
            return new Point3D(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z);
        }
        public static Point3D operator -(Point3D lhs, Point3D rhs)
        {
            return new Point3D(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z);
        }
        public static float DotProduct(Point3D lhs, Point3D rhs)
        {
            return lhs.x * rhs.x + lhs.y * rhs.y + lhs.z * rhs.z;
        }
        public static Point3D CrossProduct(Point3D a, Point3D b)
        {
            return new Point3D(a.y * b.z - a.z * b.y, a.z * b.x - a.x * b.z, a.x * b.y - a.y * b.x);
        }
        public static Point3D operator *(Point3D lhs, float rhs)
        {
            return new Point3D(lhs.x * rhs, lhs.y * rhs, lhs.z * rhs);
        }
        public static Point3D operator *(float lhs, Point3D rhs)
        {
            return new Point3D(lhs * rhs.x, lhs * rhs.y, lhs * rhs.z);
        }
        public static bool operator <(Point3D lhs, Point3D rhs)
        {
            return (lhs.x < rhs.x) || ((lhs.x == rhs.x) && (lhs.y < rhs.y))
                || ((lhs.x == rhs.x) && (lhs.y == rhs.y) && (lhs.z < rhs.z));
        }
        public static bool operator >(Point3D lhs, Point3D rhs)
        {
            return (lhs.x > rhs.x) || ((lhs.x == rhs.x) && (lhs.y > rhs.y))
                || ((lhs.x == rhs.x) && (lhs.y == rhs.y) && (lhs.z > rhs.z));
        }
        public static bool operator ==(Point3D lhs, Point3D rhs)
        {
            return (lhs.x == rhs.x) && (lhs.y == rhs.y) && (lhs.z == rhs.z);
        }
        public static bool operator !=(Point3D lhs, Point3D rhs)
        {
            return !(lhs == rhs);
        }

        public PointF ToPointF()
        {
            return new PointF(x, y);
        }

        public double Length()
        {
            return Math.Sqrt(x * x + y * y + z * z);
        }

        public override bool Equals(object obj)
        {
            return obj is Point3D d &&
                   x == d.x &&
                   y == d.y &&
                   z == d.z;
        }

        public override int GetHashCode()
        {
            int hashCode = 373119288;
            hashCode = hashCode * -1521134295 + x.GetHashCode();
            hashCode = hashCode * -1521134295 + y.GetHashCode();
            hashCode = hashCode * -1521134295 + z.GetHashCode();
            return hashCode;
        }
    }
}
