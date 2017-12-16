using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _3902GameProject.Classes
{
    public class RightWalkingSmallMarioState : GenericRightSmallMarioState
    {
        public RightWalkingSmallMarioState(Mario mario) : base(mario)
        {
            MarioSprite = Classes.PlayerSpriteFactory.Instance.CreateRightWalkingSmallMarioSprite();
        }

        public override void TurnLeft()
        {
            MarioInstance.State = new LeftWalkingSmallMarioState(MarioInstance);
        }
        public override void MakeBig()
        {
            MarioInstance.State = new RightSmallToBigWalkingState(MarioInstance);
        }
        public override void MakeFire()
        {
            MarioInstance.State = new RightSmallToFireWalkingState(MarioInstance);
        }
        public override void MakeWalk()
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
