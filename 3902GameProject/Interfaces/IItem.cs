using _3902GameProject.Classes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3902GameProject.Interfaces
{
    public interface IItem : IGameObject
    {
        ItemData ItemInfo { get; set; }
    }
}
