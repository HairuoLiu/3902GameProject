using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using _3902GameProject.Interfaces;
using static _3902GameProject.Classes.Mario;
using _3902GameProject.Classes.SystemSprites;

namespace _3902GameProject.Classes
{
    public abstract class GenericMarioState : IMarioState
    {
        public Interfaces.ISprite MarioSprite { get; set; }
        public Mario MarioInstance { get; set; }
        protected GenericMarioState(Mario mario)
        {
            MarioInstance = mario;
        }

        public abstract void TurnLeft();
        public abstract void TurnRight();
        public abstract void Jump();
        public abstract void Crouch();
        public abstract void MakeSmall();
        public abstract void MakeBig();
        public abstract void MakeFire();
        public abstract void Damage();
        public virtual void MakeDead()
        {
            MarioInstance.State = new DeadMarioState(MarioInstance);
        }
        public abstract void MakeStand();
        public abstract void MakeRun();
        public abstract void MakeWalk();
        public abstract void MakeFlag();
        public abstract Power PowerLevel();
        public abstract bool IsCrouching();
        public abstract bool IsJumping();
        public abstract bool IsFacingLeft();
        public virtual bool IsDead()
        {
            return false;
        }

        public virtual void Update()
        {
            MarioSprite.Update();
        }

        public void Draw(float x, float y, SpriteBatch spriteBatch, Color tint)
        {
            MarioSprite.Draw(x, y, spriteBatch, tint);
        }
    }
}
