﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3902GameProject.Classes.MarioSprites
{
    class RightBigDamageTransitionCrouchingSprite : GenericTallMarioSprite
    {
        private int timer = 0;
        public RightBigDamageTransitionCrouchingSprite(Texture2D spritesheet) : base(spritesheet)
        {
            SpriteByFrame.Add(0, new Rectangle(UtilityClasses.SpriteUtilityConsts.BRCMXPos1, 1, UtilityClasses.SpriteUtilityConsts.SmallSprite, UtilityClasses.SpriteUtilityConsts.BigSprite));
            SpriteByFrame.Add(1, new Rectangle(UtilityClasses.SpriteUtilityConsts.SRCMXPos1, UtilityClasses.SpriteUtilityConsts.SYPos1, UtilityClasses.SpriteUtilityConsts.SmallSprite, UtilityClasses.SpriteUtilityConsts.SmallSprite));
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
