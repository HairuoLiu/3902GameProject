using _3902GameProject.Interfaces;
using _3902GameProject.Classes.SceneSprites.Misc_Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using _3902GameProject.Classes.UtilityClasses;


namespace _3902GameProject.Classes
{
    public class QuestionBlock : GenericBlock
    {
        public bool IsUsed { get; private set; }
        public QuestionBlock(float x, float y, Texture2D spritesheet, Func<int, int, IItem> func) : base(spritesheet, func)
        {
            IsUsed = false;
            IsVisible = true;
            XPosition = x;
            YPosition = y;
            SpriteByFrame.Add(0, SceneUtilityConsts.QuestionBlockRectangle1);
            SpriteByFrame.Add(1, SceneUtilityConsts.QuestionBlockRectangle1);
            SpriteByFrame.Add(2, SceneUtilityConsts.QuestionBlockRectangle1);
            SpriteByFrame.Add(3, SceneUtilityConsts.QuestionBlockRectangle2);
            SpriteByFrame.Add(4, SceneUtilityConsts.QuestionBlockRectangle3);
            SpriteByFrame.Add(5, SceneUtilityConsts.QuestionBlockRectangle2);
            FrameDelay = SceneUtilityConsts.QuestionBlockFrameDelay;
            TotalFrames = SceneUtilityConsts.QuestionBlockTotalFrames;
        }
        public override void PunchFromBelow(IPlayer player)
        {
            if (!IsUsed)
            {
                IsUsed = true;
                this.MakeUsed();
                Game1.GameInstance.Scorekeeper.Points += SceneUtilityConsts.BlockPoints;
                this.Bounce();
            }

        }
    }
}