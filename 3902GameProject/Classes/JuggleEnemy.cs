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
    public class JuggleEnemy : IEnemy
    {
        IEnemy baseEnemy;
        public Boolean PUp { get; set; }
        public int HitTimer { get; set; }
        public float XPosition
        {
            get
            {
                return baseEnemy.XPosition;
            }
            set
            {
                baseEnemy.XPosition = value;
            }
        }
        public float YPosition
        {
            get
            {
                return baseEnemy.YPosition;
            }
            set
            {
                baseEnemy.YPosition = value;
            }
        }
        public float XVelocity
        {
            get
            {
                return baseEnemy.XVelocity;
            }
            set
            {
                baseEnemy.XVelocity = value;
            }
        }
        public float YVelocity
        {
            get
            {
                return baseEnemy.YVelocity;
            }
            set
            {
                baseEnemy.YVelocity = value;
            }
        }
        public bool IsDead
        {
            get
            {
                return baseEnemy.IsDead;
            }
        }
        public float Gravity
        {
            get
            {
                return baseEnemy.Gravity;
            }
            set
            {
                baseEnemy.Gravity = value;
            }
        }
        public bool Stomped
        {
            get
            {
                return baseEnemy.Stomped;
            }
            set
            {
                baseEnemy.Stomped = value;
            }
        }

        public JuggleEnemy(IEnemy enemy)
        {
            baseEnemy = enemy;
            HitTimer = 0;
        }

        public Rectangle BoundingRectangle()
        {
            if (HitTimer > 0) return new Rectangle(0, 0, 0, 0);
            else return baseEnemy.BoundingRectangle();
        }

        public void MakeStomped()
        {
            baseEnemy.MakeStomped();
        }

        public void MakeFlipped(bool flipToLeft)
        {
            baseEnemy.MakeFlipped(flipToLeft);
        }

        public void MakeFlipped(Vector2 flipDirection)
        {
            baseEnemy.MakeFlipped(flipDirection);
        }

        public void Update()
        {
            if (HitTimer > 0) HitTimer--;
            baseEnemy.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            baseEnemy.Draw(spriteBatch);
        }
    }
}
