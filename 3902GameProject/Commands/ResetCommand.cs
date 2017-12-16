namespace _3902GameProject.Classes
{
    public class ResetCommand : ICommand
    {
        private Game1 gameInstance;
        public ResetCommand(Game1 game)
        {
            gameInstance = game;
        }

        public void Execute()
        {
            gameInstance.ResetLevel();
        }
    }
}
