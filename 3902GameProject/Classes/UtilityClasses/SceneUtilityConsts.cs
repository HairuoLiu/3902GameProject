using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3902GameProject.Classes.UtilityClasses
{
    class SceneUtilityConsts
    {
        internal static readonly int DrawWidth = 16;
        internal static readonly int DrawHeight = 16;

        internal static readonly int TotalBouncingFrames = 15;
        internal static readonly int[] BouncingOffset = new int[] { -1, -2, -2, -1, 0, -1, 0, 0, 1, 1, 1, 1, 2, 2, -1 };

        internal static readonly float Depth = 0.3f;
        internal static readonly Rectangle Empty = new Rectangle(0, 0, 0, 0);
        internal static readonly Rectangle UsedBlockRectangle = new Rectangle(4, 22, 16, 16);
        internal static readonly Rectangle GroundBlockRectangle = new Rectangle(4, 81, 16, 16);
        internal static readonly Rectangle BrickBlockRectangle = new Rectangle(4, 4, 16, 16);
        internal static readonly Rectangle QuestionBlockRectangle1 = new Rectangle(3, 117, 16, 16);
        internal static readonly Rectangle QuestionBlockRectangle2 = new Rectangle(21, 117, 16, 16);
        internal static readonly Rectangle QuestionBlockRectangle3 = new Rectangle(39, 117, 16, 16);
        internal static readonly Rectangle DarkGroundBlockRectangle = new Rectangle(24, 81, 16, 16);
        internal static readonly Rectangle DarkBrickBlockRectangle = new Rectangle(24, 4, 16, 16);
        internal static readonly Rectangle DarkBrickBitRectangle = new Rectangle(63, 21, 16, 16);
        internal static readonly Rectangle BrickBitRectangle = new Rectangle(63, 4, 16, 16);
        internal static readonly Rectangle StoneBlockRectangle = new Rectangle(4, 99, 16, 16);

        internal static readonly int QuestionBlockFrameDelay = 8;
        internal static readonly int QuestionBlockTotalFrames = 6;

        internal static readonly float BitLaunchSpeedX = 1.0f;
        internal static readonly float BitLaunchSpeedY = 3.0f;
        internal static readonly float Gravity = 0.2f;
        internal static readonly int DestroyTimerStart = -1;
        internal static readonly int DestroyTimerEnd = 3;
        internal static readonly int RemoveTimerTotal = 200;

        internal static readonly Rectangle CastleRectangle = new Rectangle(247, 863, 80, 80);
        internal static readonly int CastleDrawWidth = 80;
        internal static readonly int CastleDrawHeight = 80;

        internal static readonly Rectangle FlagRectangle1 = new Rectangle(249, 594, 24, 168);
        internal static readonly Rectangle FlagRectangle2 = new Rectangle(215, 594, 24, 168);
        internal static readonly Rectangle FlagRectangle3 = new Rectangle(181, 594, 24, 168);
        internal static readonly Rectangle FlagRectangle4 = new Rectangle(148, 594, 24, 168);
        internal static readonly Rectangle FlagRectangle5 = new Rectangle(115, 594, 24, 168);
        internal static readonly int FlagDrawWidth = 24;
        internal static readonly int FlagDrawHeight = 168;
        internal static readonly int FlagFrames = 5;

        internal static readonly int BlockPoints = 100;

        internal static readonly float SceneryDepth = 0.1f;
        internal static readonly int SceneryFrameDelay = 5;
        internal static readonly int ExceptionFrame = 4;

        internal static readonly int HorPipeWidth = 39;
        internal static readonly int HorPipeHeight = 32;
        internal static readonly float PipeDepth = 0.99f;
        internal static readonly int PipeWidth = 16;
        internal static readonly int PipeHeight = 16;
        internal static readonly Rectangle HorPipeRectangle = new Rectangle(156, 417, 39, 32);
        internal static readonly Rectangle LeftPipePieceRectangle = new Rectangle(230, 433, 16, 16);
        internal static readonly Rectangle LeftPipeTopRectangle = new Rectangle(309, 417, 16, 16);
        internal static readonly Rectangle RightPipePieceRectangle = new Rectangle(246, 433, 16, 16);
        internal static readonly Rectangle RightPipeTopRectangle = new Rectangle(325, 417, 16, 16);

    }
}
