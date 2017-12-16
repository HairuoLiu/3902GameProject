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
    public interface IMarth : IPlayer
    {
        IWeapon Sword { get; }

        void BumpHead();
        void SetGroundedState(bool isGrounded);
        void Swing();
    }
}
