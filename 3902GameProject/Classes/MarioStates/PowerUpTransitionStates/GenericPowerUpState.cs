using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using _3902GameProject.Interfaces;
using static _3902GameProject.Classes.Mario;

namespace _3902GameProject.Classes
{
    public abstract class GenericPowerUpState : GenericMarioState
    {
        protected GenericPowerUpState(Mario mario) : base(mario)
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

        }
        public override void MakeBig()
        {

        }
        public override void MakeFire()
        {

        }
        public override void MakeDead()
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
    }
}
