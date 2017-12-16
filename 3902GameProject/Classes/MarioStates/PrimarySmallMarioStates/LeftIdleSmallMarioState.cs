using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _3902GameProject.Classes
{
    public class LeftIdleSmallMarioState : GenericLeftSmallMarioState
    {
        public LeftIdleSmallMarioState(Mario mario) : base(mario)
        {
            MarioSprite = Classes.PlayerSpriteFactory.Instance.CreateLeftIdleSmallMarioSprite();
        }

        public override void TurnRight()
        {
            MarioInstance.State = new RightIdleSmallMarioState(MarioInstance);
        }
        public override void MakeBig()
        {
            MarioInstance.State = new LeftSmallToBigIdleState(MarioInstance);
        }
        public override void MakeFire()
        {
            MarioInstance.State = new LeftSmallToFireIdleState(MarioInstance);
        }
        public override void MakeStand()
        {
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
