using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3902GameProject.Controllers
{
    public class ThumbstickDirection
    {
        public Vector2 Direction { get; private set; }
        public float Tolerance { get; private set; }

        public ThumbstickDirection(Vector2 direction, float tolerance)
        {
            Direction = direction;
            Tolerance = tolerance;
        }
    }
}
