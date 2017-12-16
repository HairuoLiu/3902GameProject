using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using _3902GameProject.Classes.UtilityClasses;

namespace _3902GameProject.Classes.SceneSprites.Misc_Sprites
{
    public class FlagIdleSprites : GenericScenery
    { 
        public FlagIdleSprites(float x, float y, Texture2D spritesheet) : base(spritesheet)
        {
            XPosition = x;
            YPosition = y;
            SpriteByFrame.Add(0, SceneUtilityConsts.FlagRectangle1);
            TotalFrames = 0;
            DrawWidth = SceneUtilityConsts.FlagDrawWidth;
            DrawHeight = SceneUtilityConsts.FlagDrawHeight;
        }

    }
}
