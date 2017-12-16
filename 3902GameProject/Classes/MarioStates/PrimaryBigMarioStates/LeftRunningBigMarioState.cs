using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _3902GameProject.Classes
{
    public class LeftRunningBigMarioState : GenericLeftBigMarioState
    {
        public LeftRunningBigMarioState(Mario mario) : base(mario)
        {
            MarioSprite = Classes.PlayerSpriteFactory.Instance.CreateLeftRunningBigMarioSprite();
        }

        public override void TurnRight()
        {
            MarioInstance.State = new RightRunningBigMarioState(MarioInstance);
        }
        public override void MakeSmall()
        {
            MarioInstance.State = new LeftRunningSmallMarioState(MarioInstance);
        }
        public override void MakeFire()
        {
            MarioInstance.State = new LeftBigToFireWalkingState(MarioInstance);
        }
        public override void Damage()
        {
            MarioInstance.State = new LeftBigDamageTransitionWalkingState(MarioInstance);
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
