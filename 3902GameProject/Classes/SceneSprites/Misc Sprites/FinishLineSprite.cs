using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using _3902GameProject.Classes.UtilityClasses;

namespace _3902GameProject.Classes.SceneSprites.Misc_Sprites
{
    public class FinishLineSprite : GenericScenery
    { 
        public FinishLineSprite(float x, float y, Texture2D spritesheet) : base(spritesheet)
        {
            DrawWidth = 16;
            DrawHeight = 200;
            XPosition = x;
            YPosition = y;
            SpriteByFrame.Add(0, new Rectangle(25, 661, DrawWidth, DrawHeight));
            TotalFrames = 0;
        }
    }
}
