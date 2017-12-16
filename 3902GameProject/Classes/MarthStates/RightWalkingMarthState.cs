using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _3902GameProject.Classes
{
    public class RightWalkingMarthState : GenericRightMarthState
    {
        public RightWalkingMarthState(Marth marth) : base(marth)
        {
            MarthSprite = PlayerSpriteFactory.Instance.CreateRightWalkingMarthSprite();
            MarthInstance.OffsetHitbox = Hitboxes.RightWalkingMarthHitbox();
        }

        public override void TurnLeft()
        {
            MarthInstance.State = new LeftWalkingMarthState(MarthInstance);
        }
        public override void MakeWalk()
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
