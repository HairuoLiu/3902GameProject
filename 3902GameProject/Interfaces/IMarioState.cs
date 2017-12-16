using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static _3902GameProject.Classes.Mario;

namespace _3902GameProject.Interfaces
{
    public interface IMarioState
    {
        void TurnLeft();
        void TurnRight();
        void Jump();
        void Crouch();
        void MakeSmall();
        void MakeBig();
        void MakeFire();
        void Damage();
        void MakeDead();
        void MakeStand();
        void MakeRun();
        void MakeWalk();
        void MakeFlag();
        Power PowerLevel();
        bool IsCrouching();
        bool IsJumping();
        bool IsFacingLeft();
        bool IsDead();

        void Update();
        void Draw(float x, float y, SpriteBatch spriteBatch, Color tint);
    }
}
