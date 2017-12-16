namespace _3902GameProject.Classes
{
    public class QuitCommand : ICommand
    {
        private Game1 gameInstance;
        public QuitCommand(Game1 game)
        {
            gameInstance = game;
        }

        public void Execute()
        {
            gameInstance.Exit();
        }
    }
}
