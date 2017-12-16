using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _3902GameProject.Classes
{
    public class RightCrouchingBigMarioState : GenericRightBigMarioState
    {
        public RightCrouchingBigMarioState(Mario mario) : base(mario)
        {
            MarioInstance.OffsetHitbox = Hitboxes.TallCrouchingMarioHitbox();
            MarioSprite = Classes.PlayerSpriteFactory.Instance.CreateRightCrouchingBigMarioSprite();
        }

        public override void TurnLeft()
        {
            MarioInstance.State = new LeftCrouchingBigMarioState(MarioInstance);
        }
        public override void Jump()
        {

        }
        public override void Crouch()
        {

        }
        public override void MakeSmall()
        {
            MarioInstance.State = new RightCrouchingSmallMarioState(MarioInstance);
        }
        public override void MakeFire()
        {
            MarioInstance.State = new RightBigToFireCrouchingState(MarioInstance);
        }
        public override void Damage()
        {
            MarioInstance.State = new RightBigDamageTransitionCrouchingState(MarioInstance);
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
