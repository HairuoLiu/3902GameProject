using _3902GameProject.Classes.UtilityClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3902GameProject.Classes.Portals
{
    public class PortalGunFlipped : GenericPortal
    {
        public PortalGunFlipped(float x, float y, Texture2D spritesheet) : base(spritesheet)
        {
            PosX = x;
            PosY = y;
            SpriteByFrame.Add(0, new Rectangle(SpriteUtilityConsts.FPortalGunX, SpriteUtilityConsts.PortalGunY, SpriteUtilityConsts.SpecialWidth, SpriteUtilityConsts.SpecialH));
            TotalFrames = 1;
            DrawHeight = SpriteUtilityConsts.SpecialH;
            DrawWidth = SpriteUtilityConsts.SpecialWidth;
            Gun = true;
        }
    }
}
