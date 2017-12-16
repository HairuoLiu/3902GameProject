using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static _3902GameProject.Classes.Mario;

namespace _3902GameProject.Classes
{
    public class LeftTurningFireMarioState : GenericMarioState
    {
        public LeftTurningFireMarioState(Mario mario) : base(mario)
        {
            MarioSprite = Classes.PlayerSpriteFactory.Instance.CreateLeftThrowingFireMarioSprite();
            MarioInstance.OffsetHitbox = Hitboxes.TallUprightMarioHitbox();
        }

        public override void MakeFlag()
        {
            MarioInstance.State = new RightFlagHoldingFireMarioState(MarioInstance);
        }

        public override void TurnRight()
        {
            //MarioInstance.State = new RightWalkingFireMarioState(MarioInstance, throwTimer);
        }
        public override void TurnLeft()
        {
        }
        public override void Jump()
        {
            MarioInstance.State = new LeftJumpingFireMarioState(MarioInstance);
        }
        public override void MakeSmall()
        {
            MarioInstance.State = new LeftIdleSmallMarioState(MarioInstance);
        }
        public override void MakeBig()
        {
            MarioInstance.State = new LeftIdleBigMarioState(MarioInstance);
        }
        public override void Damage()
        {
            MarioInstance.State = new LeftIdleSmallMarioState(MarioInstance);
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
            return true;
        }
        public override void Update()
        {
            base.Update();

        }
    }
}
