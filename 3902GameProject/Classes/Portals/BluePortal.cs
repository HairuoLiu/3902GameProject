﻿using _3902GameProject.Classes.UtilityClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3902GameProject.Classes.Portals
{
    public class BluePortal : GenericPortal
    {
        public BluePortal(float x, float y, Texture2D spritesheet) : base(spritesheet)
        {
            PosX = x;
            PosY = y;
            SpriteByFrame.Add(0, new Rectangle(SpriteUtilityConsts.BPortalX, SpriteUtilityConsts.BPortalY, SpriteUtilityConsts.SpecialH, SpriteUtilityConsts.BigSprite));
            TotalFrames = 1;
        }
    }
}
