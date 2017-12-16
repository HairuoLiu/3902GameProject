using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using _3902GameProject.Interfaces;

namespace _3902GameProject.Classes.EnemyStates
{
    public abstract class GenericEnemyState : IEnemyState
    {
        protected ISprite Sprite { get; set; }
        protected GenericEnemyState()
        {
        }

        public abstract void ChangeMovementToLeft();

        public abstract void ChangeMovementToRight();

        public abstract void MakeStomped();

        public abstract void MakeFlipped();

        public void Update()
        {
            Sprite.Update();
        }

        public void Draw(float x, float y, SpriteBatch spriteBatch)
        {
            Sprite.Draw(x, y, spriteBatch, Color.White);
        }
    }
}
