using _3902GameProject.Classes.SystemSprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using static _3902GameProject.Classes.Mario;

namespace _3902GameProject.Classes
{
    public class DeadMarioState : GenericMarioState
    {
        public DeadMarioState(Mario mario) : base(mario)
        {
            //SoundControl.PauseSong();
            //SoundControl.PlaySoundEffect(Sound.gameoverEffect);
            MarioInstance.OffsetHitbox = Hitboxes.SmallMarioHitbox();
            MarioSprite = Classes.PlayerSpriteFactory.Instance.CreateDeadMarioSprite();
        }
        public override void MakeFlag()
        {
            
        }
        public override void TurnLeft()
        {

        }
        public override void TurnRight()
        {

        }
        public override void Jump()
        {

        }
        public override void Crouch()
        {

        }
        public override void MakeSmall()
        {
            MarioInstance.State = new RightIdleSmallMarioState(MarioInstance);
        }
        public override void MakeBig()
        {
            MarioInstance.State = new RightIdleBigMarioState(MarioInstance);
        }
        public override void MakeFire()
        {
            MarioInstance.State = new RightIdleFireMarioState(MarioInstance);
        }
        public override void Damage()
        {

        }
        public override void MakeStand()
        {
        }
        public override void MakeRun()
        {

        }
        public override void MakeWalk()
        { 

        }

        public override Power PowerLevel()
        {
            return Power.None;
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
        public override bool IsDead()
        {
            return true;
        }
    }
}
