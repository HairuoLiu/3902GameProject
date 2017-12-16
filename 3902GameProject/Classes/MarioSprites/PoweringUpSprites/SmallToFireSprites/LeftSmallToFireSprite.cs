using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3902GameProject.Classes.MarioSprites
{
    class LeftSmallToFireSprite : GenericTallMarioSprite
    {
        private int timer = 0;
        private int[] drawHeights = new int[] { UtilityClasses.SpriteUtilityConsts.BigSprite, UtilityClasses.SpriteUtilityConsts.SmallSprite, UtilityClasses.SpriteUtilityConsts.BigSprite, UtilityClasses.SpriteUtilityConsts.SmallSprite, UtilityClasses.SpriteUtilityConsts.BigSprite, UtilityClasses.SpriteUtilityConsts.SmallSprite, UtilityClasses.SpriteUtilityConsts.BigSprite, UtilityClasses.SpriteUtilityConsts.SmallSprite, UtilityClasses.SpriteUtilityConsts.BigSprite };
        public LeftSmallToFireSprite(Texture2D spritesheet) : base(spritesheet)
        {
            SpriteByFrame.Add(0, new Rectangle(UtilityClasses.SpriteUtilityConsts.BLIMXPos1, UtilityClasses.SpriteUtilityConsts.FYpos, UtilityClasses.SpriteUtilityConsts.SmallSprite, UtilityClasses.SpriteUtilityConsts.BigSprite));
            SpriteByFrame.Add(1, new Rectangle(UtilityClasses.SpriteUtilityConsts.SLIMXPos1, UtilityClasses.SpriteUtilityConsts.SYPos1, UtilityClasses.SpriteUtilityConsts.SmallSprite, UtilityClasses.SpriteUtilityConsts.SmallSprite));
            SpriteByFrame.Add(2, new Rectangle(UtilityClasses.SpriteUtilityConsts.BLIMXPos1, UtilityClasses.SpriteUtilityConsts.FYpos, UtilityClasses.SpriteUtilityConsts.SmallSprite, UtilityClasses.SpriteUtilityConsts.BigSprite));
            SpriteByFrame.Add(3, new Rectangle(UtilityClasses.SpriteUtilityConsts.SLIMXPos1, UtilityClasses.SpriteUtilityConsts.SYPos1, UtilityClasses.SpriteUtilityConsts.SmallSprite, UtilityClasses.SpriteUtilityConsts.SmallSprite));
            SpriteByFrame.Add(4, new Rectangle(UtilityClasses.SpriteUtilityConsts.BLIMXPos1, UtilityClasses.SpriteUtilityConsts.FYpos, UtilityClasses.SpriteUtilityConsts.SmallSprite, UtilityClasses.SpriteUtilityConsts.BigSprite));
            SpriteByFrame.Add(5, new Rectangle(UtilityClasses.SpriteUtilityConsts.SLIMXPos1, UtilityClasses.SpriteUtilityConsts.SYPos1, UtilityClasses.SpriteUtilityConsts.SmallSprite, UtilityClasses.SpriteUtilityConsts.SmallSprite));
            SpriteByFrame.Add(6, new Rectangle(UtilityClasses.SpriteUtilityConsts.BLIMXPos1, UtilityClasses.SpriteUtilityConsts.FYpos, UtilityClasses.SpriteUtilityConsts.SmallSprite, UtilityClasses.SpriteUtilityConsts.BigSprite));
            SpriteByFrame.Add(7, new Rectangle(UtilityClasses.SpriteUtilityConsts.BLIMXPos1, UtilityClasses.SpriteUtilityConsts.FYpos, UtilityClasses.SpriteUtilityConsts.SmallSprite, UtilityClasses.SpriteUtilityConsts.SmallSprite));
            SpriteByFrame.Add(8, new Rectangle(UtilityClasses.SpriteUtilityConsts.SLIMXPos1, UtilityClasses.SpriteUtilityConsts.SYPos1, UtilityClasses.SpriteUtilityConsts.SmallSprite, UtilityClasses.SpriteUtilityConsts.BigSprite));

            TotalFrames = UtilityClasses.SpriteUtilityConsts.LargeFrameCount;
            FrameDelay = UtilityClasses.SpriteUtilityConsts.SmallDelay;
        }

        public override void Update()
        {
            timer++;
            DrawHeight = drawHeights[(timer / UtilityClasses.SpriteUtilityConsts.divisor) % TotalFrames];
            base.Update();
        }
    }
}
