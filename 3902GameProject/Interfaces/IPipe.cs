using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3902GameProject.Interfaces
{
    public interface IPipe : IGameObject
    {
        void Enter();
        Boolean Psg { get; set; }
    }
}
