﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _3902GameProject.Classes
{
    public class RightBigToFireIdleState : GenericBigToFireState
    {
        public RightBigToFireIdleState(Mario mario) : base(mario)
        {
            MarioSprite = Classes.PlayerSpriteFactory.Instance.CreateRightBigToFireSprite();
        }
        public override void MakeFlag()
        {
            MarioInstance.State = new RightFlagHoldingFireMarioState(MarioInstance);
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
            return false;
        }

        public override void Damage()
        {
            MarioInstance.State = new RightIdleFireMarioState(MarioInstance);
        }
    }
}
