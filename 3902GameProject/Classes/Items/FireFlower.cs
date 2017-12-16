using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3902GameProject.Classes
{
    public class FireFlower : GenericItem
    {
        private static readonly int SmallSprite = 16;
        private static readonly int XPos = 4;
        private static readonly int XGap = 30;
        private static readonly int YPos = 64;
        private static readonly int FDelay = 8;
        private static readonly int FrameCount = 4;
        public FireFlower(float x, float y, Texture2D spritesheet) : base(spritesheet)
        {
            ItemInfo.XPosition = x;
            ItemInfo.YPosition = y;
            SpriteByFrame.Add(0, new Rectangle(XPos, YPos, SmallSprite, SmallSprite));
            SpriteByFrame.Add(1, new Rectangle(XPos + XGap, YPos, SmallSprite, SmallSprite));
            SpriteByFrame.Add(2, new Rectangle(XPos + (2*XGap), YPos, SmallSprite, SmallSprite));
            SpriteByFrame.Add(3, new Rectangle(XPos + (3*XGap), YPos, SmallSprite, SmallSprite));
            FrameDelay = FDelay;
            TotalFrames = FrameCount;
            ItemInfo.XVelocity = 0;
            ItemInfo.YVelocity = 0;
        }
    }
}
