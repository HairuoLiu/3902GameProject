using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _3902GameProject.Classes.UtilityClasses;

namespace _3902GameProject.Classes
{
    public class RightPipeTop : GenericPipe
    {
        public RightPipeTop(float x, float y, Texture2D spritesheet) : base(spritesheet)
        {
            XPosition = x;
            YPosition = y;
            SpriteByFrame.Add(0, SceneUtilityConsts.RightPipeTopRectangle);
            TotalFrames = 0;
        }
    }
}
