using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3902GameProject.Classes.MarioSprites
{
    public class LeftCrouchingMarthSprite : GenericMarthSprite
    {
        public LeftCrouchingMarthSprite(Texture2D spritesheet) : base(spritesheet)
        {
            DrawWidth = 33;
            DrawHeight = 19;
            SpriteByFrame.Add(0, new Rectangle(35, 40, DrawWidth, DrawHeight));
            FrameDelay = 1;
            TotalFrames = 1;
        }

        public override void Draw(float x, float y, SpriteBatch spriteBatch, Color tint)
        {
            base.Draw(x - 5, y - DrawHeight, spriteBatch, tint);
        }
    }
}
