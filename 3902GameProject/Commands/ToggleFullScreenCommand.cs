using _3902GameProject.Interfaces;
using Microsoft.Xna.Framework.Input;
using _3902GameProject.Classes.SystemSprites;
using Microsoft.Xna.Framework;

namespace _3902GameProject.Classes
{
    internal class ToggleFullScreenCommand : ICommand
    {
        private Game1 gameInstance;

        public ToggleFullScreenCommand(Game1 game)
        {
            gameInstance = game;
        }

        public void Execute()
        {
            gameInstance.Graphics.ToggleFullScreen();
        }
    }
}