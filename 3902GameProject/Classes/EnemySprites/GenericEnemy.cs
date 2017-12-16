using _3902GameProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static _3902GameProject.Classes.CollisionHandler;

namespace _3902GameProject.Classes
{
    public abstract class GenericEnemy : Interfaces.ISprite
    {
        public float Depth { get; private set; }
        protected Texture2D EnemySpriteSheet { get; private set; }
        protected Dictionary<int, Rectangle> SpriteByFrame { get; private set; }
        public int DrawWidth { get; protected set; }
        public int DrawHeight { get; protected set; }
        private int delayCounter = 0;
        protected int FrameDelay { get; set; }
        private int frame = 0;
        protected int TotalFrames { get; set; }

        protected GenericEnemy(Texture2D spritesheet)
        {
            EnemySpriteSheet = spritesheet;
            SpriteByFrame = new Dictionary<int, Rectangle>();
            Depth = UtilityClasses.SpriteUtilityConsts.MedDepth;
        }

        public void Update()
        {
            delayCounter++;
            if (delayCounter >= FrameDelay)
            {
                delayCounter = 0;
                frame++;
            }
            if (frame >= TotalFrames)
                frame = 0;
        }

        public void Draw(float x, float y, SpriteBatch spriteBatch, Color tint)
        {
            spriteBatch.Draw(EnemySpriteSheet, 
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
