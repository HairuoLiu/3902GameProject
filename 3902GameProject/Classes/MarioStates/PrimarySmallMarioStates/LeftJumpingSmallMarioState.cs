using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _3902GameProject.Classes
{
    public class LeftJumpingSmallMarioState : GenericLeftSmallMarioState
    {
        public LeftJumpingSmallMarioState(Mario mario) : base(mario)
        {
            MarioSprite = Classes.PlayerSpriteFactory.Instance.CreateLeftJumpingSmallMarioSprite();
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
        public override void MakeBig()
        {
            MarioInstance.State = new LeftSmallToBigJumpingState(MarioInstance);
        }
        public override void MakeFire()
        {
            MarioInstance.State = new LeftSmallToFireJumpingState(MarioInstance);
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
