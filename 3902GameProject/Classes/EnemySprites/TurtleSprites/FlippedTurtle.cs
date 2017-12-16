using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3902GameProject.Classes
{
    public class FlippedTurtle : GenericTurtle
    {
        public FlippedTurtle(Texture2D spritesheet) : base(spritesheet)
        {
            SpriteByFrame.Add(0, new Rectangle(UtilityClasses.SpriteUtilityConsts.FlippedTurtlePosX, UtilityClasses.SpriteUtilityConsts.FlippedTurtlePosY, UtilityClasses.SpriteUtilityConsts.SmallSprite, UtilityClasses.SpriteUtilityConsts.MedSprite));
            FrameDelay = 1;
            TotalFrames = 1;
        }
    }
}
