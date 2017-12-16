using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _3902GameProject.Classes
{
    public class LeftFallingMarthState : GenericLeftMarthState
    {
        public LeftFallingMarthState(Marth marth) : base(marth)
        {
            MarthSprite = Classes.PlayerSpriteFactory.Instance.CreateLeftFallingMarthSprite();
            MarthInstance.OffsetHitbox = Hitboxes.LeftFallingMarthHitbox();
        }

        public override void TurnRight()
        {
            MarthInstance.State = new RightFallingMarthState(MarthInstance);
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
