using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3902GameProject.Classes.UtilityClasses
{
    static class GoombaUtilityConsts
    {
        internal static readonly float XSpeed = 0.5f;
        internal static readonly float YSpeed = 2f;
        internal static readonly float YFlipSpeed = 5f;
        internal static readonly float XFlipSpeed = 2f;
        internal static readonly float FlipGravity = 0.5f;

        internal static readonly int WakeOffset = 250;
        internal static readonly int RemoveBodyTotal = 60;
        internal static readonly int Height = 16;
    }
}
