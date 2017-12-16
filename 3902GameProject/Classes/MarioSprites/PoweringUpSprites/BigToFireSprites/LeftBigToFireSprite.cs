using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3902GameProject.Classes.MarioSprites
{
    class LeftBigToFireSprite : GenericTallMarioSprite
    {
        public LeftBigToFireSprite(Texture2D spritesheet) : base(spritesheet)
        {
            SpriteByFrame.Add(0, new Rectangle(UtilityClasses.SpriteUtilityConsts.BLIMXPos1, UtilityClasses.SpriteUtilityConsts.FYpos, UtilityClasses.SpriteUtilityConsts.SmallSprite, UtilityClasses.SpriteUtilityConsts.BigSprite));
            SpriteByFrame.Add(1, new Rectangle(UtilityClasses.SpriteUtilityConsts.BLIMXPos1, 1, UtilityClasses.SpriteUtilityConsts.SmallSprite, UtilityClasses.SpriteUtilityConsts.BigSprite));

            TotalFrames = UtilityClasses.SpriteUtilityConsts.SmallFrameCount;
            FrameDelay = UtilityClasses.SpriteUtilityConsts.SmallDelay;
        }
    }
}
