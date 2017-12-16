using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _3902GameProject.Classes
{
    public class LeftCrouchingFireMarioState : GenericLeftFireMarioState
    {
        public LeftCrouchingFireMarioState(Mario mario) : base(mario)
        {
            MarioInstance.OffsetHitbox = Hitboxes.TallCrouchingMarioHitbox();
            MarioSprite = Classes.PlayerSpriteFactory.Instance.CreateLeftCrouchingFireMarioSprite();
        }

        public override void TurnRight()
        {
            MarioInstance.State = new RightCrouchingFireMarioState(MarioInstance);
        }
        public override void Jump()
        {

        }
        public override void Crouch()
        {

        }
        public override void MakeSmall()
        {
            MarioInstance.State = new LeftCrouchingSmallMarioState(MarioInstance);
        }
        public override void MakeBig()
        {
            MarioInstance.State = new LeftCrouchingBigMarioState(MarioInstance);
        }
        public override void Damage()
        {
            MarioInstance.State = new LeftFireDamageTransitionCrouchingState(MarioInstance);
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
