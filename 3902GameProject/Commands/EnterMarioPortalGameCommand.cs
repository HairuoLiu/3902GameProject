using _3902GameProject.Classes.UtilityClasses;
using _3902GameProject.Interfaces;

namespace _3902GameProject.Classes
{
    public class EnterMarioPortalGameCommand : ICommand
    {
        public EnterMarioPortalGameCommand()
        {
        }

        public void Execute()
        {
            Game1 game = Game1.GameInstance;
            game.LevelFile = StringConsts.LevelPortalFile;
            game.Scorekeeper.Level = StringConsts.Level1Code;
            game.Scorekeeper.Lives = MiscUtilityClass.MarioStartingLives;
            game.Type = Game1.GameType.MarioPortal;
            game.HeadsUpDisplay = new MarioHeadsUp();
            game.State = new PortalInstructionScreen();
        }
    }
}
