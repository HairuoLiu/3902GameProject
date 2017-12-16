using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _3902GameProject.Classes
{
    public class LeftCrouchingBigMarioState : GenericLeftBigMarioState
    {
        public LeftCrouchingBigMarioState(Mario mario) : base(mario)
        {
            MarioInstance.OffsetHitbox = Hitboxes.TallCrouchingMarioHitbox();
            MarioSprite = Classes.PlayerSpriteFactory.Instance.CreateLeftCrouchingBigMarioSprite();
        }

        public override void TurnRight()
        {
            MarioInstance.State = new RightCrouchingBigMarioState(MarioInstance);
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
        public override void MakeFire()
        {
            MarioInstance.State = new LeftBigToFireCrouchingState(MarioInstance);
        }
        public override void Damage()
        {
            MarioInstance.State = new LeftBigDamageTransitionCrouchingState(MarioInstance);
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
