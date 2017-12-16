using _3902GameProject.Classes.EnemyStates;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _3902GameProject.Interfaces;
using _3902GameProject.Classes.UtilityClasses;

namespace _3902GameProject.Classes
{
    public class Goomba : IEnemy
    {
        public Boolean PUp { get; set; }
        public IEnemyState State { get; set; }
        public Rectangle OffsetHitbox { get; set; }
        public float XPosition { get; set; }
        public float YPosition { get; set; }
        public float XVelocity { get; set; }
        public float YVelocity { get; set; }
        public bool IsDead { get; protected set; }
        public float Gravity { get; set; }
        public bool Stomped { get; set; }
        private int removeBody;
        private int removeBodyTimer = GoombaUtilityConsts.RemoveBodyTotal;
        private bool awake = false;

        public Goomba(float x, float y)
        {
            removeBody = removeBodyTimer;
            XPosition = x;
            YPosition = y;
            XVelocity = 0;
            YVelocity = 0;
            Gravity = 0;
            IsDead = false;
            Stomped = false;
            State = new LeftWalkingGoombaState(this);
        }

        public void WakeUp()
        {
            XVelocity = -GoombaUtilityConsts.XSpeed;
            YVelocity = GoombaUtilityConsts.YSpeed;
            awake = true;
        }

        public Rectangle BoundingRectangle()
        {
            return new Rectangle((int)XPosition + OffsetHitbox.X, (int)YPosition + OffsetHitbox.Y, OffsetHitbox.Width, OffsetHitbox.Height);
        }

        public void MakeStomped()
        {
            if (removeBody == removeBodyTimer) removeBody--;
            State.MakeStomped();
            IsDead = true;
            Stomped = true;
        }

        public void MakeFlipped(bool flipToLeft)
        {
            State.MakeFlipped();
            YVelocity = -GoombaUtilityConsts.YFlipSpeed;
            if (flipToLeft)
                XVelocity = -GoombaUtilityConsts.XFlipSpeed;
            else
                XVelocity = GoombaUtilityConsts.XFlipSpeed;
            Gravity = GoombaUtilityConsts.FlipGravity;
            IsDead = true;
        }

        public void MakeFlipped(Vector2 flipDirection)
        {
            State.MakeFlipped();
            float flipMagnitude = MiscUtilityClass.SwingLaunchMagnitude;
            XVelocity = flipDirection.X * flipMagnitude;
            YVelocity = flipDirection.Y * flipMagnitude;
            Gravity = MiscUtilityClass.SwingGravity;
            IsDead = true;
        }

        public void ChangeMovementToLeft()
        {
            State.ChangeMovementToLeft();
        }

        public void ChangeMovementToRight()
        {
            State.ChangeMovementToRight();
        }

        public void Update()
        {
            State.Update();
            if (Stomped)
            {
                XVelocity = 0;
                YVelocity = 0;
            }
            if (removeBody < removeBodyTimer)
                removeBody--;
            if (removeBody <= 0)
                RemoveGoomba();
            if (!awake && (Game1.GameInstance.GameLevel.GetPlayer(0).BoundingRectangle().X + GoombaUtilityConsts.WakeOffset > XPosition && Game1.GameInstance.GameLevel.GetPlayer(0).BoundingRectangle().X - GoombaUtilityConsts.WakeOffset < XPosition))
                WakeUp();
            XPosition += XVelocity;
            YPosition += YVelocity;
            YVelocity += Gravity;
            if (YVelocity > GoombaUtilityConsts.YFlipSpeed)
                YVelocity = GoombaUtilityConsts.YFlipSpeed;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            State.Draw(XPosition, YPosition - GoombaUtilityConsts.Height, spriteBatch);
        }

        public void RemoveGoomba()
        {
            Game1.GameInstance.GameLevel.RemoveObject(this, false);
        }
    }
}
