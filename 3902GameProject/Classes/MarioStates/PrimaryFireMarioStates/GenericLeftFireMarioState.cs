using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _3902GameProject.Classes
{
    public abstract class GenericLeftFireMarioState : GenericFireMarioState
    {
        protected GenericLeftFireMarioState(Mario mario) : base(mario)
        {
        }

        public override void TurnLeft()
        {
        }
        public override void Jump()
        {
            MarioInstance.State = new LeftJumpingFireMarioState(MarioInstance);
        }
        public override void Crouch()
        {
            MarioInstance.State = new LeftCrouchingFireMarioState(MarioInstance);
        }
        public override void MakeStand()
        {
            MarioInstance.State = new LeftIdleFireMarioState(MarioInstance);
        }
        public override void MakeRun()
        {
            MarioInstance.State = new LeftRunningFireMarioState(MarioInstance);
        }
        public override void MakeWalk()
        {
            MarioInstance.State = new LeftWalkingFireMarioState(MarioInstance);
        }
        public override bool IsFacingLeft()
        {
            return true;
        }
    }
}
