using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _3902GameProject.Classes
{
    public class RightCrouchingMarthState : GenericRightMarthState
    {
        public RightCrouchingMarthState(Marth marth) : base(marth)
        {
            MarthSprite = Classes.PlayerSpriteFactory.Instance.CreateRightCrouchingMarthSprite();
            MarthInstance.OffsetHitbox = Hitboxes.RightCrouchingMarthHitbox();
        }

        public override void TurnLeft()
        {
            MarthInstance.State = new LeftCrouchingMarthState(MarthInstance);
        }
        public override void Crouch()
        {

        }
        public override bool IsCrouching()
        {
            return true;
        }
        public override bool IsJumping()
        {
            return false;
        }
    }
}
