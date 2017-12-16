using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _3902GameProject.Classes
{
    public class LeftBigDamageTransitionCrouchingState : GenericBigDamageTransitionState
    {
        public LeftBigDamageTransitionCrouchingState(Mario mario) : base(mario)
        {
            MarioSprite = Classes.PlayerSpriteFactory.Instance.CreateLeftBigDamageTransitionCrouchingSprite();
        }
        public override void MakeFlag()
        {
            MarioInstance.State = new RightFlagHoldingBigMarioState(MarioInstance);
        }
        public override bool IsFacingLeft()
        {
            return true;
        }

        public override bool IsCrouching()
        {
            return true;
        }

        public override bool IsJumping()
        {
            return false;
        }

        public override void Damage()
        {
            MarioInstance.State = new LeftCrouchingSmallMarioState(MarioInstance);
        }
    }
}
