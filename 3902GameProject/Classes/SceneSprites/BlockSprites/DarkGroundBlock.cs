﻿using _3902GameProject.Classes.UtilityClasses;
using _3902GameProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace _3902GameProject.Classes
{
    public class DarkGroundBlock : GenericBlock
    {
        public DarkGroundBlock(float x, float y, Texture2D spritesheet, Func<int, int, IItem> func) : base(spritesheet, func)
        {
            IsVisible = true;
            XPosition = x;
            YPosition = y;
            SpriteByFrame.Add(0, SceneUtilityConsts.DarkGroundBlockRectangle);
            FrameDelay = 1;
            TotalFrames = 1;
        }

        public override void PunchFromBelow(IPlayer player)
        {
        }
    }
}