using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3902GameProject.Classes
{
    public class WalkingGoomba : GenericGoomba
    {
        public WalkingGoomba(Texture2D spritesheet) : base(spritesheet)
        {
            SpriteByFrame.Add(0, new Rectangle(0, UtilityClasses.SpriteUtilityConsts.GoombaY, UtilityClasses.SpriteUtilityConsts.SmallSprite, UtilityClasses.SpriteUtilityConsts.SmallSprite));
            SpriteByFrame.Add(1, new Rectangle(UtilityClasses.SpriteUtilityConsts.BigXGap, UtilityClasses.SpriteUtilityConsts.GoombaY, UtilityClasses.SpriteUtilityConsts.SmallSprite, UtilityClasses.SpriteUtilityConsts.SmallSprite));
            FrameDelay = UtilityClasses.SpriteUtilityConsts.LargeDelay;
            TotalFrames = UtilityClasses.SpriteUtilityConsts.SmallFrameCount;
        }
    }
}
