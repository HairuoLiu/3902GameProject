using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using _3902GameProject.Interfaces;
using static _3902GameProject.Classes.Mario;
using _3902GameProject.Classes.SystemSprites;

namespace _3902GameProject.Classes
{
    public abstract class GenericMarthState : IMarthState
    {
        public ISprite MarthSprite { get; set; }
        public Marth MarthInstance { get; set; }
        protected GenericMarthState(Marth marth)
        {
            MarthInstance = marth;
        }

        public abstract void TurnLeft();
        public abstract void TurnRight();
        public abstract void Jump();
        public abstract void Fall();
        public abstract void Crouch();
        public abstract void MakeDead();
        public abstract void Damage();
        public abstract void MakeStand();
        public abstract void MakeWalk();
        public abstract void MakeSwing();
        public abstract bool IsCrouching();
        public abstract bool IsJumping();
        public abstract bool IsFacingLeft();
        public virtual bool IsDead()
        {
            return false;
        }
        public virtual bool IsSwinging()
        {
            return false;
        }

        public virtual void Update()
        {
            MarthSprite.Update();
        }

        public void Draw(float x, float y, SpriteBatch spriteBatch, Color tint)
        {
            MarthSprite.Draw(x, y, spriteBatch, tint);
        }
    }
}
