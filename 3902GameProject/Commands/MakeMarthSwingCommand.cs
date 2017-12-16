using _3902GameProject.Interfaces;

namespace _3902GameProject.Classes
{
    public class MakeMarthSwingCommand : ICommand
    {
        private int playerNum;
        public MakeMarthSwingCommand(int num)
        {
            playerNum = num;
        }

        public void Execute()
        {
            ILevel level = Game1.GameInstance.GameLevel;
            ((IMarth)level.GetPlayer(playerNum)).Swing();
        }
    }
}
