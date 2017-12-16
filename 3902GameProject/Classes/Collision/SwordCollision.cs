using _3902GameProject.Classes.SystemSprites;
using _3902GameProject.Classes.UtilityClasses;
using _3902GameProject.Interfaces;
using System.Collections.Generic;
using static _3902GameProject.Game1;

namespace _3902GameProject.Classes
{
    public static class SwordCollision
    {
        public static void HandleCollisionsForSword(ISword sword, IList<IGameObject> collisions)
        {
            foreach (IGameObject obj in collisions)
            {
                if (obj is IEnemy enemy)
                {
                    if (enemy is JuggleEnemy jEnemy)
                    {
                        if (jEnemy.HitTimer > 0) continue;
                        else jEnemy.HitTimer = MiscUtilityClass.JuggleHitTimer;
                    }
                    SoundControl.PlaySoundEffect(Sound.kickEffect);
                    enemy.MakeFlipped(sword.LaunchDirection());
                    GameType Type = GameInstance.Type;
                    if (Type == GameType.MarthJuggle) GameInstance.Scorekeeper.Points += 1;
                    else if (Type == GameType.MarthNormal) GameInstance.Scorekeeper.KillEnemy(enemy, false);
                }
            }
        }
    }
}
