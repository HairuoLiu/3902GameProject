using _3902GameProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using _3902GameProject.Classes.UtilityClasses;


namespace _3902GameProject.Classes
{
    public class DarkBrickBlock : GenericBlock
    {
        //private IList<IBlock> brickBits;
        private Texture2D tempSpriteSheet;
        private int destroyTimer = SceneUtilityConsts.DestroyTimerStart;
        private int destroyTimerTotal = SceneUtilityConsts.DestroyTimerEnd;
        public DarkBrickBlock(float x, float y, Texture2D spritesheet, Func<int, int, IItem> func) : base(spritesheet, func)
        {
            IsVisible = true;
            XPosition = x;
            YPosition = y;
            SpriteByFrame.Add(0, SceneUtilityConsts.DarkBrickBlockRectangle);
            FrameDelay = 1;
            TotalFrames = 1;
            tempSpriteSheet = spritesheet;
        }

        public override void PunchFromBelow(IPlayer player)
        {
            if (IsVisible)
            {
                Bounce();
                if (player is IMario mario && !mario.IsTall()) return;
                IsVisible = false;
                Game1.GameInstance.Scorekeeper.Points += SceneUtilityConsts.BlockPoints;
                destroyTimer = 0;
                SpriteByFrame[0] = SceneUtilityConsts.Empty;

                ILevel level = Game1.GameInstance.GameLevel;
                level.AddObject(new DarkBrickBit(XPosition + (SceneUtilityConsts.DrawHeight >> 1), YPosition, tempSpriteSheet, SceneUtilityConsts.BitLaunchSpeedX, -SceneUtilityConsts.BitLaunchSpeedY, null), true);
                level.AddObject(new DarkBrickBit(XPosition + (SceneUtilityConsts.DrawHeight >> 1), YPosition+8, tempSpriteSheet, SceneUtilityConsts.BitLaunchSpeedX, -SceneUtilityConsts.BitLaunchSpeedX, null), true);
                level.AddObject(new DarkBrickBit(XPosition, YPosition, tempSpriteSheet, -SceneUtilityConsts.BitLaunchSpeedX, -SceneUtilityConsts.BitLaunchSpeedY, null), true);
                level.AddObject(new DarkBrickBit(XPosition, YPosition+8, tempSpriteSheet, -SceneUtilityConsts.BitLaunchSpeedX, -SceneUtilityConsts.BitLaunchSpeedX, null), true);
            }
        }

        public override void Update()
        {
            if (destroyTimer >= destroyTimerTotal)
            {
                ILevel level = Game1.GameInstance.GameLevel;
                level.RemoveObject(this, true);
            }
            if (destroyTimer >= 0)
            {
                destroyTimer++;
            }
            base.Update();
        }
    }
}
