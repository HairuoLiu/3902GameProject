using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace _3902GameProject.Classes
{
    public class LeftRunningSmallMarioSprite : GenericShortMarioSprite
    {
        public LeftRunningSmallMarioSprite(Texture2D spritesheet) : base(spritesheet)
        {
            SpriteByFrame.Add(0, new Rectangle(UtilityClasses.SpriteUtilityConsts.SLWMXPos1, UtilityClasses.SpriteUtilityConsts.SYPos1, UtilityClasses.SpriteUtilityConsts.SmallSprite, UtilityClasses.SpriteUtilityConsts.SmallSprite));
            SpriteByFrame.Add(1, new Rectangle(UtilityClasses.SpriteUtilityConsts.SLWMXPos2, UtilityClasses.SpriteUtilityConsts.SYPos1, UtilityClasses.SpriteUtilityConsts.SmallSprite, UtilityClasses.SpriteUtilityConsts.SmallSprite));
            SpriteByFrame.Add(2, new Rectangle(UtilityClasses.SpriteUtilityConsts.SLWMXPos3, UtilityClasses.SpriteUtilityConsts.SYPos1, UtilityClasses.SpriteUtilityConsts.SmallSprite, UtilityClasses.SpriteUtilityConsts.SmallSprite));
            FrameDelay = UtilityClasses.SpriteUtilityConsts.TinyDelay;
            TotalFrames = UtilityClasses.SpriteUtilityConsts.NormalFrameCount;
        }
    }
}
