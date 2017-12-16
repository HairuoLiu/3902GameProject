using _3902GameProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace _3902GameProject.Classes
{
    public class MarioActionState
    {
        private IMario marioInstance;

        private bool isOnGround;
        public bool IsOnGround
        {
            get
            {
                return isOnGround;
            }
            set
            {
                if (value && !isOnGround)
                {
                    CanStartJump = true;
                    Game1.GameInstance.Scorekeeper.ResetEnemyMultiplier();
                }
                else if (!value && isOnGround)
                {
                    CanStartJump = false;
                }
                isOnGround = value;
            }
        }
        public bool IsRunning { get; private set; }
        public bool CanStartJump { get; private set; }
        public bool CanContinueJump { get; private set; }
        public bool IsPaused
        {
            get
            {
                return pauseTimer > 0;
            }
        }
        private bool continueJump;
        private int jumpContinueTimer;
        private int hitTimer;
        private int pauseTimer;
        private int pauseTimerTotal;
        Action f;

        public MarioActionState(IMario mario)
        {
            marioInstance = mario;
            hitTimer = 0;
            jumpContinueTimer = 0;
            pauseTimer = 0;
            continueJump = false;
            isOnGround = true;
            CanStartJump = true;
            CanContinueJump = false;
            IsRunning = false;
        }

        public void BeginPause(Action func, int pauseLength)
        {
            f = func;
            pauseTimer = 1;
            pauseTimerTotal = pauseLength;
        }

        public void GetHit()
        {
            if (hitTimer <= 0)
                hitTimer = UtilityClasses.MiscUtilityClass.HitTimer;
        }

        public bool IsVulnerable()
        {
            return hitTimer == 0;
        }

        public void Jump()
        {
            IsOnGround = false;
            CanContinueJump = true;
            continueJump = true;
            jumpContinueTimer = UtilityClasses.MiscUtilityClass.JumpTimer;
        }

        public void ContinueJump()
        {
            continueJump = true;
        }

        public void EndJump()
        {
            jumpContinueTimer = 0;
            continueJump = false;
            CanContinueJump = false;
        }

        public void Update()
        {
            if (pauseTimer >= pauseTimerTotal - 1)
            {
                f?.Invoke();
                pauseTimer = 0;
            }
            if (pauseTimer > 0)
            {
                pauseTimer++;
                return;
            }

            if (hitTimer > 0)
            {
                hitTimer--;
                if (hitTimer % UtilityClasses.MiscUtilityClass.Even == 1)
                    marioInstance.Tint = Color.Transparent;
                else
                    marioInstance.Tint = Color.White;
            }

            if (jumpContinueTimer > 0)
                jumpContinueTimer--;

            if (!continueJump)
                jumpContinueTimer = 0;
            continueJump = false;

            if (jumpContinueTimer <= 0)
                CanContinueJump = false;

            if (Math.Abs(marioInstance.Physics.XVelocity) > UtilityClasses.MiscUtilityClass.RunningVel)
                IsRunning = true;
            else
                IsRunning = false;

            if (isOnGround)
            {
                marioInstance.Physics.Gravity = 0;
                marioInstance.Physics.DampenSpeed(UtilityClasses.MiscUtilityClass.SmallDamp, 0);
            }
            else
            {
                marioInstance.Physics.Gravity = UtilityClasses.MiscUtilityClass.Grav;
                marioInstance.Physics.DampenSpeed(UtilityClasses.MiscUtilityClass.LargeDamp, 0);
            }
        }
    }
}