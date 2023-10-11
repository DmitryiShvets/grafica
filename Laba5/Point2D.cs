using System;

namespace Laba5
{
    public class Point2D : IComparable<Point2D>, IEquatable<Point2D>
    {

        public int x;
        public int y;

        public Point2D(int x, int y)
        {

            this.x = x;
            this.y = y;
        }

        public int CompareTo(Point2D other)
        {
            if (other == null) return 1;
            if (this.y < other.y) return -1;
            else if (this.y == other.y && this.x < other.x) return -1;
            else if (this.y == other.y && this.x > other.x) return 1;
            else return 1;
        }

        public bool Equals(Point2D other)
        {
            return this.x == other.x && this.y == other.y;
        }
    }

}
