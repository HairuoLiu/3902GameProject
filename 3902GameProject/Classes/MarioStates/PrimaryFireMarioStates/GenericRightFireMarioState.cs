using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _3902GameProject.Classes
{
    public abstract class GenericRightFireMarioState : GenericFireMarioState
    {
        protected GenericRightFireMarioState(Mario mario) : base(mario)
        {
        }

        public override void TurnRight()
        {
        }
        public override void Jump()
        {
            MarioInstance.State = new RightJumpingFireMarioState(MarioInstance);
        }
        public override void Crouch()
        {
            MarioInstance.State = new RightCrouchingFireMarioState(MarioInstance);
        }
        public override void MakeStand()
        {
            MarioInstance.State = new RightIdleFireMarioState(MarioInstance);
        }
        public override void MakeRun()
        {
            MarioInstance.State = new RightRunningFireMarioState(MarioInstance);
        }
        public override void MakeWalk()
        {
            MarioInstance.State = new RightWalkingFireMarioState(MarioInstance);
        }
        public override bool IsFacingLeft()
        {
            return false;
        }
    }
}
