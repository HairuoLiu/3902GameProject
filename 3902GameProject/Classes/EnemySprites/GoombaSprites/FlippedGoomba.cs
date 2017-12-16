using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3902GameProject.Classes
{
    public class FlippedGoomba : GenericGoomba
    {
        public FlippedGoomba(Texture2D spritesheet) : base(spritesheet)
        {
            SpriteByFrame.Add(0, new Rectangle(UtilityClasses.SpriteUtilityConsts.GoombaFlippedX, UtilityClasses.SpriteUtilityConsts.GoombaFlippedY, UtilityClasses.SpriteUtilityConsts.SmallSprite, UtilityClasses.SpriteUtilityConsts.SmallSprite));
            FrameDelay = 1;
            TotalFrames = 1;
        }
    }
}
