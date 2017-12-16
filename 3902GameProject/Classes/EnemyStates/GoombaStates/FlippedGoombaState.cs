using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace _3902GameProject.Classes.EnemyStates
{
    public class FlippedGoombaState : GenericEnemyState
    {
        private Goomba goombaInstance;
        public FlippedGoombaState(Goomba goomba)
        {
            goombaInstance = goomba;
            goombaInstance.OffsetHitbox = Hitboxes.DeadGoombaHitbox();
            Sprite = Classes.EnemySpriteFactory.Instance.FlippedGoomba();
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
