using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using _3902GameProject.Classes.UtilityClasses;

namespace _3902GameProject.Classes.SceneSprites.Misc_Sprites
{
    public class FlagPoleSprite : GenericScenery
    { 
        public FlagPoleSprite(float x, float y, Texture2D spritesheet) : base(spritesheet)
        {
            DrawWidth = 16;
            DrawHeight = 152;
            XPosition = x;
            YPosition = y;
            SpriteByFrame.Add(0, new Rectangle(288, 594, DrawWidth, DrawHeight));
            TotalFrames = 0;
        }
        public override Rectangle BoundingRectangle()
        {
            return new Rectangle((int)XPosition + 7, (int)YPosition - DrawHeight, 2, DrawHeight);
        }
    }
}
