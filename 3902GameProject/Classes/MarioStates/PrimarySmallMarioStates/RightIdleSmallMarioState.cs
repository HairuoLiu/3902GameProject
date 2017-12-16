using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _3902GameProject.Classes
{
    public class RightIdleSmallMarioState : GenericRightSmallMarioState
    {
        public RightIdleSmallMarioState(Mario mario) : base(mario)
        {
            MarioSprite = Classes.PlayerSpriteFactory.Instance.CreateRightIdleSmallMarioSprite();
        }

        public override void TurnLeft()
        {
            MarioInstance.State = new LeftIdleSmallMarioState(MarioInstance);
        }
        public override void MakeBig()
        {
            MarioInstance.State = new RightSmallToBigIdleState(MarioInstance);
        }
        public override void MakeFire()
        {
            MarioInstance.State = new RightSmallToFireIdleState(MarioInstance);
        }
        public override bool IsCrouching()
        {
            return false;
        }
        public override bool IsJumping()
        {
            return false;
        }
    }
}
