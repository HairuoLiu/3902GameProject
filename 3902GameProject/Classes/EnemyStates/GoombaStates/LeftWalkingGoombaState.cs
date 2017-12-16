using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace _3902GameProject.Classes.EnemyStates
{
    public class LeftWalkingGoombaState : GenericEnemyState
    {
        private Goomba goombaInstance;
        public LeftWalkingGoombaState(Goomba goomba)
        {
            goombaInstance = goomba;
            goombaInstance.OffsetHitbox = Hitboxes.WalkingGoombaHitbox();
            Sprite = Classes.EnemySpriteFactory.Instance.CreateGoomba();
        }

        public override void ChangeMovementToLeft()
        {
        }

        public override void ChangeMovementToRight()
        {
            goombaInstance.State = new RightWalkingGoombaState(goombaInstance);
        }

        public override void MakeStomped()
        {
            goombaInstance.State = new StompedGoombaState(goombaInstance);
        }

        public override void MakeFlipped()
        {
            goombaInstance.State = new FlippedGoombaState(goombaInstance);
        }
    }
}
