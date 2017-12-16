using _3902GameProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _3902GameProject.Classes
{
    public class LeftDeadMarthState : GenericLeftMarthState
    {
        public LeftDeadMarthState(Marth marth) : base(marth)
        {
            MarthSprite = Classes.PlayerSpriteFactory.Instance.CreateLeftDamagingMarthSprite();
            MarthInstance.OffsetHitbox = Hitboxes.LeftStandingMarthHitbox();
        }

        public override void TurnLeft() { }
        public override void TurnRight() { }
        public override void Jump() { }
        public override void Fall() { }
        public override void Crouch() { }
        public override void Damage() { }
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
        public override bool IsDead()
        {
            return true;
        }
    }
}
