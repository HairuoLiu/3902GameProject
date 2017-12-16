using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _3902GameProject.Classes
{
    public class LeftIdleMarthState : GenericLeftMarthState
    {
        public LeftIdleMarthState(Marth marth) : base(marth)
        {
            MarthSprite = Classes.PlayerSpriteFactory.Instance.CreateLeftIdleMarthSprite();
            MarthInstance.OffsetHitbox = Hitboxes.LeftStandingMarthHitbox();
        }

        public override void TurnRight()
        {
            MarthInstance.State = new RightIdleMarthState(MarthInstance);
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
