using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static _3902GameProject.Classes.Mario;

namespace _3902GameProject.Interfaces
{
    public interface IMarthState
    {
        void TurnLeft();
        void TurnRight();
        void Jump();
        void Fall();
        void Crouch();
        void MakeDead();
        void Damage();
        void MakeStand();
        void MakeWalk();
        void MakeSwing();
        bool IsCrouching();
        bool IsJumping();
        bool IsFacingLeft();
        bool IsSwinging();
        bool IsDead();

        void Update();
        void Draw(float x, float y, SpriteBatch spriteBatch, Color tint);
    }
}
