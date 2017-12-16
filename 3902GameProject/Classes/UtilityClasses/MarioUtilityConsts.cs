using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3902GameProject.Classes.UtilityClasses
{
    static class MarioUtilityConsts
    {
        internal static readonly int EndDamageTotal = 60;
        internal static readonly float Gravity = 0.3f;
        internal static readonly float MaxXSpeed = 1.5f;
        internal static readonly float MaxXSpeedRun = 2.5f;
        internal static readonly float MaxYSpeed = 5.0f;
        internal static readonly float WalkAcceleration = 0.4f;
        internal static readonly float JumpBase = 3.5f;
        internal static readonly float JumpScale = 5f;
        internal static readonly int DeathHeight = 600;
        internal static readonly float Tolerance = 0.1f;
        internal static readonly int ThrowTimer = 8;
        internal static readonly int MaxFireballs = 2;
    }
}
