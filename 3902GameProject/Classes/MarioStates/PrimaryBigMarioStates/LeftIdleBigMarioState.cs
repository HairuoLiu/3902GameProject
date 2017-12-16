using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _3902GameProject.Classes
{
    public class LeftIdleBigMarioState : GenericLeftBigMarioState
    {
        public LeftIdleBigMarioState(Mario mario) : base(mario)
        {
            MarioSprite = Classes.PlayerSpriteFactory.Instance.CreateLeftIdleBigMarioSprite();
        }

        public override void TurnRight()
        {
            MarioInstance.State = new RightIdleBigMarioState(MarioInstance);
        }
        public override void MakeSmall()
        {
            MarioInstance.State = new LeftIdleSmallMarioState(MarioInstance);
        }
        public override void MakeFire()
        {
            MarioInstance.State = new LeftBigToFireIdleState(MarioInstance);
        }
        public override void Damage()
        {
            MarioInstance.State = new LeftBigDamageTransitionIdleState(MarioInstance);
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
