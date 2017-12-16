using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3902GameProject.Classes.UtilityClasses
{
    static class MiscUtilityClass
    {
        internal static readonly int FlashDelay = 5;
        internal static readonly int StarTimer = 300;
        internal static readonly int SmallScore = 100;
        internal static readonly int BigScore = 1600;
        internal static readonly int StartingTime = 300;
        internal static readonly int MarioStartingLives = 3;
        internal static readonly float TimeDivisor = 60f;
        internal static readonly int FlagMultiplier = 4;
        internal static readonly int ScoreFlagMultiplier = 400;
        internal static readonly int HitTimer = 180;
        internal static readonly int JumpTimer = 15;
        internal static readonly int Even = 2;
        internal static readonly float RunningVel = 2.0f;
        internal static readonly float SmallDamp = 0.2f;
        internal static readonly float LargeDamp = 0.3f;
        internal static readonly float Grav = 0.4f;

        internal static readonly int WorldXOffset = 10;
        internal static readonly int TopLevelYOffset = 10;
        internal static readonly int BottomLevelYOffset = 50;

        internal static readonly int PipeDestX = 112;
        internal static readonly int PipeDestY = 416;
        internal static readonly int SidePipeDestX = 2618;
        internal static readonly int SidePipeDestY = 180;
        internal static readonly int PipeTransitionTime = 80;

        internal static readonly int CastleEntranceX = 3260;
        internal static readonly int MarthCastleEntranceX = 2096;

        internal static readonly int VictoryTimer = 120;

        internal static readonly int SwingFrameTime = 4;
        internal static readonly float SwingLaunchMagnitude = 5.0f;
        internal static readonly float SwingGravity = 0.2f;
        internal static readonly int HitPoints = 2;
        internal static readonly int MarthStartingLives = 1;
        internal static readonly int JuggleHitTimer = 16;

        internal static readonly int FlagFallTimer = 108;
        internal static readonly float MarthWalkSpeed = 1f;
        internal static readonly float MarthJumpInitial = 4.0f;
        internal static readonly float MarthJumpContinue = 0.1f;
    }
}
