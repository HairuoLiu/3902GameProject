using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using _3902GameProject.Classes.UtilityClasses;

namespace _3902GameProject.Classes.SceneSprites.Misc_Sprites
{
    public class FlagSprite : GenericScenery
    { 
        public FlagSprite(float x, float y, Texture2D spritesheet) : base(spritesheet)
        {
            DrawWidth = 17;
            DrawHeight = 16;
            XPosition = x;
            YPosition = y;
            SpriteByFrame.Add(0, new Rectangle(249, 602, DrawWidth, DrawHeight));
            TotalFrames = 0;
        }
    }
}
