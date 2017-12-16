using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _3902GameProject.Classes
{
    public class RightRunningSmallMarioState : GenericRightSmallMarioState
    {
        public RightRunningSmallMarioState(Mario mario) : base(mario)
        {
            MarioSprite = Classes.PlayerSpriteFactory.Instance.CreateRightRunningSmallMarioSprite();
        }

        public override void TurnLeft()
        {
            MarioInstance.State = new LeftRunningSmallMarioState(MarioInstance);
        }
        public override void MakeBig()
        {
            MarioInstance.State = new RightSmallToBigWalkingState(MarioInstance);
        }
        public override void MakeFire()
        {
            MarioInstance.State = new RightSmallToFireWalkingState(MarioInstance);
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
