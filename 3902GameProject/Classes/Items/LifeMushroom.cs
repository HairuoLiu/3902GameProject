using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3902GameProject.Classes
{
    public class LifeMushroom : GenericItem
    {
        private static readonly int SmallSprite = 16;
        private static readonly int XPos = 214;
        private static readonly int YPos = 34;
        private static readonly float InitYVel = 1.7f;
        private static readonly int InitXVel = 1;
        public LifeMushroom(float x, float y, Texture2D spritesheet) : base(spritesheet)
        {
            ItemInfo.XPosition = x;
            ItemInfo.YPosition = y;
            SpriteByFrame.Add(0, new Rectangle(XPos, YPos, SmallSprite, SmallSprite));
            FrameDelay = 1;
            TotalFrames = 1;
            ItemInfo.XVelocity = InitXVel;
            ItemInfo.YVelocity = InitYVel;
        }
    }
}

