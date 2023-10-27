
using System.Security.Cryptography;
using static blank.Vertex2D;

namespace blank
{
    public class Polygon
    {
        private Vertex2D _v;
        private int _size;
        private void Resize()
        {
            if (_v == null) _size = 0;
            else
            {
                Vertex2D v = _v.Next;
                for (_size = 1; v != _v; v = v.Next, _size++) ;
            }
        }

        public Polygon()
        {
            _v = null;
            _size = 0;
        }
        public Polygon(Vertex2D v)
        {
            _v = v;
            Resize();
        }
        public Polygon(Polygon p)
        {
            _size = p._size;
            if (_size == 0) _v = null;
            else
            {
                _v = new Vertex2D(p.Point);
                for (int i = 1; i < _size; i++)
                {
                    p.Advance(ROTATION.CLOCKWISE);
                    _v = _v.Insert(new Vertex2D(p.Point));
                }
            }
            p.Advance(ROTATION.CLOCKWISE);
            _v = _v.Next;
        }

        public Point2D Point
        {
            get { return _v.Point; }
        }
        public int Size
        {
            get { return _size; }
        }
        public Vertex2D Front
        {
            get { return _v; }
        }
        public Edge Edge()
        {
            return new Edge(Point, _v.Next.Point);
        }

        public Vertex2D Next
        {
            get { return _v.Next; }
        }
        public Vertex2D Prev
        {
            get { return _v.Next; }
        }
        public Vertex2D Neighbor(ROTATION r)
        {
            return _v.Neighbor(r);
        }

        public Vertex2D Advance(ROTATION r)
        {
            _v = _v.Neighbor(r);
            return _v;
        }
        public Vertex2D SetV(Vertex2D v)
        {
            _v = v;
            return _v;
        }
        public Vertex2D Insert(Point2D p)
        {
            if (_size++ == 0) _v = new Vertex2D(p);
            else _v = _v.Insert(new Vertex2D(p));
            return _v;
        }
        public void Remove()
        {
            _v = (--_size == 0) ? null : _v.Prev;
        }
        public Polygon Split(Vertex2D v)
        {
            Vertex2D vp = _v.Split(v);
            Resize();
            return new Polygon(vp);
        }
        public Polygon RotateEdge()
        {
            if (_size >= 2)
            {
                var edited_edge = Edge().Rotation90();
                Point.x = edited_edge.origin.x;
                Point.y = edited_edge.origin.y;
                Next.Point.x = edited_edge.dest.x;
                Next.Point.y = edited_edge.dest.y;
            }
            return this;
        }
    }
}
