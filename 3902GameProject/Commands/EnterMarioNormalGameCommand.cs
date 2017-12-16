using _3902GameProject.Classes.UtilityClasses;
using _3902GameProject.Interfaces;

namespace _3902GameProject.Classes
{
    public class EnterMarioGameCommand : ICommand
    {
        public EnterMarioGameCommand()
        {
        }

        public void Execute()
        {
            Game1 game = Game1.GameInstance;
            game.LevelFile = StringConsts.Level1File;
            game.Scorekeeper.Level = StringConsts.Level1Code;
            game.Scorekeeper.Lives = MiscUtilityClass.MarioStartingLives;
            game.Type = Game1.GameType.MarioNormal;
            game.HeadsUpDisplay = new MarioHeadsUp();
            game.State = new TransitioningLifeScreen(120);
        }
    }
}
