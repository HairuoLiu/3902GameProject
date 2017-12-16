using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _3902GameProject.Classes
{
    public class LeftJumpingFireMarioState : GenericLeftFireMarioState
    {
        public LeftJumpingFireMarioState(Mario mario) : base(mario)
        {
            MarioSprite = Classes.PlayerSpriteFactory.Instance.CreateLeftJumpingFireMarioSprite();
        }

        public override void TurnRight()
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
            MarioInstance.State = new LeftJumpingSmallMarioState(MarioInstance);
        }
        public override void MakeBig()
        {
            MarioInstance.State = new LeftJumpingBigMarioState(MarioInstance);
        }
        public override void Damage()
        {
            MarioInstance.State = new LeftFireDamageTransitionJumpingState(MarioInstance);
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
