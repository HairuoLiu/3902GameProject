using _3902GameProject.Interfaces;
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
    public class GenericScenery : IScenery
    {
        public Boolean PUp { get; set; }
        private int delayCounter = 0;
        private int FrameDelay = SceneUtilityConsts.SceneryFrameDelay;
        public float Depth { get; set; }
        public int DrawWidth { get; set; }
        public int DrawHeight { get; set; }
        public float XPosition { get; set; }
        public float YPosition { get; set; }

        protected Texture2D PipeSpriteSheet { get; set; }
        protected Dictionary<int, Rectangle> SpriteByFrame { get; private set; }
        private int frame = 0;
        protected int TotalFrames { get; set; }

        protected GenericScenery(Texture2D spritesheet)
        {
            SpriteByFrame = new Dictionary<int, Rectangle>();
            PipeSpriteSheet = spritesheet;
            Depth = SceneUtilityConsts.SceneryDepth;
        }

        public virtual Rectangle BoundingRectangle()
        {
            return new Rectangle((int) XPosition, (int) YPosition-DrawHeight, DrawWidth, DrawHeight);
        }

        public void Update()
        {
            delayCounter++;
            if (delayCounter >= FrameDelay && frame != SceneUtilityConsts.ExceptionFrame)
            {
                delayCounter = 0;
                frame++;
            }
            if (frame >= TotalFrames && frame != SceneUtilityConsts.ExceptionFrame)
                frame = 0;
        }

        // To match ISprite interface
        public void Draw(float x, float y, SpriteBatch spriteBatch, Color tint)
        {
            Draw(spriteBatch);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(PipeSpriteSheet,
                new Rectangle((int)XPosition, (int)YPosition - DrawHeight, DrawWidth, DrawHeight), 
                SpriteByFrame[frame], 
                Color.White, 
                0f, 
                new Vector2(0, 0), 
                SpriteEffects.None, 
                Depth);
        }
    }
}
