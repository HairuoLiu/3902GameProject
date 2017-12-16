using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace _3902GameProject.Classes.EnemyStates
{
    public class LeftWalkingTurtleState : GenericEnemyState
    {
        private Turtle turtleInstance;
        public LeftWalkingTurtleState(Turtle turtle)
        {
            turtleInstance = turtle;
            turtleInstance.OffsetHitbox = Hitboxes.WalkingKoopaHitbox();
            Sprite = Classes.EnemySpriteFactory.Instance.CreateLeftWalkingTurtle();
        }

        public override void ChangeMovementToLeft()
        {
        }

        public override void ChangeMovementToRight()
        {
            turtleInstance.State = new RightWalkingTurtleState(turtleInstance);
        }

        public override void MakeStomped()
        {
            turtleInstance.State = new DeadTurtleState(turtleInstance);
        }

        public override void MakeFlipped()
        {
            turtleInstance.State = new FlippedTurtleState(turtleInstance);
        }
    }
}
