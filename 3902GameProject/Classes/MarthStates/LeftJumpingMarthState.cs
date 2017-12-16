using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _3902GameProject.Classes
{
    public class LeftJumpingMarthState : GenericLeftMarthState
    {
        public LeftJumpingMarthState(Marth marth) : base(marth)
        {
            MarthSprite = Classes.PlayerSpriteFactory.Instance.CreateLeftJumpingMarthSprite();
            MarthInstance.OffsetHitbox = Hitboxes.LeftJumpingMarthHitbox();
        }

        public override void TurnRight()
        {
            MarthInstance.State = new RightJumpingMarthState(MarthInstance);
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
            if (MarthInstance.Physics.YVelocity >= 0) MarthInstance.State = new LeftFallingMarthState(MarthInstance);
        }
    }
}
