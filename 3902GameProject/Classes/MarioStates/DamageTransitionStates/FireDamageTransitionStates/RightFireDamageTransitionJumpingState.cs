using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _3902GameProject.Classes
{
    public class RightFireDamageTransitionJumpingState : GenericFireDamageTransitionState
    {
        public RightFireDamageTransitionJumpingState(Mario mario) : base(mario)
        {
            MarioSprite = Classes.PlayerSpriteFactory.Instance.CreateRightFireDamageTransitionJumpingSprite();
        }
        public override void MakeFlag()
        {
            MarioInstance.State = new RightFlagHoldingFireMarioState(MarioInstance);
        }
        public override bool IsFacingLeft()
        {
            return false;
        }

        public override bool IsCrouching()
        {
            return false;
        }

        public override bool IsJumping()
        {
            return true;
        }

        public override void Damage()
        {
            MarioInstance.State = new RightJumpingSmallMarioState(MarioInstance);
        }
    }
}
