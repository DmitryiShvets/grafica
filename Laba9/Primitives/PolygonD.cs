using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace blank
{
    internal class PolygonD : Polygon
    {
        public enum ORIENTATION_POINT
        {
            INSIDE,
            OUTSIDE,
            BOUNDARY
        }

        public enum ORIENTATION_EDGE
        {
            TOUCHING,
            CROSSING,
            INESSENTIAL
        }

        public PolygonD() : base() { }

        public PolygonD(Vertex2D v) : base(v) { }

        public PolygonD(Polygon p) : base(p) { }

        int EdgeType(Point2D a, Edge e)
        {
            Point2D v = e.origin;
            Point2D w = e.dest;
            switch (a.Classify(e))
            {
                case Point2D.ORIENTATION.LEFT:
                    return (int)(((v.y < a.y) && (a.y <= w.x)) ? ORIENTATION_EDGE.CROSSING : ORIENTATION_EDGE.INESSENTIAL);
                case Point2D.ORIENTATION.RIGHT:
                    return (int)(((w.y < a.y) && (a.y <= v.y)) ? ORIENTATION_EDGE.CROSSING : ORIENTATION_EDGE.INESSENTIAL);
                case Point2D.ORIENTATION.BETWEEN:
                    return (int)ORIENTATION_EDGE.TOUCHING;
                case Point2D.ORIENTATION.ORIGIN:
                    return (int)ORIENTATION_EDGE.TOUCHING;
                case Point2D.ORIENTATION.DESTINITON:
                    return (int)ORIENTATION_EDGE.TOUCHING;
                default:
                    return (int)ORIENTATION_EDGE.INESSENTIAL;
            }
        }

        public bool IsPointInPolygon(Point2D point) // 5) Принадлежит ли точка выпуклому многоугольнику
        {
            Vertex2D start = this.Front;
            PolygonD polygon = this;
            Point2D.ORIENTATION orient = point.Classify(polygon.Edge());
            for (int i = 0; i < polygon.Size; i++, polygon.Advance(Vertex2D.ROTATION.CLOCKWISE))
            {
                if (point.Classify(polygon.Edge()) != orient)
                {
                    polygon.SetV(start);
                    return false;
                }
            }
            return true;
        }
        
        public bool IsPointInPolygon2(Point2D point) // 6) Принадлежит ли точка невыпуклому многоугольнику
        {
            bool res = false;
            PolygonD polygon = this;
            for (int i = 0; i < polygon.Size; i++, polygon.Advance(Vertex2D.ROTATION.CLOCKWISE))
            {
                Edge e = polygon.Edge();
                Point2D minPoint = e.origin;
                Point2D maxPoint = e.dest;
                if (minPoint.y > maxPoint.y) (minPoint, maxPoint) = (maxPoint, minPoint);

                if (maxPoint.y <= point.y || minPoint.y > point.y)
                    continue;

                switch (point.Classify(minPoint, maxPoint))
                {
                    case Point2D.ORIENTATION.BETWEEN:
                        return true;
                    case Point2D.ORIENTATION.LEFT:
                        res = !res;
                        break;
                    default:
                        break;
                }
            }

            return res;
        }

        /*
        bool isPointInsidePolygon3(Point point, Polygon polygon)
        {
            bool res = false;
            for (int i = 0; i < polygon.vertices.length; i++)
            {
                Offset minPoint = polygon.vertices[i];
                Offset maxPoint = polygon.vertices[(i + 1) % polygon.vertices.length];
                if (minPoint.dy > maxPoint.dy) (minPoint, maxPoint) = (maxPoint, minPoint);

                if (maxPoint.dy <= point.position.dy || minPoint.dy > point.position.dy)
                    continue;

                switch (pointRelativeToLineAsOffsets(point.position, minPoint, maxPoint))
                {
                    case RelativePointPosition.collinear:
                        return true;
                    case RelativePointPosition.left:
                        res = !res;
                        break;
                    default:
                }
            }

            return res;
        }
        */
        /*
        public int IsPointInPolygon2(Point2D point) // 6) Принадлежит ли точка невыпуклому многоугольнику
        {
            bool parity = false;
            int count = 0;
            PolygonD polygon = this;
            for (int i = 0; i < polygon.Size; i++, polygon.Advance(Vertex.ROTATION.CLOCKWISE))
            {
                Edge e = polygon.Edge();
                switch ((ORIENTATION_EDGE)EdgeType(point, polygon.Edge()))
                {
                    case ORIENTATION_EDGE.TOUCHING:
                        return (int)ORIENTATION_POINT.BOUNDARY;
                    case ORIENTATION_EDGE.CROSSING:
                        parity = !parity;
                        count++;
                        break;
                }
            }
            Console.WriteLine($"count = {count}");
            return (int)(parity ? ORIENTATION_POINT.INSIDE : ORIENTATION_POINT.OUTSIDE);
        }*/
    }
}
