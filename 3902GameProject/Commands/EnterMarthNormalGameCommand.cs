using _3902GameProject.Classes.UtilityClasses;
using _3902GameProject.Interfaces;

namespace _3902GameProject.Classes
{
    public class EnterMarthNormalGameCommand : ICommand
    {
        public EnterMarthNormalGameCommand()
        {
        }

        public void Execute()
        {
            Game1 game = Game1.GameInstance;
            game.LevelFile = StringConsts.Level1MarthFile;
            game.Scorekeeper.Level = StringConsts.Level1Code;
            game.Scorekeeper.Lives = MiscUtilityClass.MarthStartingLives;
            game.Scorekeeper.HitPoints = MiscUtilityClass.HitPoints;
            game.Type = Game1.GameType.MarthNormal;
            game.HeadsUpDisplay = new MarthJuggleHeadsUp();
            game.State = new TransitioningLifeScreen(120);
        }
    }
}
