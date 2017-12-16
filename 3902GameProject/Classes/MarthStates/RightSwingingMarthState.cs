using _3902GameProject.Classes.UtilityClasses;
using _3902GameProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _3902GameProject.Classes
{
    public class RightSwingingMarthState : GenericLeftMarthState
    {
        private int timer = MiscUtilityClass.SwingFrameTime * 3;
        private IMarthState state;
        public RightSwingingMarthState(Marth marth, IMarthState marthState) : base(marth)
        {
            MarthSprite = Classes.PlayerSpriteFactory.Instance.CreateRightSwingingMarthSprite();
            MarthInstance.OffsetHitbox = Hitboxes.RightSwingingMarthHitbox();
            state = marthState;
        }

        public override void TurnRight()
        {
        }
        public override void TurnLeft()
        {
        }
        public override void Jump()
        {
        }
        public override void Fall()
        {
        }
        public override void Crouch()
        {
        }
        public override void MakeStand()
        {
        }
        public override void MakeWalk()
        {
        }
        public override bool IsFacingLeft()
        {
            return false;
        }
        public override void MakeSwing()
        {
        }
        public override bool IsCrouching()
        {
            return false;
        }
        public override bool IsJumping()
        {
            return false;
        }
        public override bool IsSwinging()
        {
            return true;
        }
        public override void Update()
        {
            timer--;
            if (timer <= 0) MarthInstance.State = state;
            base.Update();
        }
    }
}
