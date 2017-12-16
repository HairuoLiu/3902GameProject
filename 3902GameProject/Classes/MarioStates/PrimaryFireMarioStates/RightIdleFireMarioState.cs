using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _3902GameProject.Classes
{
    public class RightIdleFireMarioState : GenericRightFireMarioState
    {
        public RightIdleFireMarioState(Mario mario) : base(mario)
        {
            MarioSprite = Classes.PlayerSpriteFactory.Instance.CreateRightIdleFireMarioSprite();
        }

        public override void TurnLeft()
        {
            MarioInstance.State = new LeftIdleFireMarioState(MarioInstance);
        }
        public override void MakeSmall()
        {
            MarioInstance.State = new RightIdleSmallMarioState(MarioInstance);
        }
        public override void MakeBig()
        {
            MarioInstance.State = new RightIdleBigMarioState(MarioInstance);
        }
        public override void Damage()
        {
            MarioInstance.State = new RightFireDamageTransitionIdleState(MarioInstance);
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
