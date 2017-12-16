using _3902GameProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using _3902GameProject.Classes.UtilityClasses;

namespace _3902GameProject.Classes
{
    public class MultiHitBrickBlock : GenericBlock
    {
        //private Texture2D tempSpriteSheet;
        private int numOfHitsRemaining;
        public MultiHitBrickBlock(float x, float y, Texture2D spritesheet, Func<int, int, IItem> func, int hits) : base(spritesheet, func)
        {
            IsVisible = true;
            XPosition = x;
            YPosition = y;
            SpriteByFrame.Add(0, SceneUtilityConsts.BrickBlockRectangle);
            FrameDelay = 1;
            TotalFrames = 1;
            numOfHitsRemaining = hits;
        }

        public override void PunchFromBelow(IPlayer player)
        {
            if (numOfHitsRemaining > 0)
            {
                numOfHitsRemaining--;
                Game1.GameInstance.Scorekeeper.Points += SceneUtilityConsts.BlockPoints;
                this.Bounce();
            }
            if (numOfHitsRemaining == 0)
            {
                this.MakeUsed();
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        public override void Update()
        {
            base.Update();
        }
    }
}
