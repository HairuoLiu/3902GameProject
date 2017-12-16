using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _3902GameProject.Classes
{
    public class LeftWalkingMarthState : GenericLeftMarthState
    {
        public LeftWalkingMarthState(Marth marth) : base(marth)
        {
            MarthSprite = Classes.PlayerSpriteFactory.Instance.CreateLeftWalkingMarthSprite();
            MarthInstance.OffsetHitbox = Hitboxes.LeftWalkingMarthHitbox();
        }

        public override void TurnRight()
        {
            MarthInstance.State = new RightWalkingMarthState(MarthInstance);
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
