using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3902GameProject.Classes
{
    public class LeftTurtle : GenericTurtle
    {
        public LeftTurtle(Texture2D spritesheet) : base(spritesheet)
        {
            SpriteByFrame.Add(0, new Rectangle(UtilityClasses.SpriteUtilityConsts.LeftTurtleXPos, 0, UtilityClasses.SpriteUtilityConsts.SmallSprite, UtilityClasses.SpriteUtilityConsts.MedSprite));
            SpriteByFrame.Add(1, new Rectangle(UtilityClasses.SpriteUtilityConsts.LeftTurtleXPos-UtilityClasses.SpriteUtilityConsts.BigXGap, 0, UtilityClasses.SpriteUtilityConsts.SmallSprite, UtilityClasses.SpriteUtilityConsts.MedSprite));
            TotalFrames = UtilityClasses.SpriteUtilityConsts.SmallFrameCount;
            FrameDelay = UtilityClasses.SpriteUtilityConsts.LargeDelay;
        }
    }
}
