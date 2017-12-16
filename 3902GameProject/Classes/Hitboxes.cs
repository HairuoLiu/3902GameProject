using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _3902GameProject.Classes
{
    public static class Hitboxes
    {
        public static Rectangle SmallMarioHitbox()
        {
            return new Rectangle(2, -16, 12, 16);
        }

        public static Rectangle TallUprightMarioHitbox()
        {
            return new Rectangle(2, -32, 12, 32);
        }

        public static Rectangle TallCrouchingMarioHitbox()
        {
            return new Rectangle(2, -16, 12, 16);
        }

        public static Rectangle WalkingGoombaHitbox()
        {
            return new Rectangle(2, -13, 12, 13);
        }

        public static Rectangle DeadGoombaHitbox()
        {
            return new Rectangle(2, -8, 12, 8);
        }

        public static Rectangle WalkingKoopaHitbox()
        {
            return new Rectangle(1, -15, 10, 15);
        }

        public static Rectangle KoopaShellHitbox()
        {
            return new Rectangle(2, -13, 12, 13);
        }

        public static Rectangle BlockHitbox()
        {
            return new Rectangle(0, -16, 16, 16);
        }

        public static Rectangle RightStandingMarthHitbox()
        {
            return new Rectangle(2, -33, 13, 33);
        }

        public static Rectangle RightWalkingMarthHitbox()
        {
            return new Rectangle(2, -33, 13, 33);
        }

        public static Rectangle LeftStandingMarthHitbox()
        {
            return new Rectangle(2, -33, 13, 33);
        }

        public static Rectangle LeftWalkingMarthHitbox()
        {
            return new Rectangle(2, -33, 13, 33);
        }

        public static Rectangle RightCrouchingMarthHitbox()
        {
            return new Rectangle(0, -17, 22, 17);
        }

        public static Rectangle LeftCrouchingMarthHitbox()
        {
            return new Rectangle(-5, -17, 22, 17);
        }

        public static Rectangle RightFallingMarthHitbox()
        {
            return new Rectangle(2, -33, 13, 33);
        }

        public static Rectangle RightJumpingMarthHitbox()
        {
            return new Rectangle(0, -34, 13, 34);
        }

        public static Rectangle LeftJumpingMarthHitbox()
        {
            return new Rectangle(2, -34, 13, 34);
        }

        public static Rectangle LeftFallingMarthHitbox()
        {
            return new Rectangle(2, -33, 13, 33);
        }

        public static Rectangle RightSwingingMarthHitbox()
        {
            return new Rectangle(2, -33, 13, 33);
        }

        public static Rectangle LeftSwingingMarthHitbox()
        {
            return new Rectangle(2, -33, 13, 33);
        }
    }
}
