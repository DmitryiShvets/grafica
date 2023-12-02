using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blank.Render
{
    internal class Vector4
    {
        public double x;
        public double y;
        public double z;

        public Vector4(Vector4 other)
        {
            this.x = other.x;
            this.y = other.y;
            this.z = other.z;
        }

        public Vector4()
        {
            this.x = 0.0f;
            this.y = 0.0f;
            this.z = 0.0f;
        }

        public Vector4(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public static Vector4 Normalize(Vector4 v)
        {
            double len = Length(v);
            return new Vector4(v.x / len, v.y / len, v.z / len);
        }
        public Vector4 Normalize()
        {
            if (Length() == 0) return this;

            return this * (1.0 / Length());
        }
        public static Vector4 operator +(Vector4 lhs, Vector4 rhs)
        {
            return new Vector4(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z);
        }
        public static Vector4 operator -(Vector4 lhs, Vector4 rhs)
        {
            return new Vector4(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z);
        }
        public static Vector4 operator -(Vector4 lhs)
        {
            return new Vector4(-lhs.x, -lhs.y, -lhs.z);
        }
        public static double DotProduct(Vector4 lhs, Vector4 rhs)
        {
            return (lhs.x * rhs.x) + (lhs.y * rhs.y) + (lhs.z * rhs.z);
        }
        public static Vector4 CrossProduct(Vector4 a, Vector4 b)
        {
            return new Vector4(a.y * b.z - a.z * b.y, a.z * b.x - a.x * b.z, a.x * b.y - a.y * b.x);
        }
        public static Vector4 operator *(Vector4 lhs, double rhs)
        {
            return new Vector4(lhs.x * rhs, lhs.y * rhs, lhs.z * rhs);
        }
        public static Vector4 operator *(double lhs, Vector4 rhs)
        {
            return new Vector4(lhs * rhs.x, lhs * rhs.y, lhs * rhs.z);
        }
        public static Vector4 operator /(Vector4 lhs, double rhs)
        {
            return new Vector4(lhs.x / rhs, lhs.y / rhs, lhs.z / rhs);
        }

        public static double Length(Vector4 v)
        {
            return Math.Sqrt(v.x * v.x + v.y * v.y + v.z * v.z);
        }

        private Vector4 Clamp()
        {
            return new Vector4(Math.Min(255, Math.Max(0, (int)x)),
                Math.Min(255, Math.Max(0, (int)y)),
                Math.Min(255, Math.Max(0, (int)z)));
        }

        public Color ToColor()
        {   
            Vector4 v = this.Clamp();
            return Color.FromArgb((int)v.x, (int)v.y, (int)v.z);
        }

        public static Vector4 MixColor(Color color, double h)
        {
            return new Vector4(color.R * h, color.G * h, color.B * h);
        }

        public double Length()
        {
            return Math.Sqrt(x * x + y * y + z * z);
        }
    }
}

