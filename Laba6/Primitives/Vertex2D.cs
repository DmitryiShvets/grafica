
using System.Drawing;

namespace blank
{
    public class Vertex2D : Point2D
    {
        protected Vertex2D _next;
        protected Vertex2D _prev;

        public Vertex2D() : base()
        {
            _next = this;
            _prev = this;
        }
        public Vertex2D(float x, float y) : base(x, y)
        {
            _next = this;
            _prev = this;
        }
        public Vertex2D(Point2D p) : base(p.x, p.y)
        {
            _next = this;
            _prev = this;
        }

        public Vertex2D Next
        {
            get { return _next; }
        }
        public Vertex2D Prev
        {
            get { return _prev; }
        }
        public Point2D Point
        {
            get { return this; }
        }

        public Vertex2D Neighbor(ROTATION r)
        {
            return r == ROTATION.CLOCKWISE ? Next : Prev;
        }
        public Vertex2D Insert(Vertex2D v)
        {
            Vertex2D tmp = _next;
            v._next = tmp;
            v._prev = this;
            this._next = v;
            tmp._prev = v;
            return v;
        }
        public Vertex2D Remove()
        {
            _prev._next = _next;
            _next._prev = _prev;
            _next = _prev = this;
            return this;
        }
        public void Splise(Vertex2D b)
        {
            Vertex2D a = this;
            Vertex2D an = a._next;
            Vertex2D bn = b._next;
            a._next = bn;
            b._next = an;
            an._prev = b;
            bn._prev = a;
        }
        public Vertex2D Split(Vertex2D v)
        {
            Vertex2D vp = v._prev.Insert(new Vertex2D(v.Point));
            Insert(new Vertex2D(Point));

            Splise(vp);
            return vp;
        }
        public enum ROTATION
        {
            CLOCKWISE,
            COUNTER_CLOCKWISE
        }
    }
}
