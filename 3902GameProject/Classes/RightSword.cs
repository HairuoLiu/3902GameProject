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
    public class RightSword : ISword, ISprite
    {
        public Boolean PUp { get; set; }
        public float Depth { get; private set; }
        private int drawWidth = 39;
        private int drawHeight = 29;
        private float upLaunch = 0.9f;
        private float sideLaunch = 0.66f;
        public IObjectPhysics Physics { get; }

        private Texture2D SwordSpritesheet;
        private Dictionary<int, Rectangle> spriteByFrame;
        private Dictionary<int, Rectangle> hitboxByFrame;
        private int frame;
        private int totalFrames;
        private int delayCounter;
        private int frameDelay;

        public RightSword(IMarth marth)
        {
            frame = 0;
            delayCounter = 0;
            SwordSpritesheet = PlayerSpriteFactory.Instance.CreateSword();
            spriteByFrame = new Dictionary<int, Rectangle>
            {
                { 0, new Rectangle(95, 42, drawWidth, drawHeight) },
                { 1, new Rectangle(122, 42, drawWidth, drawHeight) },
                { 2, new Rectangle(122, 42, drawWidth, drawHeight) }
            };
            hitboxByFrame = new Dictionary<int, Rectangle>
            {
                { 0, new Rectangle(17, -20, 14, 16) },
                { 1, new Rectangle(20, -28, 17, 22) },
                { 2, new Rectangle(20, -28, 17, 22) }
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

        public Vector2 LaunchDirection()
        {
            if (frame == 0) return new Vector2((float)Math.Cos(sideLaunch * Math.PI / 2), -(float)Math.Sin(sideLaunch * Math.PI / 2));
            else return new Vector2((float)Math.Cos(upLaunch * Math.PI / 2), -(float)Math.Sin(upLaunch * Math.PI / 2));
        }

        public bool IsFacingLeft()
        {
            return false;
        }
    }
}
