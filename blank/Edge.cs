
using System;
namespace blank
{
    public class Edge
    {
        public Point2D origin;
        public Point2D dest;

        public Edge(Point2D origin, Point2D dest)
        {
            this.origin = origin;
            this.dest = dest;
        }
        public Edge()
        {
            this.origin = new Point2D(0.0f, 0.0f);
            this.dest = new Point2D(1.0f, 0.0f);
        }

        public virtual Edge Rotation(double angle)
        {
            throw new NotImplementedException();
        }
        public virtual Edge Flip()
        {
            throw new NotImplementedException();
        }
        public virtual Point2D Point(double t)
        {
            throw new NotImplementedException();
        }
        public virtual ORIENTATION_EDGE Intersect(Edge e,double t)
        {
            throw new NotImplementedException();
        }
        public virtual ORIENTATION_EDGE Cross(Edge e, double t)
        {
            throw new NotImplementedException();
        }
        public virtual bool IsVertical()
        {
            throw new NotImplementedException();
        }
        public virtual double Slope()
        {
            throw new NotImplementedException();
        }
        public virtual double Y(double x)
        {
            throw new NotImplementedException();
        }

        public enum ORIENTATION_EDGE
        {
            COLLINEAR,          // коллинеарны
            PARALLEL,           // параллельны
            SKEW,               // наклонены
            SKEW_CROSS,         // наклонены и пересекаются
            SKEW_NO_CROSS,      // наклонены и не пересекаются

        }
    }
}
