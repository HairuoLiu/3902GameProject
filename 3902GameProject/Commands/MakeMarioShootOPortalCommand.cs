using _3902GameProject.Interfaces;

namespace _3902GameProject.Classes
{
    public class MakeMarioShootOPortalCommand : ICommand
    {
        private int playerNum;
        public MakeMarioShootOPortalCommand(int num)
        {
            playerNum = num;
        }

        public void Execute()
        {
            ILevel level = Game1.GameInstance.GameLevel;
            ((IMario)level.GetPlayer(playerNum)).ShootOrangePortal();
        }
    }
}
