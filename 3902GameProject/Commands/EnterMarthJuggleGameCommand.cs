using _3902GameProject.Classes.UtilityClasses;
using _3902GameProject.Interfaces;

namespace _3902GameProject.Classes
{
    public class EnterMarthJuggleGameCommand : ICommand
    {
        public EnterMarthJuggleGameCommand()
        {
        }

        public void Execute()
        {
            Game1 game = Game1.GameInstance;
            game.LevelFile = StringConsts.JuggleLevelMarth;
            game.Scorekeeper.Level = StringConsts.LevelMarthCode;
            game.Scorekeeper.Lives = MiscUtilityClass.MarthStartingLives;
            game.Scorekeeper.HitPoints = MiscUtilityClass.HitPoints;
            game.Type = Game1.GameType.MarthJuggle;
            game.HeadsUpDisplay = new MarthJuggleHeadsUp();
            game.State = new JuggleInstructionScreen();
        }
    }
}
