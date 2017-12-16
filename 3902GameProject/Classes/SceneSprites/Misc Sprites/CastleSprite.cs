using _3902GameProject.Classes.UtilityClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3902GameProject.Classes.SceneSprites.Misc_Sprites
{
    public class CastleSprite : GenericScenery
    {
        public CastleSprite(float x, float y, Texture2D spritesheet) : base(spritesheet)
        {
            XPosition = x;
            YPosition = y;
            SpriteByFrame.Add(0, SceneUtilityConsts.CastleRectangle);
            TotalFrames = 0;
            DrawWidth = SceneUtilityConsts.CastleDrawWidth;
            DrawHeight = SceneUtilityConsts.CastleDrawHeight;
        }
    }
}
