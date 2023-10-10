using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba5
{
    public class VectorD
    {
        public float X { get; set; }
        public float Y { get; set; }

        public VectorD(float x, float y)
        {
            X = x;
            Y = y;
        }
        public static VectorD Zero => new VectorD(0, 0);
        public static VectorD operator +(VectorD a, VectorD b)
        {
            return new VectorD(a.X + b.X, a.Y + b.Y);
        }
        public static VectorD operator *(float scalar, VectorD vector)
        {
            return new VectorD(scalar * vector.X, scalar * vector.Y);
        }
    }
}
