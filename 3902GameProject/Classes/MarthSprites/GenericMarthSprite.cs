using _3902GameProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace _3902GameProject.Classes
{
    public abstract class GenericMarthSprite : ISprite
    {
        public float Depth { get; private set; }
        protected int DrawWidth { get; set; }
        protected int DrawHeight { get; set; }
        protected Texture2D MarthSpritesheet { get; private set; }
        protected Dictionary<int, Rectangle> SpriteByFrame { get; private set; }
        private int frame = 0;
        protected int TotalFrames { get; set; }
        private int delayCounter = 0;
        protected int FrameDelay { get; set; }

        protected GenericMarthSprite(Texture2D spritesheet)
        {
            SpriteByFrame = new Dictionary<int, Rectangle>();
            MarthSpritesheet = spritesheet;
            Depth = 1f;
        }

        public virtual void Update()
        {
            delayCounter++;
            if (delayCounter >= FrameDelay)
            {
                frame++;
                delayCounter = 0;
            }
            if (frame >= TotalFrames)
                frame = 0;
        }

        public virtual void Draw(float x, float y, SpriteBatch spriteBatch, Color tint)
        {
            spriteBatch.Draw(MarthSpritesheet, 
                new Rectangle((int)x, (int)y, DrawWidth, DrawHeight), 
                SpriteByFrame[frame], 
                tint, 
                0f, 
                new Vector2(0, 0), 
                SpriteEffects.None, 
                Depth);
        }
    }
}
