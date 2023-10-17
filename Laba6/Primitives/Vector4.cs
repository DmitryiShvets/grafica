using System;
using System.Collections.Generic;
using System.Drawing;

namespace blank.Primitives
{
    internal class Vector4
    {
        public float x;
        public float y;
        public float z;
        public float w;

        public Vector4()
        {
            this.x = 0.0f;
            this.y = 0.0f;
            this.z = 0.0f;
            this.w = 1.0f;
        }

        public Vector4(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = 1.0f;
        }

        public Vector4(float x, float y, float z, float w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        public static Vector4 operator +(Vector4 lhs, Vector4 rhs)
        {
            return new Vector4(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z);
        }
        public static Vector4 operator -(Vector4 lhs, Vector4 rhs)
        {
            return new Vector4(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z);
        }
        public static float DotProduct(Vector4 lhs, Vector4 rhs)
        {
            return lhs.x * rhs.x + lhs.y * rhs.y + lhs.z * rhs.z;
        }
        public static Vector4 CrossProduct(Vector4 a, Vector4 b)
        {
            return new Vector4(a.y * b.z - a.z * b.y, a.z * b.x - a.x * b.z, a.x * b.y - a.y * b.x);
        }
        public static Vector4 operator *(Vector4 lhs, float rhs)
        {
            return new Vector4(lhs.x * rhs, lhs.y * rhs, lhs.z * rhs);
        }
        public static Vector4 operator *(float lhs, Vector4 rhs)
        {
            return new Vector4(lhs * rhs.x, lhs * rhs.y, lhs * rhs.z);
        }
        public static bool operator <(Vector4 lhs, Vector4 rhs)
        {
            return (lhs.x < rhs.x) || ((lhs.x == rhs.x) && (lhs.y < rhs.y))
                || ((lhs.x == rhs.x) && (lhs.y == rhs.y) && (lhs.z < rhs.z));
        }
        public static bool operator >(Vector4 lhs, Vector4 rhs)
        {
            return (lhs.x > rhs.x) || ((lhs.x == rhs.x) && (lhs.y > rhs.y))
                || ((lhs.x == rhs.x) && (lhs.y == rhs.y) && (lhs.z > rhs.z));
        }
        public static bool operator ==(Vector4 lhs, Vector4 rhs)
        {
            return (lhs.x == rhs.x) && (lhs.y == rhs.y) && (lhs.z == rhs.z);
        }
        public static bool operator !=(Vector4 lhs, Vector4 rhs)
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
            return obj is Vector4 d &&
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
