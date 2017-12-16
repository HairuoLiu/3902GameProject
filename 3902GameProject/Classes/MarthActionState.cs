using _3902GameProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace _3902GameProject.Classes
{
    public class MarthActionState
    {
        private IMarth marthInstance;

        public bool IsRunning { get; private set; }
        public bool IsPaused
        {
            get
            {
                return pauseTimer > 0;
            }
        }
        private int hitTimer;
        private int pauseTimer;
        private int pauseTimerTotal;
        Action f;

        public MarthActionState(IMarth marth)
        {
            marthInstance = marth;
            hitTimer = 0;
            pauseTimer = 0;
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

        public void Update()
        {
            if (hitTimer > 0)
            {
                hitTimer--;
                if (hitTimer % UtilityClasses.MiscUtilityClass.Even == 1)
                    marthInstance.Tint = Color.Transparent;
                else
                    marthInstance.Tint = Color.White;
            }
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
        }
    }
}