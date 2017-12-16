using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using _3902GameProject.Interfaces;
using static _3902GameProject.Classes.Mario;

namespace _3902GameProject.Classes
{
    public abstract class GenericSmallMarioState : GenericMarioState
    {
        protected GenericSmallMarioState(Mario mario) : base(mario)
        {
            MarioInstance.OffsetHitbox = Hitboxes.SmallMarioHitbox();
        }

        public override void MakeSmall()
        {

        }
        public override void Damage()
        {
            MarioInstance.State = new DeadMarioState(MarioInstance);
        }

        public override void MakeFlag()
        {
            MarioInstance.State = new RightFlagHoldingSmallMarioState(MarioInstance);
        }
        public override Power PowerLevel()
        {
            return Power.None;
        }
    }
}
