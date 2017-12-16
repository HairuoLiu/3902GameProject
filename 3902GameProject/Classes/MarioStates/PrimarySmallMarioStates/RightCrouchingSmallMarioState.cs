using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _3902GameProject.Classes
{
    public class RightCrouchingSmallMarioState : GenericRightSmallMarioState
    {
        public RightCrouchingSmallMarioState(Mario mario) : base(mario)
        {
            MarioSprite = Classes.PlayerSpriteFactory.Instance.CreateRightCrouchingSmallMarioSprite();
        }

        public override void TurnLeft()
        {
            MarioInstance.State = new LeftCrouchingSmallMarioState(MarioInstance);
        }
        public override void Jump()
        {

        }
        public override void Crouch()
        {

        }
        public override void MakeBig()
        {
            MarioInstance.State = new RightSmallToBigCrouchingState(MarioInstance);
        }
        public override void MakeFire()
        {
            MarioInstance.State = new RightSmallToFireCrouchingState(MarioInstance);
        }
        public override void MakeRun()
        {
        }
        public override void MakeWalk()
        {
        }
        public override bool IsCrouching()
        {
            return true;
        }
        public override bool IsJumping()
        {
            return false;
        }
    }
}
