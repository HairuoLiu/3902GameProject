using _3902GameProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using static _3902GameProject.Classes.CollisionGeneral;
using _3902GameProject.Classes.UtilityClasses;

namespace _3902GameProject.Classes
{
    public abstract class GenericBlock : IBlock, ISprite
    {
        public Boolean PUp { get; set; }
        public Boolean PickedUp { get; set; }
        public float Depth { get; protected set; }
        private int drawWidth = SceneUtilityConsts.DrawWidth;
        private int drawHeight = SceneUtilityConsts.DrawHeight;
        public float XPosition { get; set; }
        public float YPosition { get; set; }

        protected Texture2D BlockSpritesheet { get; private set; }
        protected Dictionary<int, Rectangle> SpriteByFrame { get; private set; }
        private int delayCounter = 0;
        protected int FrameDelay { get; set; }
        private int frame = 0;
        protected int TotalFrames { get; set; }
        public bool IsVisible { get; protected set; }
        public bool IsBouncing { get; protected set; }
        private int bouncingFrame = 0;
        private int totalBouncingFrames = SceneUtilityConsts.TotalBouncingFrames;
        private int[] bouncingOffset = SceneUtilityConsts.BouncingOffset;

        private Func<int, int, IItem> getItem;

        protected GenericBlock(Texture2D spritesheet, Func<int, int, IItem> func)
        {
            BlockSpritesheet = spritesheet;
            SpriteByFrame = new Dictionary<int, Rectangle>();
            getItem = func;
            Depth = SceneUtilityConsts.Depth;
        }

        public virtual Rectangle BoundingRectangle()
        {
            Rectangle OffsetHitbox = Hitboxes.BlockHitbox();
            return new Rectangle((int)XPosition + OffsetHitbox.X, (int)YPosition + OffsetHitbox.Y, OffsetHitbox.Width, OffsetHitbox.Height);
        }

        public abstract void PunchFromBelow(IPlayer player);

        protected void SpawnItem()
        {
            if (getItem != null)
            {
                Game1.GameInstance.GameLevel.AddObject(getItem((int)XPosition, (int)YPosition), false);
            }
        }

        public void CollisionWithPlayer(CollisionDirection dir, IPlayer player)
        {
            if ((dir == CollisionDirection.Bottom) && (player.Physics.YVelocity < 0))
            {
                PunchFromBelow(player);
            }
        }

        public void Draw(float x, float y, SpriteBatch spriteBatch, Color tint)
        {
            Draw(spriteBatch);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(BlockSpritesheet, 
                new Rectangle((int)XPosition, (int)YPosition - drawHeight, drawWidth, drawHeight), 
                SpriteByFrame[frame], Color.White, 0f, new Vector2(0, 0), SpriteEffects.None, Depth);
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

            if (IsBouncing && bouncingFrame < totalBouncingFrames)
            {
                YPosition += bouncingOffset[bouncingFrame];
                bouncingFrame++;
            }
            if (bouncingFrame >= totalBouncingFrames)
            {
                IsBouncing = false;
                bouncingFrame = 0;
                SpawnItem();
            }

        }

        protected void Bounce()
        {
            if (!IsBouncing)
            {
                IsBouncing = true;
            }
        }

        protected void MakeUsed()
        {
            SpriteByFrame[0] = SceneUtilityConsts.UsedBlockRectangle;
            frame = 0;
            delayCounter = 0;
            FrameDelay = 1;
            TotalFrames = 1;
        }
    }
}
