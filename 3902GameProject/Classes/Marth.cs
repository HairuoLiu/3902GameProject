using _3902GameProject.Classes.SystemSprites;
using _3902GameProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using _3902GameProject.Classes.UtilityClasses;

namespace _3902GameProject.Classes
{
    public class Marth : IMarth
    {
        public Boolean PUp { get; set; }
        public IMarthState State { get; set; }
        public Rectangle OffsetHitbox { get; set; }

        public Color Tint { get; set; }
        public IObjectPhysics Physics { get; set; }
        private MarthActionState actionState;

        public IWeapon Sword { get; }

        private bool isOnGround;
        private int jumpTimer;

        public Marth(float x, float y)
        {
            Tint = Color.White;
            State = new RightWalkingMarthState(this);
            Physics = new ObjectPhysics(x, y, 0.2f, 2, 5);
            actionState = new MarthActionState(this);
            isOnGround = true;
            jumpTimer = 0;
        }

        public Rectangle BoundingRectangle()
        {
            return new Rectangle((int)Physics.XPosition + OffsetHitbox.X, (int)Physics.YPosition + OffsetHitbox.Y, OffsetHitbox.Width, OffsetHitbox.Height);
        }

        public bool IsDead()
        {
            return State.IsDead();
        }

        public void MoveLeft()
        {
            State.TurnLeft();
            if (!State.IsCrouching() &&
                !(isOnGround && State.IsSwinging()))
            {
                Physics.XVelocity = -MiscUtilityClass.MarthWalkSpeed;
                if (!State.IsJumping()) State.MakeWalk();
            }
        }

        public void MoveRight()
        {
            State.TurnRight();
            if (!State.IsCrouching() &&
                !(isOnGround && State.IsSwinging()))
            {
                Physics.XVelocity = MiscUtilityClass.MarthWalkSpeed;
                if (!State.IsJumping()) State.MakeWalk();
            }
        }

        public void Jump()
        {
            if (isOnGround && !State.IsCrouching() && !State.IsSwinging())
            {
                State.Jump();
                Physics.YVelocity = -MiscUtilityClass.MarthJumpInitial;
                jumpTimer = MiscUtilityClass.JumpTimer;
                isOnGround = false;
                SoundControl.PlaySoundEffect(Sound.jumpSmallEffect);
            }
        }

        public void ContinueJump()
        {
            if (jumpTimer > 0)
            {
                jumpTimer--;
                Physics.YVelocity -= MiscUtilityClass.MarthJumpContinue;
            }
        }

        public void EndJump()
        {
            jumpTimer = 0;
        }

        public void BumpHead()
        {
            Physics.YVelocity = Math.Max(0f, Physics.YVelocity);
            jumpTimer = 0;
        }

        public void Crouch()
        {
            State.Crouch();
        }

        public void Stand()
        {
            State.MakeStand();
        }

        public void Damage()
        {
            if (actionState.IsVulnerable())
            {
                Game1 game = Game1.GameInstance;
                game.Scorekeeper.HitPoints--;
                if (game.Scorekeeper.HitPoints > 0)
                {
                    SoundControl.PlaySoundEffect(Sound.pipeEffect);
                }
                else
                {
                    MakeDead();
                    game.Scorekeeper.Lives--;
                    SoundControl.StopSong();
                    SoundControl.PlaySoundEffect(Sound.marioDieEffect);
                }
                State.Damage();
                game.PauseAllButOne((IGameObject)this, MarioUtilityConsts.EndDamageTotal);
                actionState.BeginPause(State.Damage, MarioUtilityConsts.EndDamageTotal);
            }
            actionState.GetHit();
        }

        public void MakeDead()
        {
            State.MakeDead();
        }

        public void SetGroundedState(bool isGrounded)
        {
            bool wasOnGround = isOnGround;
            if (isGrounded && !wasOnGround)
            {
                State.MakeStand();
            }
            else if (!isGrounded && wasOnGround)
            {
                State.Jump();
                State.Update();
            }
            isOnGround = isGrounded;
        }

        public void Update()
        {
            if (State.IsJumping() && isOnGround) State.MakeStand();
            if (Game1.GameInstance.Scorekeeper.Time == 0)
            {
                Game1.GameInstance.Scorekeeper.Lives--;
                MakeDead();
            }
            ICamera camera = Game1.GameInstance.TempCamera;
            int marthWidth = BoundingRectangle().Width;
            if (Physics.XPosition <= camera.XPosition) Physics.XPosition = camera.XPosition;
            if (Physics.XPosition >= camera.XPosition + camera.Width - marthWidth) Physics.XPosition = camera.XPosition + camera.Width - marthWidth;
            if (Physics.YPosition > MarioUtilityConsts.DeathHeight)
            {
                Game1.GameInstance.Scorekeeper.Lives--;
                MakeDead();
            }

            State.Update();
            actionState.Update();
            if (actionState.IsPaused) return;
            Physics.Update();
            if (Math.Abs(Physics.XVelocity) < 0.1f && !State.IsJumping() && !State.IsCrouching())
            {
                State.MakeStand();
            }
            Physics.XVelocity = 0;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            State.Draw(Physics.XPosition, Physics.YPosition, spriteBatch, Tint);
        }

        public void Swing()
        {
            if (!State.IsSwinging())
            {
                State.MakeSwing();
                if (State.IsSwinging())
                {
                    if (State.IsFacingLeft()) Game1.GameInstance.GameLevel.AddObject(new LeftSword(this), false);
                    else Game1.GameInstance.GameLevel.AddObject(new RightSword(this), false);
                }
            }
        }
    }
}
