using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _3902GameProject.Interfaces;
using _3902GameProject.Classes.UtilityClasses;

namespace _3902GameProject.Classes
{
    public class Score : IScore
    {
        private float time;
        private bool hasFlag;
        public int Time
        {
            get
            {
                return (int)time;
            }
            set
            {
                time = value;
            }
        }
        public string Level { get; set; }
        public int Coins { get; set; }
        public int Points { get; set; }
        public int Lives { get; set; }
        public int HitPoints { get; set; }
        private int scoreFromEnemy;
        private int minScoreFromEnemy = UtilityClasses.MiscUtilityClass.SmallScore;
        private int maxScoreFromEnemy = UtilityClasses.MiscUtilityClass.BigScore;
        public Score()
        {
            Level = StringConsts.Level1Code;
            Coins = 0;
            Points = 0;
            ResetTime();
            hasFlag = false;
            scoreFromEnemy = minScoreFromEnemy;
        }
        public void Update()
        {
            time -= 1f / UtilityClasses.MiscUtilityClass.TimeDivisor;
        }
        public void ResetTime()
        {
            time = UtilityClasses.MiscUtilityClass.StartingTime;
        }
        public void KillEnemy(IEnemy enemy, bool wasJump)
        {
            if (wasJump)
            {
                Points += scoreFromEnemy;
                scoreFromEnemy = Math.Min(2 * scoreFromEnemy, maxScoreFromEnemy);
            }
            else
            {
                Points += minScoreFromEnemy;
            }
        }
        public void ResetEnemyMultiplier()
        {
            scoreFromEnemy = minScoreFromEnemy;
        }
        public void CollectItem(IItem item)
        {
            Points += UtilityClasses.MiscUtilityClass.SmallScore;
            if (item is StaticCoin) Coins++;
            else if (item is LifeMushroom) Lives++;
        }
        public void GetFlag(float percentHeight)
        {
            if (!hasFlag)
            {
                hasFlag = true;
                if (percentHeight < .25f) percentHeight = 0.25f;
                else if (percentHeight < .5f) percentHeight = 0.5f;
                else if (percentHeight < .75f) percentHeight = 0.75f;
                else percentHeight = 1f;
                Points += UtilityClasses.MiscUtilityClass.SmallScore + UtilityClasses.MiscUtilityClass.FlagMultiplier * (int)(percentHeight * UtilityClasses.MiscUtilityClass.ScoreFlagMultiplier);
            }
        }
    }
}
