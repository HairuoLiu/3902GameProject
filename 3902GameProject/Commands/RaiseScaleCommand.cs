using System;

namespace _3902GameProject.Classes
{
    public class RaiseScaleCommand : ICommand
    {
        public RaiseScaleCommand()
        {
        }

        public void Execute()
        {
            Game1.Scale = Math.Min(Game1.Scale + 0.5f, 3.5f);
            Game1.GameInstance.SetWindow();
        }
    }
}
