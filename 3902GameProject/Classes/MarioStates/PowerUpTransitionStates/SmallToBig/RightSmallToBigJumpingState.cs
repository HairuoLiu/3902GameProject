﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _3902GameProject.Classes
{
    public class RightSmallToBigJumpingState : GenericSmallToBigState
    {
        public RightSmallToBigJumpingState(Mario mario) : base(mario)
        {
            MarioSprite = Classes.PlayerSpriteFactory.Instance.CreateRightSmallToBigSprite();
        }
        public override void MakeFlag()
        {
            MarioInstance.State = new RightFlagHoldingBigMarioState(MarioInstance);
        }
        public override bool IsFacingLeft()
        {
            return false;
        }

        public override bool IsCrouching()
        {
            return false;
        }

        public override bool IsJumping()
        {
            return true;
        }

        public override void Damage()
        {
            MarioInstance.State = new RightJumpingBigMarioState(MarioInstance);
        }
    }
}
