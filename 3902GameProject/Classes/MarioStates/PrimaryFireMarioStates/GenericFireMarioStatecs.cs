using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using _3902GameProject.Interfaces;
using static _3902GameProject.Classes.Mario;

namespace _3902GameProject.Classes
{
    public abstract class GenericFireMarioState : GenericMarioState
    {
        protected GenericFireMarioState(Mario mario) : base(mario)
        {
            MarioInstance.OffsetHitbox = Hitboxes.TallUprightMarioHitbox();
        }

        public override void MakeFire()
        {
        }
        public override Power PowerLevel()
        {
            return Power.Fire;
        }

        public override void MakeFlag()
        {
            MarioInstance.State = new RightFlagHoldingFireMarioState(MarioInstance);
        }
    }
}
