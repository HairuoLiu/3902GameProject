using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _3902GameProject.Classes.UtilityClasses;

namespace _3902GameProject.Classes.SceneSprites.Misc_Sprites
{
    public class Flag4StepAnimationSprites : GenericScenery
    {
        public Flag4StepAnimationSprites(float x, float y, Texture2D spritesheet) : base(spritesheet)
        {
            XPosition = x;
            YPosition = y;
            SpriteByFrame.Add(0, SceneUtilityConsts.FlagRectangle1);
            SpriteByFrame.Add(1, SceneUtilityConsts.FlagRectangle2);
            SpriteByFrame.Add(2, SceneUtilityConsts.FlagRectangle3);
            SpriteByFrame.Add(3, SceneUtilityConsts.FlagRectangle4);
            SpriteByFrame.Add(4, SceneUtilityConsts.FlagRectangle5);
            TotalFrames = SceneUtilityConsts.FlagFrames;
            DrawWidth = SceneUtilityConsts.FlagDrawWidth;
            DrawHeight = SceneUtilityConsts.FlagDrawHeight;
        }
    }
}
