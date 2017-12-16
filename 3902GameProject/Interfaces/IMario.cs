using _3902GameProject.Classes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static _3902GameProject.Classes.CollisionHandler;

namespace _3902GameProject.Interfaces
{
    public interface IMario : IPlayer
    {
        //IObjectPhysics Physics { get; }
        IList<IWeapon> Fireballs { get; }
        Boolean CanCollide { get; set; }
        //bool IsDead();
        //void MoveLeft();
        //void MoveRight();
        //void Jump();
        //void ContinueJump();
        //void Crouch();
        //void Stand();
        void MakeSmall();
        void MakeBig();
        void MakeFire();
        //void MakeDead();
        bool IsTall();
        void BumpHead();
        void SetRunning(bool isRunning);
        void SetGroundedState(bool isGrounded);
        void ShootFireball();
        void ShootOrangePortal();
        void ShootBluePortal();
        void MakeFlag();
    }
}
