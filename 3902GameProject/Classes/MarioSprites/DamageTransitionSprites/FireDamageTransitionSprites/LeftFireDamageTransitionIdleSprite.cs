﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3902GameProject.Classes.MarioSprites
{
    class LeftFireDamageTransitionIdleSprite : GenericTallMarioSprite
    {
        private int timer = 0;
        public LeftFireDamageTransitionIdleSprite(Texture2D spritesheet) : base(spritesheet)
        {
            SpriteByFrame.Add(0, new Rectangle(UtilityClasses.SpriteUtilityConsts.BLIMXPos1, UtilityClasses.SpriteUtilityConsts.FYpos, UtilityClasses.SpriteUtilityConsts.SmallSprite, UtilityClasses.SpriteUtilityConsts.BigSprite));
            SpriteByFrame.Add(1, new Rectangle(UtilityClasses.SpriteUtilityConsts.SLIMXPos1, UtilityClasses.SpriteUtilityConsts.SYPos1, UtilityClasses.SpriteUtilityConsts.SmallSprite, UtilityClasses.SpriteUtilityConsts.SmallSprite));
            TotalFrames = UtilityClasses.SpriteUtilityConsts.SmallFrameCount;
            FrameDelay = UtilityClasses.SpriteUtilityConsts.TinyDelay;
        }

        public override void Update()
        {
            timer = 1 - timer;
            if (timer == 0)
                DrawHeight = UtilityClasses.SpriteUtilityConsts.FullDrawHeight - DrawHeight;
            base.Update();
        }
    }
}
