using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace _3902GameProject.Classes.EnemyStates
{
    public class DeadTurtleState : GenericEnemyState
    {
        private Turtle turtleInstance;
        public DeadTurtleState(Turtle turtle)
        {
            turtleInstance = turtle;
            turtleInstance.OffsetHitbox = Hitboxes.KoopaShellHitbox();
            Sprite = Classes.EnemySpriteFactory.Instance.CreateDeadTurtle();
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
