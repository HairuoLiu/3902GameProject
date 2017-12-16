using Microsoft.Xna.Framework;


namespace _3902GameProject.Interfaces
{
    public interface IPlayer : IGameObject
    {
        IObjectPhysics Physics { get; }
        Color Tint { get; set; }
        bool IsDead();
        void MoveLeft();
        void MoveRight();
        void Jump();
        void Stand();
        void Crouch();
        void ContinueJump();
        void EndJump();
        void Damage();
        void MakeDead();
    }
}
