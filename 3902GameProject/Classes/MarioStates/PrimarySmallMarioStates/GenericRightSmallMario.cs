using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _3902GameProject.Classes
{
    public abstract class GenericRightSmallMarioState : GenericSmallMarioState
    {
        protected GenericRightSmallMarioState(Mario mario) : base(mario)
        {
        }

        public override void TurnRight()
        {
        }
        public override void Jump()
        {
            MarioInstance.State = new RightJumpingSmallMarioState(MarioInstance);
        }
        public override void Crouch()
        {
            MarioInstance.State = new RightCrouchingSmallMarioState(MarioInstance);
        }
        public override void MakeStand()
        {
            MarioInstance.State = new RightIdleSmallMarioState(MarioInstance);
        }
        public override void MakeRun()
        {
            MarioInstance.State = new RightRunningSmallMarioState(MarioInstance);
        }
        public override void MakeWalk()
        {
            MarioInstance.State = new RightWalkingSmallMarioState(MarioInstance);
        }
        public override bool IsFacingLeft()
        {
            return false;
        }
    }
}
