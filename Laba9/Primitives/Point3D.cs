using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blank
{
    class Point3D
    {
        public double x;
        public double y;
        public double z;

        public Point3D(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Point3D()
        {
            this.x = 0;
            this.y = 0;
            this.z = 0;
        }

        public Point2D ToPoint2D()
        {
            return new Point2D((float)this.x, (float)this.y);
        }

        public Point2DV ToPoint2DV()
        {
            return new Point2DV((float)this.x, (float)this.y);
        }
    }
}
