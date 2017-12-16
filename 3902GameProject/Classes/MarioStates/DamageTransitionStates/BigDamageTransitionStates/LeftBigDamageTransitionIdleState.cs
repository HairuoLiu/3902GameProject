using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _3902GameProject.Classes
{
    public class LeftBigDamageTransitionIdleState : GenericBigDamageTransitionState
    {
        public LeftBigDamageTransitionIdleState(Mario mario) : base(mario)
        {
            MarioSprite = Classes.PlayerSpriteFactory.Instance.CreateLeftBigDamageTransitionIdleSprite();
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
            return false;
        }

        public override bool IsJumping()
        {
            return false;
        }

        public override void Damage()
        {
            MarioInstance.State = new LeftIdleSmallMarioState(MarioInstance);
        }
    }
}
