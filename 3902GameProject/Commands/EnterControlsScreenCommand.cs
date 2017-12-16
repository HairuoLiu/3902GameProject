using _3902GameProject.Classes.UtilityClasses;
using _3902GameProject.Interfaces;

namespace _3902GameProject.Classes
{
    public class EnterControlsScrenCommand : ICommand
    {
        public EnterControlsScrenCommand()
        {
        }

        public void Execute()
        {
            Game1.GameInstance.State = new ControlsScreen();
        }
    }
}
