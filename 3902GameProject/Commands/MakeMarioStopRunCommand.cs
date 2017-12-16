using _3902GameProject.Interfaces;

namespace _3902GameProject.Classes
{
    public class MakeMarioStopRunCommand : ICommand
    {
        private int playerNum;
        public MakeMarioStopRunCommand(int num)
        {
            playerNum = num;
        }

        public void Execute()
        {
            ILevel level = Game1.GameInstance.GameLevel;
            ((IMario)level.GetPlayer(playerNum)).SetRunning(false);
        }
    }
}
