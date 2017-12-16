using _3902GameProject.Classes.UtilityClasses;
using _3902GameProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3902GameProject.Classes.Portals
{
    public abstract class GenericPortal : IPortal
    {
        public Boolean Left { get; set; }
        public Boolean PUp { get; set; }
        public float Vel { get; set; }
        public Boolean Ball { get; set; }
        public int DrawHeight { get; set; }
        public int DrawWidth { get; set; }
        public Boolean PortalO { get; set; }
        public float PosX { get; set; }
        public float PosY { get; set; }
        public Boolean Gun { get; set; }
        public Boolean Orange { get; set; }
        public int TotalFrames { get; set; }
        protected Texture2D PortalSpritesheet { get; private set;}
        protected Dictionary<int, Rectangle> SpriteByFrame { get; private set; }
        public float Depth { get; private set; }

        protected GenericPortal(Texture2D spritesheet)
        {
            DrawHeight = SpriteUtilityConsts.BigSprite;
            DrawWidth = SpriteUtilityConsts.SpecialH;
            PortalSpritesheet = spritesheet;
            SpriteByFrame = new Dictionary<int, Rectangle>();
            Depth = 1f;
            PosX = 0;
            PosY = 0;
            PortalO = false;
        }
        public Rectangle BoundingRectangle()
        {
            return new Rectangle((int)PosX, (int)PosY - DrawHeight + 1, DrawWidth, DrawHeight);
        }

        public void Update()
        {
            if (PUp)
            {
                PosX = Game1.GameInstance.GameLevel.GetPlayer(0).BoundingRectangle().Center.X - SpriteUtilityConsts.TinyGap;
                if(Game1.GameInstance.GameLevel.GetPlayer(0).BoundingRectangle().Height > SpriteUtilityConsts.SmallSprite)
                {
                    PosY = Game1.GameInstance.GameLevel.GetPlayer(0).BoundingRectangle().Center.Y + SpriteUtilityConsts.TinyGap;
                }
                else
                {
                    PosY = Game1.GameInstance.GameLevel.GetPlayer(0).BoundingRectangle().Center.Y + SpriteUtilityConsts.TiniestGap;
                }
                Flip(this);
            }
            else if (Ball)
            {
                PosX = PosX + Vel;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(PortalSpritesheet,
                new Rectangle((int)PosX, (int)PosY - DrawHeight, DrawWidth, DrawHeight),
                SpriteByFrame[0],
                Color.White,
                0f,
                new Vector2(0, 0),
                SpriteEffects.None,
                Depth);
        }

        private static void Flip(IPortal portal)
        {
            IPortal newPortal = null;
            Mario mario = (Mario)Game1.GameInstance.GameLevel.GetPlayer(0);
            if (mario.State.IsFacingLeft())
            {
                if(!(portal is PortalGunFlipped))
                {
                    newPortal = PortalSpriteFactory.Instance.CreateFlippedPortalGun(portal.BoundingRectangle().X, portal.BoundingRectangle().Y);
                    newPortal.PUp = true;
                    Game1.GameInstance.GameLevel.StaticObjects.Add(newPortal);
                    Game1.GameInstance.GameLevel.StaticObjects.Remove(portal);
                }
            }
            else if (!mario.State.IsFacingLeft())
            {
                if (portal is PortalGunFlipped)
                {
                    newPortal = PortalSpriteFactory.Instance.CreatePortalGun(portal.BoundingRectangle().X, portal.BoundingRectangle().Y);
                    newPortal.PUp = true;
                    Game1.GameInstance.GameLevel.StaticObjects.Add(newPortal);
                    Game1.GameInstance.GameLevel.StaticObjects.Remove(portal);
                }
            }
        }
    }
}
