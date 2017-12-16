using _3902GameProject.Interfaces;

namespace _3902GameProject.Classes
{
    public class KillPlayerCommand : ICommand
    {
        private int playerNum;
        public KillPlayerCommand(int num)
        {
            playerNum = num;
        }

        public void Execute()
        {
            ILevel level = Game1.GameInstance.GameLevel;
            level.GetPlayer(playerNum).MakeDead();
        }
    }
}
