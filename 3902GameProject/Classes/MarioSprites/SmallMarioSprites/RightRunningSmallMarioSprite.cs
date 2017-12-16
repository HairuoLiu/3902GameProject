using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace _3902GameProject.Classes
{
    public class RightRunningSmallMarioSprite : GenericShortMarioSprite
    {
        public RightRunningSmallMarioSprite(Texture2D spritesheet) : base(spritesheet)
        {
            SpriteByFrame.Add(0, new Rectangle(UtilityClasses.SpriteUtilityConsts.SRMXPos1, UtilityClasses.SpriteUtilityConsts.SYPos1, UtilityClasses.SpriteUtilityConsts.SmallSprite, UtilityClasses.SpriteUtilityConsts.SmallSprite));
            SpriteByFrame.Add(1, new Rectangle(UtilityClasses.SpriteUtilityConsts.SRMXPos2, UtilityClasses.SpriteUtilityConsts.SYPos1, UtilityClasses.SpriteUtilityConsts.SmallSprite, UtilityClasses.SpriteUtilityConsts.SmallSprite));
            SpriteByFrame.Add(2, new Rectangle(UtilityClasses.SpriteUtilityConsts.SRMXPos3, UtilityClasses.SpriteUtilityConsts.SYPos1, UtilityClasses.SpriteUtilityConsts.SmallSprite, UtilityClasses.SpriteUtilityConsts.SmallSprite));
            TotalFrames = UtilityClasses.SpriteUtilityConsts.NormalFrameCount;
            FrameDelay = UtilityClasses.SpriteUtilityConsts.TinyDelay;
        }
    }
}
