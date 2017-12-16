using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _3902GameProject.Classes
{
    public class RightRunningBigMarioState : GenericRightBigMarioState
    {
        public RightRunningBigMarioState(Mario mario) : base(mario)
        {
            MarioSprite = Classes.PlayerSpriteFactory.Instance.CreateRightRunningBigMarioSprite();
        }

        public override void TurnLeft()
        {
            MarioInstance.State = new LeftRunningBigMarioState(MarioInstance);
        }
        public override void MakeSmall()
        {
            MarioInstance.State = new RightRunningSmallMarioState(MarioInstance);
        }
        public override void MakeFire()
        {
            MarioInstance.State = new RightBigToFireWalkingState(MarioInstance);
        }
        public override void Damage()
        {
            MarioInstance.State = new RightBigDamageTransitionWalkingState(MarioInstance);
        }
        public override void MakeRun()
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
