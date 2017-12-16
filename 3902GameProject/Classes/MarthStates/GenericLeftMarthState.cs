using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using _3902GameProject.Interfaces;
using static _3902GameProject.Classes.Mario;
using _3902GameProject.Classes.SystemSprites;

namespace _3902GameProject.Classes
{
    public abstract class GenericLeftMarthState : GenericMarthState
    {
        protected GenericLeftMarthState(Marth marth) : base(marth)
        {
            MarthInstance = marth;
        }

        public override void TurnLeft()
        {
        }
        public override void Jump()
        {
            MarthInstance.State = new LeftJumpingMarthState(MarthInstance);
        }
        public override void Fall()
        {
            MarthInstance.State = new LeftFallingMarthState(MarthInstance);
        }
        public override void Crouch()
        {
            MarthInstance.State = new LeftCrouchingMarthState(MarthInstance);
        }
        public override void MakeStand()
        {
            MarthInstance.State = new LeftIdleMarthState(MarthInstance);
        }
        public override void MakeWalk()
        {
            MarthInstance.State = new LeftWalkingMarthState(MarthInstance);
        }
        public override void MakeDead()
        {
            MarthInstance.State = new LeftDeadMarthState(MarthInstance);
        }
        public override bool IsFacingLeft()
        {
            return true;
        }
        public override void Damage()
        {
            MarthInstance.State = new LeftDamagingMarthState(MarthInstance, this);
        }
        public override void MakeSwing()
        {
            MarthInstance.State = new LeftSwingingMarthState(MarthInstance, this);
        }
    }
}
