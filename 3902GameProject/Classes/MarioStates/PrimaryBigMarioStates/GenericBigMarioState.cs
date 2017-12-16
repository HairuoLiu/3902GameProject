using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using _3902GameProject.Interfaces;
using static _3902GameProject.Classes.Mario;

namespace _3902GameProject.Classes
{
    public abstract class GenericBigMarioState : GenericMarioState
    {
        protected GenericBigMarioState(Mario mario) : base(mario)
        {
            MarioInstance.OffsetHitbox = Hitboxes.TallUprightMarioHitbox();
        }

        public override void MakeBig()
        {

        }
        public override Power PowerLevel()
        {
            return Power.Big;
        }

        public override void MakeFlag()
        {
            MarioInstance.State = new RightFlagHoldingBigMarioState(MarioInstance);
        }
    }
}
