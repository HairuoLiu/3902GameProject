using _3902GameProject.Classes.UtilityClasses;
using _3902GameProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace _3902GameProject.Classes
{
    public class DarkBrickBit : GenericBlock
    {
        private float yVelocity;
        private float gravity = SceneUtilityConsts.Gravity;
        private float xVelocity;
        private int timer = 0;
        public DarkBrickBit(float x, float y, Texture2D spritesheet, float xVel, float yVel, Func<int, int, IItem> func) : base(spritesheet, func)
        {
            IsVisible = true;
            XPosition = x;
            YPosition = y;
            yVelocity = yVel;
            xVelocity = xVel;
            SpriteByFrame.Add(0, SceneUtilityConsts.DarkBrickBitRectangle);
            FrameDelay = 1;
            TotalFrames = 1;
            Depth = 1;
        }

        public override Rectangle BoundingRectangle()
        {
            return SceneUtilityConsts.Empty;
        }

        public override void PunchFromBelow(IPlayer player)
        {
        }

        public override void Update()
        {
            timer++;
            if (timer > SceneUtilityConsts.RemoveTimerTotal)
            {
                ILevel level = Game1.GameInstance.GameLevel;
                level.RemoveObject(this, true);
            }
            YPosition += yVelocity;
            XPosition += xVelocity;
            yVelocity += gravity;
            base.Update();
        }
    }
}
