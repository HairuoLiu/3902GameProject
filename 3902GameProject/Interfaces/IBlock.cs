using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static _3902GameProject.Classes.CollisionGeneral;

namespace _3902GameProject.Interfaces
{
    public interface IBlock : IGameObject
    {
        bool IsVisible { get; }
        bool IsBouncing { get; }
        void PunchFromBelow(IPlayer player);
        void CollisionWithPlayer(CollisionDirection dir, IPlayer collidingPlayer);
    }
}
