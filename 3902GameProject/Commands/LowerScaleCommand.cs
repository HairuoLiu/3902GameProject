using System;

namespace _3902GameProject.Classes
{
    public class LowerScaleCommand : ICommand
    {
        public LowerScaleCommand()
        {
        }

        public void Execute()
        {
            Game1.Scale = Math.Max(Game1.Scale - 0.5f, 2f);
            Game1.GameInstance.SetWindow();
        }
    }
}
