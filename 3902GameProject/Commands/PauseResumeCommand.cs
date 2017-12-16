using _3902GameProject.Interfaces;
using Microsoft.Xna.Framework.Input;
using _3902GameProject.Classes.SystemSprites;

namespace _3902GameProject.Classes
{
    internal class PauseResumeCommand : ICommand
    {
        private Game1 gameInstance;

        public PauseResumeCommand(Game1 game)
        {
            gameInstance = game;
        }

        public void Execute()
        {
            if (gameInstance.Type == Game1.GameType.None) return;
            if (gameInstance.UserPause)
            {
                gameInstance.UserPause = false;
                SoundControl.UnpauseSong();
            }
            else
            {
                gameInstance.UserPause = true;
                SoundControl.PauseSong();
            }
        }
    }
}