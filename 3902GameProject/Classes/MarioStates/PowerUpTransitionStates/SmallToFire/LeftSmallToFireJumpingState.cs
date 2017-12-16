using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _3902GameProject.Classes
{
    public class LeftSmallToFireJumpingState : GenericSmallToFireState
    {
        public LeftSmallToFireJumpingState(Mario mario) : base(mario)
        {
            MarioSprite = Classes.PlayerSpriteFactory.Instance.CreateLeftSmallToFireSprite();
        }
        public override void MakeFlag()
        {
            MarioInstance.State = new RightFlagHoldingFireMarioState(MarioInstance);
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
            return true;
        }

        public override void Damage()
        {
            MarioInstance.State = new LeftJumpingFireMarioState(MarioInstance);
        }
    }
}
