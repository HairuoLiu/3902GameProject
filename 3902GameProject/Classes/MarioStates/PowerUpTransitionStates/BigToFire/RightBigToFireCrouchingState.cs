using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _3902GameProject.Classes
{
    public class RightBigToFireCrouchingState : GenericBigToFireState
    {
        public RightBigToFireCrouchingState(Mario mario) : base(mario)
        {
            MarioSprite = Classes.PlayerSpriteFactory.Instance.CreateRightBigToFireSprite();
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
            return true;
        }

        public override bool IsJumping()
        {
            return false;
        }

        public override void Damage()
        {
            MarioInstance.State = new RightCrouchingFireMarioState(MarioInstance);
        }
    }
}
