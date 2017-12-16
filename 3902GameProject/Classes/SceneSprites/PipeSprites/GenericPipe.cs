using _3902GameProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _3902GameProject.Classes.UtilityClasses;

namespace _3902GameProject.Classes
{
    public abstract class GenericPipe : IPipe, ISprite
    {
        public Boolean PUp { get; set; }
        public float Depth { get; private set; }
        private int drawWidth = SceneUtilityConsts.PipeWidth;
        private int drawHeight = SceneUtilityConsts.PipeHeight;
        public float XPosition { get; set; }
        public float YPosition { get; set; }

        protected Texture2D PipeSpriteSheet { get; set; }
        protected Dictionary<int, Rectangle> SpriteByFrame { get; private set; }
        private int frame = 0;
        public Boolean Psg { get; set; }
        protected int TotalFrames { get; set; }

        protected GenericPipe(Texture2D spritesheet)
        {
            SpriteByFrame = new Dictionary<int, Rectangle>();
            PipeSpriteSheet = spritesheet;
            Depth = SceneUtilityConsts.PipeDepth;
            Psg = false;
        }

        public Rectangle BoundingRectangle()
        {
            return new Rectangle((int)XPosition, (int)YPosition - drawHeight, drawWidth, drawHeight);
        }

        public virtual void Enter()
        {
        }

        public void Update()
        {
        }

        // To match ISprite interface
        public void Draw(float x, float y, SpriteBatch spriteBatch, Color tint)
        {
            Draw(spriteBatch);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(PipeSpriteSheet, 
                this.BoundingRectangle(), 
                SpriteByFrame[frame], 
                Color.White, 
                0f, 
                new Vector2(0, 0), 
                SpriteEffects.None, 
                Depth);
        }
    }
}
