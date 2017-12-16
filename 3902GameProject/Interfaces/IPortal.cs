using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _3902GameProject.Interfaces
{
    public interface IPortal :IGameObject
    {
        Boolean Left { get; set; }
        Boolean Gun { get; set; }
        Boolean Ball { get; set; }
    }
}
