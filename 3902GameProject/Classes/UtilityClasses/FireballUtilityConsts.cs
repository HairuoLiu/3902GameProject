using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3902GameProject.Classes.UtilityClasses
{
    static class FireballUtilityConsts
    {
        internal static readonly int DrawSmall = 8;
        internal static readonly int DrawLarge = 16;
        internal static readonly Rectangle FireballRec1 = new Rectangle(26, 150, 8, 8);
        internal static readonly Rectangle FireballRec2 = new Rectangle(41, 150, 8, 8);
        internal static readonly Rectangle FireballRec3 = new Rectangle(26, 165, 8, 8);
        internal static readonly Rectangle FireballRec4 = new Rectangle(41, 165, 8, 8);
        internal static readonly int Frames = 4;
        internal static readonly int FrameDelay = 4;
        internal static readonly float XSpeed = 4;
        internal static readonly float YSpeed = 3;
        internal static readonly int ExplostionTotal = 7;
        internal static readonly float Gravity = 0.4f;

        internal static readonly int DestroyXOffset = 4;
        internal static readonly int DestroyFrames = 3;
        internal static readonly int DestroyFrameDelay = 2;
        internal static readonly Rectangle DestroyFireballRec1 = new Rectangle(360, 184, 16, 16);
        internal static readonly Rectangle DestroyFireballRec2 = new Rectangle(390, 184, 16, 16);
        internal static readonly Rectangle DestroyFireballRec3 = new Rectangle(420, 184, 16, 16);
    }
}
