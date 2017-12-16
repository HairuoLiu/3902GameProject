using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _3902GameProject.Classes
{
    public class RightCrouchingFireMarioState : GenericRightFireMarioState
    {
        public RightCrouchingFireMarioState(Mario mario) : base(mario)
        {
            MarioInstance.OffsetHitbox = Hitboxes.TallCrouchingMarioHitbox();
            MarioSprite = Classes.PlayerSpriteFactory.Instance.CreateRightCrouchingFireMarioSprite();
        }

        public override void TurnLeft()
        {
            MarioInstance.State = new LeftCrouchingFireMarioState(MarioInstance);
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
        public override void MakeBig()
        {
            MarioInstance.State = new RightCrouchingBigMarioState(MarioInstance);
        }
        public override void Damage()
        {
            MarioInstance.State = new RightFireDamageTransitionCrouchingState(MarioInstance);
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
