using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _3902GameProject.Classes
{
    public class RightIdleMarthState : GenericRightMarthState
    {
        public RightIdleMarthState(Marth marth) : base(marth)
        {
            MarthSprite = Classes.PlayerSpriteFactory.Instance.CreateRightIdleMarthSprite();
            MarthInstance.OffsetHitbox = Hitboxes.RightStandingMarthHitbox();
        }

        public override void TurnLeft()
        {
            MarthInstance.State = new LeftIdleMarthState(MarthInstance);
        }
        public override void MakeStand()
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
    }
}
