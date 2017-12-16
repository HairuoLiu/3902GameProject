using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using _3902GameProject.Interfaces;
using static _3902GameProject.Classes.Mario;

namespace _3902GameProject.Classes
{
    public abstract class GenericFireDamageTransitionState : GenericDamageTransitionState
    {
        protected GenericFireDamageTransitionState(Mario mario) : base(mario)
        {
        }

        public override Power PowerLevel()
        {
            return Power.Fire;
        }
    }
}
