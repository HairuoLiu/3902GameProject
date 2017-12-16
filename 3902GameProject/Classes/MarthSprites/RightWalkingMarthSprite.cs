using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3902GameProject.Classes.MarioSprites
{
    public class RightWalkingMarthSprite : GenericMarthSprite
    {
        public RightWalkingMarthSprite(Texture2D spritesheet) : base(spritesheet)
        {
            DrawWidth = 23;
            DrawHeight = 34;
            SpriteByFrame.Add(0, new Rectangle(0, 113, DrawWidth, DrawHeight));
            SpriteByFrame.Add(1, new Rectangle(26, 113, DrawWidth, DrawHeight));
            SpriteByFrame.Add(2, new Rectangle(52, 113, DrawWidth, DrawHeight));
            SpriteByFrame.Add(3, new Rectangle(75, 113, DrawWidth, DrawHeight));
            SpriteByFrame.Add(4, new Rectangle(100, 113, DrawWidth, DrawHeight));
            SpriteByFrame.Add(5, new Rectangle(125, 113, DrawWidth, DrawHeight));
            FrameDelay = 8;
            TotalFrames = 6;
        }

        public override void Draw(float x, float y, SpriteBatch spriteBatch, Color tint)
        {
            base.Draw(x - 4, y - DrawHeight, spriteBatch, tint);
        }
    }
}
