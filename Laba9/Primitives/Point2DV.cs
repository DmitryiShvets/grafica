using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blank
{
    class Point2DV : Point2D
    {
        public Visibile isVisible { get; set; }

        public Point2DV() : base() { }
        public Point2DV(float x, float y) : base(x, y) { }

        public Point2DV(float x, float y, Visibile _isVisible) : base(x, y) {
            isVisible = _isVisible;
        }
        public enum Visibile
        {
            VisibleAndUpper,
            VisibleAndLower,
            Invisible
        }
    }
}
