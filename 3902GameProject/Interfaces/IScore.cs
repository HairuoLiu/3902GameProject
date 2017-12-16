using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static _3902GameProject.Classes.CollisionGeneral;

namespace _3902GameProject.Interfaces
{
    public interface IScore
    {
        int Time { get; set; }
        string Level { get; set; }
        int Coins { get; set; }
        int Points { get; set; }
        int Lives { get; set; }
        int HitPoints { get; set; }
        void Update();
        void KillEnemy(IEnemy enemy, bool wasJump);
        void ResetEnemyMultiplier();
        void CollectItem(IItem item);
        void GetFlag(float percentHeight);
        void ResetTime();
    }
}
