using _3902GameProject.Classes.UtilityClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3902GameProject.Classes.MarioSprites
{
    public class RightSwingingMarthSprite : GenericMarthSprite
    {
        public RightSwingingMarthSprite(Texture2D spritesheet) : base(spritesheet)
        {
            DrawWidth = 24;
            DrawHeight = 33;
            SpriteByFrame.Add(0, new Rectangle(145, 38, DrawWidth, DrawHeight));
            SpriteByFrame.Add(1, new Rectangle(172, 38, DrawWidth, DrawHeight));
            SpriteByFrame.Add(2, new Rectangle(172, 38, DrawWidth, DrawHeight));
            FrameDelay = MiscUtilityClass.SwingFrameTime;
            TotalFrames = 3;
        }

        public override void Draw(float x, float y, SpriteBatch spriteBatch, Color tint)
        {
            base.Draw(x - 3, y - DrawHeight, spriteBatch, tint);
        }
    }
}
