using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3902GameProject.Classes
{
    public class RightTurtle : GenericTurtle
    {
        public RightTurtle(Texture2D spritesheet) : base(spritesheet)
        {
            SpriteByFrame.Add(0, new Rectangle(UtilityClasses.SpriteUtilityConsts.RightTurtleXPos, 0, UtilityClasses.SpriteUtilityConsts.SmallSprite, UtilityClasses.SpriteUtilityConsts.MedSprite));
            SpriteByFrame.Add(1, new Rectangle(UtilityClasses.SpriteUtilityConsts.RightTurtleXPos + UtilityClasses.SpriteUtilityConsts.BigXGap, 0, UtilityClasses.SpriteUtilityConsts.SmallSprite, UtilityClasses.SpriteUtilityConsts.MedSprite));
            FrameDelay = UtilityClasses.SpriteUtilityConsts.LargeDelay;
            TotalFrames = UtilityClasses.SpriteUtilityConsts.SmallFrameCount;
        }
    }
}
