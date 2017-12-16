using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3902GameProject.Classes.MarioSprites
{
    public class RightIdleMarthSprite : GenericMarthSprite
    {
        public RightIdleMarthSprite(Texture2D spritesheet) : base(spritesheet)
        {
            DrawWidth = 17;
            DrawHeight = 34;
            SpriteByFrame.Add(0, new Rectangle(2, 1, DrawWidth, DrawHeight));
            FrameDelay = 1;
            TotalFrames = 1;
        }

        public override void Draw(float x, float y, SpriteBatch spriteBatch, Color tint)
        {
            base.Draw(x, y - DrawHeight, spriteBatch, tint);
        }
    }
}
