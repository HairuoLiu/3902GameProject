using _3902GameProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using static _3902GameProject.Classes.CollisionHandler;

namespace _3902GameProject.Classes
{
    public class ObjectPhysics : IObjectPhysics
    {
        public float XPosition { get; set; }
        public float YPosition { get; set; }
        public float XVelocity { get; set; }
        public float YVelocity { get; set; }
        public float Gravity { get; set; }
        public float MaxXSpeed { get; set; }
        public float MaxYSpeed { get; set; }

        public ObjectPhysics(float x, float y, float g, float maxX, float maxY)
        {
            XPosition = x;
            YPosition = y;
            XVelocity = 0;
            YVelocity = 0;
            Gravity = g;
            MaxXSpeed = maxX;
            MaxYSpeed = maxY;
        }

        public void Update()
        {
            Move();
            if (Math.Abs(XVelocity) > MaxXSpeed)
                XVelocity = MaxXSpeed * Sign(XVelocity);

            if (Math.Abs(YVelocity) > MaxYSpeed)
                YVelocity = MaxYSpeed * Sign(YVelocity);
            else
                YVelocity += Gravity;
        }

        private void Move()
        {
            XPosition += XVelocity;
            YPosition += YVelocity;
        }

        public void DampenSpeed(float XDamp, float YDamp)
        {
            if (Math.Abs(XVelocity) > XDamp)
                XVelocity -= Sign(XVelocity) * XDamp;
            else
                XVelocity = 0;

            if (Math.Abs(YVelocity) > YDamp)
                YVelocity -= Sign(YVelocity) * YDamp;
            else
                YVelocity = 0;
        }

        private static int Sign(float num)
        {
            if (num == 0)
                return 0;
            else
                return (int)(num / Math.Abs(num));
        }
    }
}
