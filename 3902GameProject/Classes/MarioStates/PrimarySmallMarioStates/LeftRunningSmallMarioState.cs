using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _3902GameProject.Classes
{
    public class LeftRunningSmallMarioState : GenericLeftSmallMarioState
    {
        public LeftRunningSmallMarioState(Mario mario) : base(mario)
        {
            MarioSprite = Classes.PlayerSpriteFactory.Instance.CreateLeftRunningSmallMarioSprite();
        }

        public override void TurnRight()
        {
            MarioInstance.State = new RightRunningSmallMarioState(MarioInstance);
        }
        public override void MakeBig()
        {
            MarioInstance.State = new LeftSmallToBigWalkingState(MarioInstance);
        }
        public override void MakeFire()
        {
            MarioInstance.State = new LeftSmallToFireWalkingState(MarioInstance);
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
