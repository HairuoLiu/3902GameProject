using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _3902GameProject.Classes
{
    public abstract class GenericRightBigMarioState : GenericBigMarioState
    {
        protected GenericRightBigMarioState(Mario mario) : base(mario)
        {
        }

        public override void TurnRight()
        {
        }
        public override void Jump()
        {
            MarioInstance.State = new RightJumpingBigMarioState(MarioInstance);
        }
        public override void Crouch()
        {
            MarioInstance.State = new RightCrouchingBigMarioState(MarioInstance);
        }
        public override void MakeStand()
        {
            MarioInstance.State = new RightIdleBigMarioState(MarioInstance);
        }
        public override void MakeRun()
        {
            MarioInstance.State = new RightRunningBigMarioState(MarioInstance);
        }
        public override void MakeWalk()
        {
            MarioInstance.State = new RightWalkingBigMarioState(MarioInstance);
        }
        public override bool IsFacingLeft()
        {
            return false;
        }
    }
}
