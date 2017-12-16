using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3902GameProject.Classes.MarioSprites
{
    class RightIdleFireMarioSprite : GenericTallMarioSprite
    {
        public RightIdleFireMarioSprite(Texture2D spritesheet) : base(spritesheet)
        {
            SpriteByFrame.Add(0, new Rectangle(UtilityClasses.SpriteUtilityConsts.BIRMXPos1, UtilityClasses.SpriteUtilityConsts.FYpos, UtilityClasses.SpriteUtilityConsts.SmallSprite, UtilityClasses.SpriteUtilityConsts.BigSprite));
            FrameDelay = 1;
            TotalFrames = 1;
        }
    }
}
