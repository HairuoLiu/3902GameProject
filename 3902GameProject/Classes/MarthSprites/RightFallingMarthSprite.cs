﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3902GameProject.Classes.MarioSprites
{
    public class RightFallingMarthSprite : GenericMarthSprite
    {
        public RightFallingMarthSprite(Texture2D spritesheet) : base(spritesheet)
        {
            DrawWidth = 20;
            DrawHeight = 45;
            SpriteByFrame.Add(0, new Rectangle(1, 63, DrawWidth, DrawHeight));
            FrameDelay = 1;
            TotalFrames = 1;
        }

        public override void Draw(float x, float y, SpriteBatch spriteBatch, Color tint)
        {
            base.Draw(x - 4, y - DrawHeight, spriteBatch, tint);
        }
    }
}