using _3902GameProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3902GameProject.Classes
{
    public abstract class GenericItem : IItem, ISprite
    {
        private static readonly int InitDrawWidth = 16;
        private static readonly int WidthBuffer = 3;
        private static readonly float InitDepth = 0.4f;
        private static readonly int InitDelayCounter = 0;
        private static readonly int InitFrame = 0;
        public ItemData ItemInfo { get; set; }
        public Boolean PUp { get; set; }
        public float Depth { get; private set; }
        private int drawWidth = InitDrawWidth;
        private int drawHeight = InitDrawWidth;
        protected Texture2D ItemSpritesheet { get; private set; }
        protected Dictionary<int, Rectangle> SpriteByFrame { get; private set; }
        private int frame = InitFrame;
        protected int TotalFrames { get; set; }
        private int delayCounter = InitDelayCounter;
        protected int FrameDelay { get; set; }

        protected GenericItem(Texture2D spritesheet)
        {
            ItemSpritesheet = spritesheet;
            SpriteByFrame = new Dictionary<int, Rectangle>();
            ItemInfo = new ItemData(0.25f, 0, 64);
            Depth = 0.2f;
        }

        public Rectangle BoundingRectangle()
        {
            return new Rectangle((int)ItemInfo.XPosition + WidthBuffer, (int)ItemInfo.YPosition - drawHeight + 1, drawWidth - (2*WidthBuffer), drawHeight - (int)(ItemInfo.FramesToRise * ItemInfo.RisePerFrame) - 1);
        }

        public void Update()
        {
            if (!ItemInfo.Deployed)
            {
                ItemInfo.DeployItem();
            }
            else
            {
                Depth = InitDepth;
                ItemInfo.XPosition += ItemInfo.XVelocity;
                ItemInfo.YPosition += ItemInfo.YVelocity;

                delayCounter++;
                if (delayCounter >= FrameDelay)
                {
                    delayCounter = 0;
                    frame++;
                }
                if (frame >= TotalFrames)
                    frame = 0;
            }
        }

        public void Draw(float x, float y, SpriteBatch spriteBatch, Color tint)
        {
            Draw(spriteBatch);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(ItemSpritesheet, 
                new Rectangle((int)ItemInfo.XPosition, (int)ItemInfo.YPosition - drawHeight, drawWidth, drawHeight),
                SpriteByFrame[frame],
                Color.White,
                0f,
                new Vector2(0, 0),
                SpriteEffects.None,
                Depth);
        }
    }
}
