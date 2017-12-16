using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _3902GameProject.Classes
{
    public class LeftCrouchingMarthState : GenericLeftMarthState
    {
        public LeftCrouchingMarthState(Marth marth) : base(marth)
        {
            MarthSprite = Classes.PlayerSpriteFactory.Instance.CreateLeftCrouchingMarthSprite();
            MarthInstance.OffsetHitbox = Hitboxes.LeftCrouchingMarthHitbox();
        }

        public override void TurnRight()
        {
            MarthInstance.State = new RightCrouchingMarthState(MarthInstance);
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
