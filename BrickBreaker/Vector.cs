using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreaker
{
    internal class Vector
    {
        public float xComponent, yComponent, newXComponent, newYComponent;


        public float vectorMagnitude;

        public Vector(int _xComponent, int _yComponent)
        {
            xComponent = _xComponent;
            yComponent = _yComponent;
        }

        public void normalize(float xComponent, float yComponent)
        {
            newXComponent = -yComponent;
            newYComponent = xComponent;
        }

        public void GetMagnitude(float xComponent, float yComponent)
        {
            vectorMagnitude = (float)Math.Sqrt(Math.Pow(xComponent, 2) + Math.Pow(yComponent, 2));
        }
    }
}
