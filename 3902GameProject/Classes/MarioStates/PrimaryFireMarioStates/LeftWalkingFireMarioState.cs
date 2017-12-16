using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _3902GameProject.Classes
{
    public class LeftWalkingFireMarioState : GenericLeftFireMarioState
    {
        public LeftWalkingFireMarioState(Mario mario) : base(mario)
        {
            MarioSprite = Classes.PlayerSpriteFactory.Instance.CreateLeftWalkingFireMarioSprite();
        }

        public override void TurnRight()
        {
            MarioInstance.State = new RightWalkingFireMarioState(MarioInstance);
        }
        public override void MakeSmall()
        {
            MarioInstance.State = new LeftWalkingSmallMarioState(MarioInstance);
        }
        public override void MakeBig()
        {
            MarioInstance.State = new LeftWalkingBigMarioState(MarioInstance);
        }
        public override void Damage()
        {
            MarioInstance.State = new LeftFireDamageTransitionWalkingState(MarioInstance);
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
