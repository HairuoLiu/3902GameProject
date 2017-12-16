using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _3902GameProject.Classes
{
    public class RightIdleBigMarioState : GenericRightBigMarioState
    {
        public RightIdleBigMarioState(Mario mario) : base(mario)
        {
            MarioSprite = Classes.PlayerSpriteFactory.Instance.CreateRightIdleBigMarioSprite();
        }

        public override void TurnLeft()
        {
            MarioInstance.State = new LeftIdleBigMarioState(MarioInstance);
        }
        public override void MakeSmall()
        {
            MarioInstance.State = new RightIdleSmallMarioState(MarioInstance);
        }
        public override void MakeFire()
        {
            MarioInstance.State = new RightBigToFireIdleState(MarioInstance);
        }
        public override void Damage()
        {
            MarioInstance.State = new RightBigDamageTransitionIdleState(MarioInstance);
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
