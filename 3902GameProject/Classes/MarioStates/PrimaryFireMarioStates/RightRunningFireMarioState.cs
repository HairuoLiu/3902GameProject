using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _3902GameProject.Classes
{
    public class RightRunningFireMarioState : GenericRightFireMarioState
    {
        public RightRunningFireMarioState(Mario mario) : base(mario)
        {
            MarioSprite = Classes.PlayerSpriteFactory.Instance.CreateRightRunningFireMarioSprite();
        }

        public override void TurnLeft()
        {
            MarioInstance.State = new LeftRunningFireMarioState(MarioInstance);
        }
        public override void MakeSmall()
        {
            MarioInstance.State = new RightRunningSmallMarioState(MarioInstance);
        }
        public override void MakeBig()
        {
            MarioInstance.State = new RightRunningBigMarioState(MarioInstance);
        }
        public override void Damage()
        {
            MarioInstance.State = new RightFireDamageTransitionWalkingState(MarioInstance);
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
            return true;
        }
    }
}
