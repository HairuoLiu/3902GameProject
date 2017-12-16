using _3902GameProject.Interfaces;

namespace _3902GameProject.Classes
{
    public class MakePlayerJumpCommand : ICommand
    {
        private int playerNum;
        public MakePlayerJumpCommand(int num)
        {
            playerNum = num;
        }

        public void Execute()
        {
            ILevel level = Game1.GameInstance.GameLevel;
            level.GetPlayer(playerNum).Jump();
        }
    }
}
