using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _3902GameProject.Classes
{
    public abstract class GenericLeftSmallMarioState : GenericSmallMarioState
    {
        protected GenericLeftSmallMarioState(Mario mario) : base(mario)
        {
        }

        public override void TurnLeft()
        {
        }
        public override void Jump()
        {
            MarioInstance.State = new LeftJumpingSmallMarioState(MarioInstance);
        }
        public override void Crouch()
        {
            MarioInstance.State = new LeftCrouchingSmallMarioState(MarioInstance);
        }
        public override void MakeStand()
        {
            MarioInstance.State = new LeftIdleSmallMarioState(MarioInstance);
        }
        public override void MakeRun()
        {
            MarioInstance.State = new LeftRunningSmallMarioState(MarioInstance);
        }
        public override void MakeWalk()
        {
            MarioInstance.State = new LeftWalkingSmallMarioState(MarioInstance);
        }
        public override bool IsFacingLeft()
        {
            return true;
        }
    }
}
