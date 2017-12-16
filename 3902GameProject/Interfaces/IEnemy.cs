using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static _3902GameProject.Classes.CollisionGeneral;

namespace _3902GameProject.Interfaces
{
    public interface IEnemy : IGameObject
    {
        float Gravity { get; set; }
        bool Stomped { get; set; }
        float XPosition { get; set; }
        float YPosition { get; set; }
        float XVelocity { get; set; }
        float YVelocity { get; set; }
        bool IsDead { get; }
        void MakeStomped();
        void MakeFlipped(bool flipToLeft);
        void MakeFlipped(Vector2 flipDirection);
    }
}
