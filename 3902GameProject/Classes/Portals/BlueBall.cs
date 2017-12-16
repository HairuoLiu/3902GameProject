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
    public class BlueBall : GenericPortal
    {
        public BlueBall(float x, float y, float vel, Texture2D spritesheet) : base(spritesheet)
        {
            PosX = x;
            PosY = y;
            SpriteByFrame.Add(0, new Rectangle(SpriteUtilityConsts.PortalBallX, SpriteUtilityConsts.PortalBBallY, SpriteUtilityConsts.TiniestGap, SpriteUtilityConsts.TiniestGap));
            TotalFrames = 1;
            Ball = true;
            Vel = vel;
            DrawHeight = SpriteUtilityConsts.TiniestGap;
            DrawWidth = SpriteUtilityConsts.TiniestGap;
        }
    }
}
