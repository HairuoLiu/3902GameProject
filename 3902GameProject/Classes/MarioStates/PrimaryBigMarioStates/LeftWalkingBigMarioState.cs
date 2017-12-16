using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _3902GameProject.Classes
{
    public class LeftWalkingBigMarioState : GenericLeftBigMarioState
    {
        public LeftWalkingBigMarioState(Mario mario) : base(mario)
        {
            MarioSprite = Classes.PlayerSpriteFactory.Instance.CreateLeftWalkingBigMarioSprite();
        }

        public override void TurnRight()
        {
            MarioInstance.State = new RightWalkingBigMarioState(MarioInstance);
        }
        public override void MakeSmall()
        {
            MarioInstance.State = new LeftWalkingSmallMarioState(MarioInstance);
        }
        public override void MakeFire()
        {
            MarioInstance.State = new LeftBigToFireWalkingState(MarioInstance);
        }
        public override void Damage()
        {
            MarioInstance.State = new LeftBigDamageTransitionWalkingState(MarioInstance);
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
