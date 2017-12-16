using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static _3902GameProject.Classes.Mario;

namespace _3902GameProject.Classes
{
    public class RightThrowingFireMarioState : GenericMarioState
    {
        private int throwTimer;
        public RightThrowingFireMarioState(Mario mario, int timer) : base(mario)
        {
            throwTimer = timer;
            MarioSprite = Classes.PlayerSpriteFactory.Instance.CreateRightThrowingFireMarioSprite();
            MarioInstance.OffsetHitbox = Hitboxes.TallUprightMarioHitbox();
        }
        public override void MakeFlag()
        {
            MarioInstance.State = new RightFlagHoldingBigMarioState(MarioInstance);
        }
        public override void TurnLeft()
        {
            MarioInstance.State = new LeftThrowingFireMarioState(MarioInstance, throwTimer);
        }
        public override void TurnRight()
        {
        }
        public override void Jump()
        {
            MarioInstance.State = new RightJumpingFireMarioState(MarioInstance);
        }
        public override void MakeSmall()
        {
            MarioInstance.State = new RightIdleSmallMarioState(MarioInstance);
        }
        public override void MakeBig()
        {
            MarioInstance.State = new RightIdleBigMarioState(MarioInstance);
        }
        public override void Damage()
        {
            MarioInstance.State = new RightFireDamageTransitionIdleState(MarioInstance);
        }
        public override void MakeWalk()
        {
        }
        public override void MakeRun()
        {
        }
        public override void Crouch()
        {
        }
        public override void MakeStand()
        {
        }
        public override void MakeFire()
        {
        }
        public override Power PowerLevel()
        {
            return Power.Fire;
        }
        public override bool IsCrouching()
        {
            return false;
        }
        public override bool IsJumping()
        {
            return false;
        }
        public override bool IsFacingLeft()
        {
            return false;
        }
        public override void Update()
        {
            base.Update();
            throwTimer--;
            if (throwTimer <= 0)
                MarioInstance.State = new RightIdleFireMarioState(MarioInstance);
        }
    }
}
