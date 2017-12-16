using _3902GameProject.Classes.EnemyStates;
using _3902GameProject.Classes.UtilityClasses;
using _3902GameProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace _3902GameProject.Classes
{
    public class Turtle : IEnemy
    {
        public Boolean PUp { get; set; }
        public IEnemyState State { get; set; }
        public Rectangle OffsetHitbox { get; set; }
        public float XPosition { get; set; }
        public float YPosition { get; set; }
        public float XVelocity { get; set; }
        public float YVelocity { get; set; }
        public bool Stomped { get; set; }
        public float Gravity { get; set; }
        public bool IsDead { get; protected set; }
        private bool awake = false;

        public Turtle(float x, float y)
        {
            XPosition = x;
            YPosition = y;
            XVelocity = 0f;
            YVelocity = UtilityClasses.TurtleUtilityClass.InitVel;
            IsDead = false;
            State = new LeftWalkingTurtleState(this);
        }

        public void WakeUp()
        {
            XVelocity = -1f;
            YVelocity = UtilityClasses.TurtleUtilityClass.InitVel;
            awake = true;
        }

        public Rectangle BoundingRectangle()
        {
            return new Rectangle((int)XPosition + OffsetHitbox.X, (int)YPosition + OffsetHitbox.Y, OffsetHitbox.Width, OffsetHitbox.Height);
        }

        public void MakeStomped()
        {
            State.MakeStomped();
            Stomped = true;
            XVelocity = 0;
            YVelocity = 0;
        }

        public void MakeFlipped(bool flipToLeft)
        {
            State.MakeFlipped();
            YVelocity = -TurtleUtilityClass.FlippedYVel;
            if (flipToLeft)
                XVelocity = -TurtleUtilityClass.FlippedXVel;
            else
                XVelocity = TurtleUtilityClass.FlippedXVel;
            Gravity = TurtleUtilityClass.TurtleGrav;
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
            float marioX = Game1.GameInstance.GameLevel.GetPlayer(0).BoundingRectangle().X; // Should be refactored to use camera somehow.
            if (!awake && (marioX + UtilityClasses.TurtleUtilityClass.WakeUpDist > XPosition && marioX - UtilityClasses.TurtleUtilityClass.WakeUpDist < XPosition))
                WakeUp();
            XPosition += XVelocity;
            YPosition += YVelocity;
            YVelocity += Gravity;
            State.Update();
            if (YVelocity > UtilityClasses.TurtleUtilityClass.FlippedYVel)
                YVelocity = UtilityClasses.TurtleUtilityClass.FlippedYVel;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            State.Draw(XPosition, YPosition - UtilityClasses.SpriteUtilityConsts.MedSprite, spriteBatch);
        }
    }
}
