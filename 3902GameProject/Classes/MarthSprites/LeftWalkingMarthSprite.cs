using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3902GameProject.Classes.MarioSprites
{
    public class LeftWalkingMarthSprite : GenericMarthSprite
    {
        public LeftWalkingMarthSprite(Texture2D spritesheet) : base(spritesheet)
        {
            DrawWidth = 34;
            DrawHeight = 34;
            SpriteByFrame.Add(0, new Rectangle(151, 151, DrawWidth, DrawHeight));
            SpriteByFrame.Add(1, new Rectangle(119, 151, DrawWidth, DrawHeight));
            SpriteByFrame.Add(2, new Rectangle(86, 151, DrawWidth, DrawHeight));
            SpriteByFrame.Add(3, new Rectangle(57, 151, DrawWidth, DrawHeight));
            SpriteByFrame.Add(4, new Rectangle(29, 151, DrawWidth, DrawHeight));
            SpriteByFrame.Add(5, new Rectangle(0, 151, DrawWidth, DrawHeight));
            FrameDelay = 8;
            TotalFrames = 6;
        }

        public override void Draw(float x, float y, SpriteBatch spriteBatch, Color tint)
        {
            base.Draw(x - 13, y - DrawHeight, spriteBatch, tint);
        }
    }
}
