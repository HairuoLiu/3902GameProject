using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3902GameProject.Classes.MarioSprites
{
    public class LeftJumpingMarthSprite : GenericMarthSprite
    {
        public LeftJumpingMarthSprite(Texture2D spritesheet) : base(spritesheet)
        {
            DrawWidth = 14;
            DrawHeight = 35;
            SpriteByFrame.Add(0, new Rectangle(48, 67, DrawWidth, DrawHeight));
            FrameDelay = 1;
            TotalFrames = 1;
        }

        public override void Draw(float x, float y, SpriteBatch spriteBatch, Color tint)
        {
            base.Draw(x + 1, y - DrawHeight, spriteBatch, tint);
        }
    }
}
