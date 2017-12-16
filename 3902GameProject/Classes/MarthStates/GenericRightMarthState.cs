using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using _3902GameProject.Interfaces;
using static _3902GameProject.Classes.Mario;
using _3902GameProject.Classes.SystemSprites;

namespace _3902GameProject.Classes
{
    public abstract class GenericRightMarthState : GenericMarthState
    {
        protected GenericRightMarthState(Marth marth) : base(marth)
        {
            MarthInstance = marth;
        }

        public override void TurnRight()
        {
        }
        public override void Jump()
        {
            MarthInstance.State = new RightJumpingMarthState(MarthInstance);
        }
        public override void Fall()
        {
            MarthInstance.State = new RightFallingMarthState(MarthInstance);
        }
        public override void Crouch()
        {
            MarthInstance.State = new RightCrouchingMarthState(MarthInstance);
        }
        public override void MakeStand()
        {
            MarthInstance.State = new RightIdleMarthState(MarthInstance);
        }
        public override void MakeWalk()
        {
            MarthInstance.State = new RightWalkingMarthState(MarthInstance);
        }
        public override void MakeDead()
        {
            MarthInstance.State = new RightDeadMarthState(MarthInstance);
        }
        public override bool IsFacingLeft()
        {
            return false;
        }
        public override void Damage()
        {
            MarthInstance.State = new RightDamagingMarthState(MarthInstance, this);
        }
        public override void MakeSwing()
        {
            MarthInstance.State = new RightSwingingMarthState(MarthInstance, this);
        }
    }
}
