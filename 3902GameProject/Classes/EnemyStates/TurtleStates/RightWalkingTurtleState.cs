using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using _3902GameProject.Interfaces;

namespace _3902GameProject.Classes.EnemyStates
{
    public class RightWalkingTurtleState : GenericEnemyState
    {
        private Turtle turtleInstance;
        public RightWalkingTurtleState(Turtle turtle)
        {
            turtleInstance = turtle;
            turtleInstance.OffsetHitbox = Hitboxes.WalkingKoopaHitbox();
            Sprite = Classes.EnemySpriteFactory.Instance.CreateRightWalkingTurtle();
        }

        public override void ChangeMovementToLeft()
        {
            turtleInstance.State = new LeftWalkingTurtleState(turtleInstance);
        }

        public override void ChangeMovementToRight()
        {
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
