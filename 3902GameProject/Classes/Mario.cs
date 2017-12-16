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
using _3902GameProject.Classes.Portals;

namespace _3902GameProject.Classes
{
    public class Mario : IMario
    {
        public Boolean PUp { get; set; }
        public enum Power
        {
            None,
            Big,
            Fire
        };

        public Boolean CanCollide { get; set; }
        public IMarioState State { get; set; }
        public Rectangle OffsetHitbox { get; set; }
        private MarioActionState actionState;
        public Boolean PortalMode {get; set; }


        public Color Tint { get; set; }
        public IObjectPhysics Physics { get; set; }

        private bool releaseCrouchOnLand;

        public IList<IWeapon> Fireballs { get; }
        public int EndDamageTimer { get; set; }
        private int endDamageTotal = MarioUtilityConsts.EndDamageTotal;

        public Mario(float x, float y)
        {
            Tint = Color.White;
            State = new RightIdleSmallMarioState(this);
            Physics = new ObjectPhysics(x, y, MarioUtilityConsts.Gravity, MarioUtilityConsts.MaxXSpeed, MarioUtilityConsts.MaxYSpeed);
            actionState = new MarioActionState(this);
            releaseCrouchOnLand = false;
            Fireballs = new List<IWeapon>();
            EndDamageTimer = 0;
            CanCollide = true;
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
            if (!(actionState.IsOnGround && State.IsCrouching()))
            {
                Physics.XVelocity += -MarioUtilityConsts.WalkAcceleration;
            }
            if (actionState.IsOnGround)
            {
                State.TurnLeft();
                if (actionState.IsRunning) State.MakeRun();
                else State.MakeWalk();
            }
        }

        public void MoveRight()
        {
            if (!(actionState.IsOnGround && State.IsCrouching()))
            {
                Physics.XVelocity += MarioUtilityConsts.WalkAcceleration;
            }
            if (actionState.IsOnGround)
            {
                State.TurnRight();
                if (actionState.IsRunning) State.MakeRun();
                else State.MakeWalk();
            }
        }

        public void Jump()
        {
            if (actionState.CanStartJump)
            {
                Physics.YVelocity = -MarioUtilityConsts.JumpBase - Math.Abs(Physics.XVelocity) / MarioUtilityConsts.JumpScale;
                actionState.Jump();
                State.Jump();
                SoundControl.PlaySoundEffect(Sound.jumpSmallEffect);
            }
        }

        public void ContinueJump()
        {
            if (actionState.CanContinueJump)
            {
                actionState.ContinueJump();
                Physics.YVelocity = -MarioUtilityConsts.JumpBase - Math.Abs(Physics.XVelocity) / MarioUtilityConsts.JumpScale;
            }
        }

        public void EndJump()
        {
            // TODO
        }

        public void BumpHead()
        {
            actionState.EndJump();
        }

        public void Crouch()
        {
            if (actionState.IsOnGround)
            {
                State.Crouch();
            }
            releaseCrouchOnLand = false;
        }

        public void Stand()
        {
            if (actionState.IsOnGround)
            {
                State.MakeStand();
            }
            else
            {
                releaseCrouchOnLand = true;
            }
        }

        public void MakeSmall()
        {
            State.MakeSmall();
        }

        public void MakeBig()
        {
            if (State.PowerLevel() == Power.None)
            {
                State.MakeBig();
                actionState.BeginPause(State.Damage, endDamageTotal);
                Game1.GameInstance.PauseAllButOne(this, endDamageTotal);
            }
        }

        public void MakeFire()
        {
            if (State.PowerLevel() != Power.Fire)
            {
                State.MakeFire();
                actionState.BeginPause(State.Damage, endDamageTotal);
                Game1.GameInstance.PauseAllButOne(this, endDamageTotal);
            }
        }

        public void MakeDead()
        {
            State.MakeDead();
        }

        public void Damage()
        {
            if (actionState.IsVulnerable())
            {
                if (State.PowerLevel().Equals(Power.None))
                {
                    SoundControl.StopSong();
                    SoundControl.PlaySoundEffect(Sound.marioDieEffect);
                    Game1.GameInstance.Scorekeeper.Lives--;
                }
                else
                {
                    SoundControl.PlaySoundEffect(Sound.pipeEffect);
                }
                State.Damage();
                Game1.GameInstance.PauseAllButOne((IGameObject)this, endDamageTotal);
                actionState.BeginPause(State.Damage, endDamageTotal);
            }
            actionState.GetHit();
        }

        public bool IsTall()
        {
            return !(State.PowerLevel() == Power.None);
        }

        public void MakeFlag()
        {
            State.MakeFlag();
        }

        public void SetGroundedState(bool isGrounded)
        {
            bool wasGrounded = actionState.IsOnGround;
            if (isGrounded && !wasGrounded && (!State.IsCrouching() || releaseCrouchOnLand))
            {
                State.MakeStand();
            }
            else if (!isGrounded && wasGrounded)
            {
                State.Jump();
            }
            actionState.IsOnGround = isGrounded;
        }

        public void SetRunning(bool isRunning)
        {
            if (isRunning)
                Physics.MaxXSpeed = MarioUtilityConsts.MaxXSpeedRun;
            else
                Physics.MaxXSpeed = MarioUtilityConsts.MaxXSpeed;
        }

        public void Update()
        {
            if (!IsDead())
            {
                if (Game1.GameInstance.Scorekeeper.Time == 0)
                {
                    Game1.GameInstance.Scorekeeper.Lives--;
                    MakeDead();
                }

                ICamera camera = Game1.GameInstance.TempCamera;
                int marioWidth = BoundingRectangle().Width;
                if (Physics.XPosition <= camera.XPosition) Physics.XPosition = camera.XPosition;
                if (Physics.XPosition >= camera.XPosition + camera.Width - marioWidth) Physics.XPosition = camera.XPosition + camera.Width - marioWidth;
                if (Physics.YPosition > MarioUtilityConsts.DeathHeight)
                {
                    Game1.GameInstance.Scorekeeper.Lives--;
                    MakeDead();
                }

                State.Update();

                actionState.Update();
                if (actionState.IsPaused) return;

                Physics.Update();

                if (Math.Abs(Physics.XVelocity) < MarioUtilityConsts.Tolerance && actionState.IsOnGround && !State.IsCrouching())
                    State.MakeStand();

                foreach (IWeapon f in Fireballs.ToArray())
                    f.Update();
            }
            else
            {
                Physics.Update();
                State.Update();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            State.Draw(Physics.XPosition, Physics.YPosition, spriteBatch, Tint);
            foreach (IWeapon f in Fireballs)
                f.Draw(spriteBatch);
        }

        public void ShootFireball()
        {
            if (State.PowerLevel() == Power.Fire && Fireballs.Count < MarioUtilityConsts.MaxFireballs)
            {
                if (State.IsFacingLeft())
                {
                    SoundControl.PlaySoundEffect(Sound.fireballEffect);
                    State = new LeftThrowingFireMarioState(this, MarioUtilityConsts.ThrowTimer);   
                }
                else
                {
                    SoundControl.PlaySoundEffect(Sound.fireballEffect);
                    State = new RightThrowingFireMarioState(this, MarioUtilityConsts.ThrowTimer);
                }
                Fireballs.Add(new Fireball(this, State.IsFacingLeft()));
            }
        }

        public void ShootOrangePortal()
        {
            if (PortalMode)
            {
                if (State.IsFacingLeft())
                {
                    Game1.GameInstance.GameLevel.AddObject(PortalSpriteFactory.Instance.CreatePortalOrangeBall((int)Physics.XPosition - SpriteUtilityConsts.TiniestGap, BoundingRectangle().Center.Y + SpriteUtilityConsts.TinyGap, -SpriteUtilityConsts.BallVel), false);
                }
                else
                {
                    Game1.GameInstance.GameLevel.AddObject(PortalSpriteFactory.Instance.CreatePortalOrangeBall((int)Physics.XPosition + SpriteUtilityConsts.SmallSprite, BoundingRectangle().Center.Y + SpriteUtilityConsts.TinyGap, SpriteUtilityConsts.BallVel), false);
                }
            }
        }
        public void ShootBluePortal()
        {
            if (PortalMode)
            {
                if (State.IsFacingLeft())
                {
                    Game1.GameInstance.GameLevel.AddObject(PortalSpriteFactory.Instance.CreatePortalBlueBall((int)Physics.XPosition - SpriteUtilityConsts.TiniestGap, BoundingRectangle().Center.Y + SpriteUtilityConsts.TinyGap, -SpriteUtilityConsts.BallVel), false);
                }
                else
                {
                    Game1.GameInstance.GameLevel.AddObject(PortalSpriteFactory.Instance.CreatePortalBlueBall((int)Physics.XPosition + SpriteUtilityConsts.SmallSprite, BoundingRectangle().Center.Y + SpriteUtilityConsts.TinyGap, SpriteUtilityConsts.BallVel), false);
                }
            }
        }
    }
}
