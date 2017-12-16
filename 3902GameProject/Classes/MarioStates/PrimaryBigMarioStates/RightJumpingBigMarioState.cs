using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _3902GameProject.Classes
{
    public class RightJumpingBigMarioState : GenericRightBigMarioState
    {
        public RightJumpingBigMarioState(Mario mario) : base(mario)
        {
            MarioSprite = Classes.PlayerSpriteFactory.Instance.CreateRightJumpingBigMarioSprite();
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
        public override void MakeSmall()
        {
            MarioInstance.State = new RightJumpingSmallMarioState(MarioInstance);
        }
        public override void MakeFire()
        {
            MarioInstance.State = new RightBigToFireJumpingState(MarioInstance);
        }
        public override void Damage()
        {
            MarioInstance.State = new RightBigDamageTransitionJumpingState(MarioInstance);
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
