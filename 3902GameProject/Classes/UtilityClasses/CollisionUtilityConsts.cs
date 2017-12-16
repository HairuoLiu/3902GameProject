using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3902GameProject.Classes.UtilityClasses
{
    static class CollisionUtilityConsts
    {
        internal static readonly float MaxVel = 3.0f;
        internal static readonly float ArcInit = 1.6f;
        internal static readonly float PosReadjusterItems = 2.0f;
        internal static readonly float VelocityInitEnemies = 2.0f;
        internal static readonly int DeltaInit = 8;
        internal static readonly float VelocityCheck = 1.5f;
        internal static readonly int BigOverlapCheck = 2;
        internal static readonly int SmallOverlapCheck = 1;
    }
}
