using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _3902GameProject.Classes
{
    public class LeftCrouchingSmallMarioState : GenericLeftSmallMarioState
    {
        public LeftCrouchingSmallMarioState(Mario mario) : base(mario)
        {
            MarioSprite = Classes.PlayerSpriteFactory.Instance.CreateLeftCrouchingSmallMarioSprite();
        }

        public override void TurnRight()
        {
            MarioInstance.State = new RightCrouchingSmallMarioState(MarioInstance);
        }
        public override void Jump()
        {
        }
        public override void Crouch()
        {
        }
        public override void MakeBig()
        {
            MarioInstance.State = new LeftSmallToBigCrouchingState(MarioInstance);
        }
        public override void MakeFire()
        {
            MarioInstance.State = new LeftSmallToFireCrouchingState(MarioInstance);
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
