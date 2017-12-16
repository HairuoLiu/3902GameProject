using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _3902GameProject.Classes
{
    public class RightJumpingSmallMarioState : GenericRightSmallMarioState
    {
        public RightJumpingSmallMarioState(Mario mario) : base(mario)
        {
            MarioSprite = Classes.PlayerSpriteFactory.Instance.CreateRightJumpingSmallMarioSprite();
        }

        public override void TurnLeft()
        {
        }
        public override void Jump()
        {
        }
        public override void Crouch()
        {
        }
        public override void MakeBig()
        {
            MarioInstance.State = new RightSmallToBigJumpingState(MarioInstance);
        }
        public override void MakeFire()
        {
            MarioInstance.State = new RightSmallToFireJumpingState(MarioInstance);
        }
        public override void MakeRun()
        {
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
            return true;
        }
    }
}
