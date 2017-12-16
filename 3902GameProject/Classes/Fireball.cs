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
    public class Fireball : IWeapon, ISprite
    {
        public Boolean PUp { get; set; }
        public float Depth { get; private set; }
        private int drawWidth = FireballUtilityConsts.DrawSmall;
        private int drawHeight = FireballUtilityConsts.DrawSmall;

        private Texture2D FireballSpritesheet;
        private Dictionary<int, Rectangle> spriteByFrame;
        private int frame = 0;
        private int totalFrames;
        private int delayCounter = 0;
        private int frameDelay;
        private int explosionTimer = 0;
        private int explosionTotalTime;
        public IObjectPhysics Physics { get; private set; }
        private IMario marioInstance;

        public Fireball(IMario mario, bool isLeftFireball)
        {
            marioInstance = mario;
            FireballSpritesheet = EnemySpriteFactory.Instance.CreateFireball();
            spriteByFrame = new Dictionary<int, Rectangle>
            {
                { 1, FireballUtilityConsts.FireballRec1 },
                { 3, FireballUtilityConsts.FireballRec2 },
                { 2, FireballUtilityConsts.FireballRec3 },
                { 0, FireballUtilityConsts.FireballRec4 }
            };
            totalFrames = FireballUtilityConsts.Frames;
            frameDelay = FireballUtilityConsts.FrameDelay;
            Physics = new ObjectPhysics(mario.BoundingRectangle().Center.X, mario.BoundingRectangle().Center.Y, 0, FireballUtilityConsts.XSpeed, FireballUtilityConsts.XSpeed+1);
            Physics.XVelocity = isLeftFireball ? -FireballUtilityConsts.XSpeed : FireballUtilityConsts.XSpeed;
            Physics.YVelocity = FireballUtilityConsts.YSpeed;
            explosionTotalTime = FireballUtilityConsts.ExplostionTotal;
            Depth = 1;
        }

        public Rectangle BoundingRectangle()
        {
            if (explosionTimer > 0) return new Rectangle(0, 0, 0, 0);
            else return new Rectangle((int)Physics.XPosition + 3 * drawWidth / 4, (int)Physics.YPosition - 3 * drawHeight / 4, drawWidth / 2, drawHeight / 2);
        }

        public void Update()
        {
            delayCounter++;
            if (delayCounter >= frameDelay)
            {
                delayCounter = 0;
                frame++;
            }
            if (frame >= totalFrames) frame = 0;

            if (explosionTimer >= explosionTotalTime)
            {
                marioInstance.Fireballs.Remove(this);
            }

            if (explosionTimer > 0)
            {
                explosionTimer++;
                return;
            }

            Physics.Update();
        }

        // to implement ISprite
        public void Draw(float x, float y, SpriteBatch spriteBatch, Color tint)
        {
            Draw(spriteBatch);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(FireballSpritesheet, 
                new Rectangle((int)Physics.XPosition, 
                (int)Physics.YPosition - drawHeight, 
                drawWidth, drawHeight), 
                spriteByFrame[frame], 
                Color.White, 
                0f, 
                new Vector2(0, 0), 
                SpriteEffects.None, 
                Depth);
        }

        public void Bounce(float y)
        {
            Physics.YPosition = y;
            Physics.YVelocity = -FireballUtilityConsts.YSpeed;
            Physics.Gravity = FireballUtilityConsts.Gravity;
        }

        public void Destroy()
        {
            drawHeight = FireballUtilityConsts.DrawLarge;
            drawWidth = FireballUtilityConsts.DrawLarge;
            Physics.XPosition -= FireballUtilityConsts.DestroyXOffset;
            Physics.YPosition += FireballUtilityConsts.DestroyXOffset;
            frame = 0;
            delayCounter = 0;
            spriteByFrame = new Dictionary<int, Rectangle>
            {
                { 0, FireballUtilityConsts.DestroyFireballRec1 },
                { 1, FireballUtilityConsts.DestroyFireballRec2 },
                { 2, FireballUtilityConsts.DestroyFireballRec3 }
            };
            totalFrames = FireballUtilityConsts.DestroyFrames;
            frameDelay = FireballUtilityConsts.DestroyFrameDelay;
            explosionTimer = 1;
        }
    }
}
