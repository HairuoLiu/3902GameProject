using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace _3902GameProject.Classes
{
    public class YellowRectangle : IGameObject
    {
        private Texture2D spritesheet;
        public bool PUp { get; set; }
        private int drawWidth = 1;
        private int drawHeight = 1;

        public YellowRectangle(Texture2D spritesheet)
        {
            this.spritesheet = spritesheet;
        }
        public Rectangle BoundingRectangle()
        {
            return new Rectangle(0, 0, 0, 0);
        }
        public void Update()
        {
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            int x = ScaledX(Game1.Scale);
            int y = (int)(Game1.Scale * Game1.WINDOW_HEIGHT_BASE * 0.83f);
            int width = (int)(Game1.Scale * 20 / 3.0f);
            int height = (int)(Game1.Scale * 40 / 3.0f);
            spriteBatch.Draw(spritesheet, new Rectangle(x, y, width, height), new Rectangle(600, 650, drawWidth, drawHeight), Color.White);
        }
        private static int ScaledX(float scale)
        {
            float percent = Math.Min(Math.Max((scale - 2.0f) / 1.5f, 0), 1);
            return (int)((25 + 418 * percent) * scale / 3.5f); 
        }
    }
}
