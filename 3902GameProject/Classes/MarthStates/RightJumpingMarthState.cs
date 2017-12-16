using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _3902GameProject.Classes
{
    public class RightJumpingMarthState : GenericRightMarthState
    {
        public RightJumpingMarthState(Marth marth) : base(marth)
        {
            MarthSprite = Classes.PlayerSpriteFactory.Instance.CreateRightJumpingMarthSprite();
            MarthInstance.OffsetHitbox = Hitboxes.RightJumpingMarthHitbox();
        }

        public override void TurnLeft()
        {
            MarthInstance.State = new LeftJumpingMarthState(MarthInstance);
        }
        public override void Jump()
        {
        }
        public override bool IsCrouching()
        {
            return false;
        }
        public override bool IsJumping()
        {
            return true;
        }

        public override void Update()
        {
            base.Update();
            if (MarthInstance.Physics.YVelocity >= 0) MarthInstance.State = new RightFallingMarthState(MarthInstance);
        }
    }
}
