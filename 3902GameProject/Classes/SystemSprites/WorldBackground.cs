using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using _3902GameProject.Classes.UtilityClasses;

namespace _3902GameProject
{
    public class WorldBackground : Interfaces.ISprite
    {
        public float Depth { get; private set; }
        Texture2D texture;
        int spriteSheetImageWidth;
        int spriteSheetImageHeight;
        int originX = 0;
        int originY = 0;

        public WorldBackground(ContentManager content)
        {
            this.texture = content.Load<Texture2D>(StringConsts.BackgroundSpriteSheet); // temp background
            spriteSheetImageWidth = texture.Width;
            spriteSheetImageHeight = texture.Height;
            Depth = 0;
        }

        public void Draw(float x, float y,SpriteBatch spriteBatch, Color tint)
        {
            Rectangle sourceRectangle = new Rectangle(originX, originY, spriteSheetImageWidth, spriteSheetImageHeight);
            Rectangle destinationRectangle = new Rectangle(originX, originY-24, spriteSheetImageWidth, spriteSheetImageHeight);
            spriteBatch.Draw(texture, 
                destinationRectangle, 
                sourceRectangle, 
                tint, 
                0f, 
                new Vector2(0,0), 
                SpriteEffects.None, 
                Depth);
        }

        public void Update()
        {

        }
    }
}
