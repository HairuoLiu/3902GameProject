using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using _3902GameProject.Classes.UtilityClasses;
using _3902GameProject.Interfaces;

namespace _3902GameProject
{
    public class MenuBackground : ISprite
    {
        public float Depth { get; private set; }
        private Texture2D texture;
        private int drawWidth = 1024;
        private int drawHeight = 872;

        public MenuBackground(Texture2D spriteSheet)
        {
            texture = spriteSheet;
            Depth = 0;
        }

        public void Draw(float x, float y,SpriteBatch spriteBatch, Color tint)
        {
            Rectangle sourceRectangle = new Rectangle(0, 0, drawWidth, drawHeight);
            Rectangle destinationRectangle = new Rectangle((int)x, (int)y - drawHeight, drawWidth, drawHeight);
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
