using blank.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blank.Primitives
{
    internal class Object3D
    {
        public Mech mech;
        public Transform transform;
        public string obj_name;

        public Object3D()
        {
            mech = new Mech();
            transform = new Transform();
        }

        public Object3D(Transform transform)
        {
            mech = new Mech();
            this.transform = transform;
        }

        public override string ToString()
        {
            return obj_name;
        }
    }
}
