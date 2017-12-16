using _3902GameProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _3902GameProject.Classes
{
    public class LeftDamagingMarthState : GenericLeftMarthState
    {
        private IMarthState state;
        public LeftDamagingMarthState(Marth marth, IMarthState marthState) : base(marth)
        {
            MarthSprite = Classes.PlayerSpriteFactory.Instance.CreateLeftDamagingMarthSprite();
            MarthInstance.OffsetHitbox = Hitboxes.LeftStandingMarthHitbox();
            state = marthState;
        }

        public override void TurnLeft() { }
        public override void TurnRight() { }
        public override void Jump() { }
        public override void Fall() { }
        public override void Crouch() { }
        public override void Damage()
        {
            MarthInstance.State = state;
        }
        public override void MakeStand() { }
        public override void MakeWalk() { }
        public override void MakeSwing() { }
        public override bool IsCrouching()
        {
            return false;
        }
        public override bool IsJumping()
        {
            return false;
        }
        public override bool IsFacingLeft()
        {
            return true;
        }
    }
}
