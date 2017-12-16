using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _3902GameProject.Classes
{
    public class RightFallingMarthState : GenericRightMarthState
    {
        public RightFallingMarthState(Marth marth) : base(marth)
        {
            MarthSprite = Classes.PlayerSpriteFactory.Instance.CreateRightFallingMarthSprite();
            MarthInstance.OffsetHitbox = Hitboxes.RightFallingMarthHitbox();
        }

        public override void TurnLeft()
        {
            MarthInstance.State = new LeftFallingMarthState(MarthInstance);
        }
        public override void Fall()
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
    }
}
