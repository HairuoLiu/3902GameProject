using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _3902GameProject.Classes
{
    public abstract class GenericLeftBigMarioState : GenericBigMarioState
    {
        protected GenericLeftBigMarioState(Mario mario) : base(mario)
        {
        }

        public override void TurnLeft()
        {
        }
        public override void Jump()
        {
            MarioInstance.State = new LeftJumpingBigMarioState(MarioInstance);
        }
        public override void Crouch()
        {
            MarioInstance.State = new LeftCrouchingBigMarioState(MarioInstance);
        }
        public override void MakeStand()
        {
            MarioInstance.State = new LeftIdleBigMarioState(MarioInstance);
        }
        public override void MakeRun()
        {
            MarioInstance.State = new LeftRunningBigMarioState(MarioInstance);
        }
        public override void MakeWalk()
        {
            MarioInstance.State = new LeftWalkingBigMarioState(MarioInstance);
        }
        public override bool IsFacingLeft()
        {
            return true;
        }
    }
}
