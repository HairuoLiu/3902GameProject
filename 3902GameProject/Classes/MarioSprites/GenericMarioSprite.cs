using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace _3902GameProject.Classes
{
    public abstract class GenericMarioSprite : Interfaces.ISprite
    {
        public float Depth { get; private set; }
        protected int DrawWidth { get; set; }
        protected int DrawHeight { get; set; }
        protected Texture2D MarioSpritesheet { get; private set; }
        protected Dictionary<int, Rectangle> SpriteByFrame { get; private set; }
        private int frame = 0;
        protected int TotalFrames { get; set; }
        private int delayCounter = 0;
        protected int FrameDelay { get; set; }

        protected GenericMarioSprite(Texture2D spritesheet)
        {
            SpriteByFrame = new Dictionary<int, Rectangle>();
            MarioSpritesheet = spritesheet;
            Depth =  UtilityClasses.SpriteUtilityConsts.HighDepth;
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

        public void Draw(float x, float y, SpriteBatch spriteBatch, Color tint)
        {
            spriteBatch.Draw(MarioSpritesheet, 
                new Rectangle((int)x, (int)y - DrawHeight, DrawWidth, DrawHeight), 
                SpriteByFrame[frame], 
                tint, 
                0f, 
                new Vector2(0, 0), 
                SpriteEffects.None, 
                Depth);
        }
    }
}
