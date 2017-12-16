using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _3902GameProject.Classes
{
    public class RightWalkingBigMarioState : GenericRightBigMarioState
    {
        public RightWalkingBigMarioState(Mario mario) : base(mario)
        {
            MarioSprite = Classes.PlayerSpriteFactory.Instance.CreateRightWalkingBigMarioSprite();
        }

        public override void TurnLeft()
        {
            MarioInstance.State = new LeftWalkingBigMarioState(MarioInstance);
        }
        public override void MakeSmall()
        {
            MarioInstance.State = new RightWalkingSmallMarioState(MarioInstance);
        }
        public override void MakeFire()
        {
            MarioInstance.State = new RightBigToFireWalkingState(MarioInstance);
        }
        public override void Damage()
        {
            MarioInstance.State = new RightBigDamageTransitionWalkingState(MarioInstance);
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
