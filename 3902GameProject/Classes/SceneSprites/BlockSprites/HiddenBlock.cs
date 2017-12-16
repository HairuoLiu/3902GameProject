using _3902GameProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using _3902GameProject.Classes.UtilityClasses;

namespace _3902GameProject.Classes
{
    public class HiddenBlock : GenericBlock
    {
        public HiddenBlock(float x, float y, Texture2D spritesheet, Func<int, int, IItem> func) : base(spritesheet, func)
        {
            IsVisible = false;
            XPosition = x;
            YPosition = y;
            SpriteByFrame.Add(0, new Rectangle(0, 0, 0, 0));
            FrameDelay = 1;
            TotalFrames = 1;
        }
        public override void PunchFromBelow(IPlayer player)
        {
            if (!IsVisible)
            {
                IsVisible = true;
                this.MakeUsed();
                Game1.GameInstance.Scorekeeper.Points += SceneUtilityConsts.BlockPoints;
                this.Bounce();
            }
        }
    }
}