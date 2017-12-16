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
    public class LeftSword : ISword, ISprite
    {
        public Boolean PUp { get; set; }
        public float Depth { get; private set; }
        private int drawWidth = 23;
        private int drawHeight = 29;
        public IObjectPhysics Physics { get; }

        private Texture2D SwordSpritesheet;
        private Dictionary<int, Rectangle> spriteByFrame;
        private Dictionary<int, Rectangle> hitboxByFrame;
        private int frame;
        private int totalFrames;
        private int delayCounter;
        private int frameDelay;

        public LeftSword(IMarth marth)
        {
            frame = 0;
            delayCounter = 0;
            SwordSpritesheet = PlayerSpriteFactory.Instance.CreateSword();
            spriteByFrame = new Dictionary<int, Rectangle>
            {
                { 0, new Rectangle(126, 78, drawWidth, drawHeight) },
                { 1, new Rectangle(97, 78, drawWidth, drawHeight) },
                { 2, new Rectangle(97, 78, drawWidth, drawHeight) }
            };
            hitboxByFrame = new Dictionary<int, Rectangle>
            {
                { 0, new Rectangle(-17, -20, 14, 16) },
                { 1, new Rectangle(-20, -28, 17, 22) },
                { 2, new Rectangle(-20, -28, 17, 22) }
            };
            totalFrames = 3;
            frameDelay = MiscUtilityClass.SwingFrameTime;
            Physics = marth.Physics;
            Depth = 1;
        }

        public Rectangle BoundingRectangle()
        {
            Rectangle offsetHitbox = hitboxByFrame[frame];
            return new Rectangle((int)Physics.XPosition + offsetHitbox.X, (int)Physics.YPosition + offsetHitbox.Y, offsetHitbox.Width, offsetHitbox.Height);
        }

        public void Update()
        {
            delayCounter++;
            if (delayCounter >= frameDelay)
            {
                delayCounter = 0;
                frame++;
            }
            if (frame >= totalFrames) Game1.GameInstance.GameLevel.RemoveObject(this, false);
        }

        // to implement ISprite
        public void Draw(float x, float y, SpriteBatch spriteBatch, Color tint)
        {
            Draw(spriteBatch);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(SwordSpritesheet, 
                new Rectangle((int)Physics.XPosition - 22, 
                (int)Physics.YPosition - drawHeight, 
                drawWidth, drawHeight), 
                spriteByFrame[frame], 
                Color.White, 
                0f, 
                new Vector2(0, 0), 
                SpriteEffects.None, 
                Depth);
        }

        public Vector2 LaunchDirection()
        {
            float f = (float)(frame * MiscUtilityClass.SwingFrameTime + delayCounter) / (MiscUtilityClass.SwingFrameTime * totalFrames);
            Vector2 result = new Vector2(1, 1);
            result.X = -(float)Math.Cos(f * Math.PI / 2);
            result.Y = -(float)Math.Sin(f * Math.PI / 2);
            return result;
        }

        public bool IsFacingLeft()
        {
            return true;
        }
    }
}
