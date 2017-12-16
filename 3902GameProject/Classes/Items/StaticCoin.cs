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
    public class StaticCoin : IItem, ISprite
    {
        public Boolean PUp { get; set; }
        public ItemData ItemInfo { get; set; }
        private static readonly int InitDelay = 0;
        private static readonly int InitFrame = 0;
        private static readonly int XPos = 124;
        private static readonly int XGap = 30;
        private static readonly int YPos = 94;
        private static readonly int SmallSprite = 16;
        private static readonly int FDelay = 6;
        private static readonly int FrameCount = 4;
        private static readonly float InitDepth = 0.4f;
        public float Depth { get; private set; }
        private readonly int drawWidth = 16;
        private readonly int drawHeight = 16;
        private int delayCounter = InitDelay;
        private int frame = InitFrame;
        private int FrameDelay;
        private int TotalFrames;
        protected Texture2D ItemSpritesheet { get; private set; }
        protected Dictionary<int, Rectangle> SpriteByFrame { get; private set; }

        public StaticCoin(float x, float y, Texture2D spritesheet)
        {
            SpriteByFrame = new Dictionary<int, Rectangle>();
            ItemInfo = new ItemData(0, 0, 0);
            ItemSpritesheet = spritesheet;
            ItemInfo.XPosition = x;
            ItemInfo.YPosition = y;
            SpriteByFrame.Add(0, new Rectangle(XPos, YPos, SmallSprite, SmallSprite));
            SpriteByFrame.Add(1, new Rectangle(XPos + XGap, YPos, SmallSprite, SmallSprite));
            SpriteByFrame.Add(2, new Rectangle(XPos + (2*XGap), YPos, SmallSprite, SmallSprite));
            SpriteByFrame.Add(3, new Rectangle(XPos + (3*XGap), YPos, SmallSprite, SmallSprite));
            FrameDelay = FDelay;
            TotalFrames = FrameCount;
            ItemInfo.XVelocity = 0;
            ItemInfo.YVelocity = 0;
            Depth = InitDepth;
        }

        public Rectangle BoundingRectangle()
        {
            return new Rectangle((int)ItemInfo.XPosition, (int)ItemInfo.YPosition - drawHeight, drawWidth, drawHeight);
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
            Draw(spriteBatch);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(ItemSpritesheet, new Rectangle((int)ItemInfo.XPosition, (int)ItemInfo.YPosition - drawHeight, drawWidth, drawHeight), SpriteByFrame[frame], Color.White, 0f, new Vector2(0, 0), SpriteEffects.None, Depth);
        }
    }
}

