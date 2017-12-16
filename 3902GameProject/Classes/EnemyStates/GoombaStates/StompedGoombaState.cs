using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace _3902GameProject.Classes.EnemyStates
{
    public class StompedGoombaState : GenericEnemyState
    {
        private Goomba goombaInstance;
        public StompedGoombaState(Goomba goomba)
        {
            goombaInstance = goomba;
            goombaInstance.OffsetHitbox = Hitboxes.DeadGoombaHitbox();
            Sprite = Classes.EnemySpriteFactory.Instance.StompedGoomba();
        }

        public override void ChangeMovementToLeft()
        {
        }

        public override void ChangeMovementToRight()
        {
        }

        public override void MakeStomped()
        {
        }

        public override void MakeFlipped()
        {
        }
    }
}
