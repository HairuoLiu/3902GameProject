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
    public class SuperStar : IItem, ISprite
    {
        public Boolean PUp { get; set; }
        private static readonly int SmallSprite = 16;
        private static readonly float RisePer = 0.25f;
        private static readonly int FramesRising = 64;
        private static readonly int Xpos = 4;
        private static readonly int YPos = 94;
        private static readonly int XGap = 30;
        private static readonly int FDelay = 14;
        private static readonly int FrameCount = 4;
        private static readonly int InitXVel = 1;
        private static readonly float ArcVal = 1.7f;
        private static readonly float InitDepth = 0.2f;
        private static readonly float ArcIncrement = 0.07f;
        private static readonly int WidthBuffer = 3;
        public ItemData ItemInfo { get; set; }
        public float Depth { get; set; }
        private int drawWidth = SmallSprite;
        private int drawHeight = SmallSprite;
        protected Texture2D ItemSpritesheet { get; private set; }
        protected Dictionary<int, Rectangle> SpriteByFrame { get; private set; }
        private int frame = 0;
        protected int TotalFrames { get; set; }
        private int delayCounter = 0;
        protected int FrameDelay { get; set; }
        public bool BounceUp { get; set; }
        public double Arc { get; set; }

        public SuperStar (float x, float y, Texture2D spritesheet)
        {
            ItemSpritesheet = spritesheet;
            ItemInfo = new ItemData(RisePer, 0, FramesRising);
            SpriteByFrame = new Dictionary<int, Rectangle>();
            ItemInfo.XPosition = x;
            ItemInfo.YPosition = y;
            SpriteByFrame.Add(0, new Rectangle(Xpos, YPos, SmallSprite, SmallSprite));
            SpriteByFrame.Add(1, new Rectangle(Xpos + XGap, YPos, SmallSprite, SmallSprite));
            SpriteByFrame.Add(2, new Rectangle(Xpos + (2*XGap), YPos, SmallSprite, SmallSprite));
            SpriteByFrame.Add(3, new Rectangle(Xpos + (3*30), YPos, SmallSprite, SmallSprite));
            FrameDelay = FDelay;
            TotalFrames = FrameCount;
            ItemInfo.XVelocity = InitXVel;
            Arc = ArcVal;
            BounceUp = true;
            Depth = InitDepth;
        }

        private void Bounce()
        {
            if (BounceUp)
            {
                ItemInfo.YPosition -= (float)Math.Pow(Arc, 2);
                Arc = Arc - ArcIncrement;
                if(Arc <= 0)
                {
                    Arc = 0;
                    BounceUp = false;
                }
            }
            else
            {
                ItemInfo.YPosition += (float)Math.Pow(Arc, 2);
                if (Arc < ArcVal)
                {
                    Arc = Arc + ArcIncrement;
                }
            }

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
                ItemInfo.XPosition += ItemInfo.XVelocity;
                Bounce();
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
            spriteBatch.Draw(ItemSpritesheet, new Rectangle((int)ItemInfo.XPosition, (int)ItemInfo.YPosition - drawHeight, drawWidth, drawHeight), SpriteByFrame[frame], Color.White, 0f, new Vector2(0, 0), SpriteEffects.None, Depth);
        }
    }
}

