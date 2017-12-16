using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3902GameProject.Interfaces
{
    public interface ISword : IWeapon
    {
        Vector2 LaunchDirection();
        bool IsFacingLeft();
    }
}
