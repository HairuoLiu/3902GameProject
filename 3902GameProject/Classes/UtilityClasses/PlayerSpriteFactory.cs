using _3902GameProject.Classes.MarioSprites;
using _3902GameProject.Classes.UtilityClasses;
using _3902GameProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _3902GameProject.Classes
{
    public class PlayerSpriteFactory
    {
        private Texture2D marioSpritesheet;
        private Texture2D marthSpritesheet;
        private Texture2D swordSpritesheet;
        private static PlayerSpriteFactory instance = new PlayerSpriteFactory();

        public static PlayerSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private PlayerSpriteFactory()
        {
        }

        public void LoadTextures(Microsoft.Xna.Framework.Content.ContentManager content)
        {
            marioSpritesheet = content.Load<Texture2D>(StringConsts.MarioSpriteSheet);
            marthSpritesheet = content.Load<Texture2D>("MarthSpriteSheet");
            swordSpritesheet = content.Load<Texture2D>("SwordSpriteSheet");
        }

        public ISprite CreateLeftIdleSmallMarioSprite()
        {
            return new LeftIdleSmallMarioSprite(marioSpritesheet);
        }

        public ISprite CreateLeftIdleBigMarioSprite()
        {
            return new LeftIdleBigMarioSprite(marioSpritesheet);
        }
        
        public ISprite CreateLeftIdleFireMarioSprite()
        {
            return new LeftIdleFireMarioSprite(marioSpritesheet);
        }

        public ISprite CreateRightIdleSmallMarioSprite()
        {
            return new RightIdleSmallMarioSprite(marioSpritesheet);
        }

        public ISprite CreateRightIdleBigMarioSprite()
        {
            return new RightIdleBigMarioSprite(marioSpritesheet);
        }

        public ISprite CreateRightIdleFireMarioSprite()
        {
            return new RightIdleFireMarioSprite(marioSpritesheet);
        }

        public ISprite CreateLeftWalkingSmallMarioSprite()
        {
            return new LeftWalkingSmallMarioSprite(marioSpritesheet);
        }

        public ISprite CreateLeftWalkingBigMarioSprite()
        {
            return new LeftWalkingBigMarioSprite(marioSpritesheet);
        }

        public ISprite CreateLeftWalkingFireMarioSprite()
        {
            return new LeftWalkingFireMarioSprite(marioSpritesheet);
        }

        public ISprite CreateLeftRunningSmallMarioSprite()
        {
            return new LeftRunningSmallMarioSprite(marioSpritesheet);
        }

        public ISprite CreateLeftRunningBigMarioSprite()
        {
            return new LeftRunningBigMarioSprite(marioSpritesheet);
        }

        public ISprite CreateLeftRunningFireMarioSprite()
        {
            return new LeftRunningFireMarioSprite(marioSpritesheet);
        }

        public ISprite CreateRightWalkingSmallMarioSprite()
        {
            return new RightWalkingSmallMarioSprite(marioSpritesheet);
        }

        public ISprite CreateRightWalkingBigMarioSprite()
        {
            return new RightWalkingBigMarioSprite(marioSpritesheet);
        }

        public ISprite CreateRightWalkingFireMarioSprite()
        {
            return new RightWalkingFireMarioSprite(marioSpritesheet);
        }
        public ISprite CreateRightRunningSmallMarioSprite()
        {
            return new RightRunningSmallMarioSprite(marioSpritesheet);
        }
        public ISprite CreateRightRunningBigMarioSprite()
        {
            return new RightRunningBigMarioSprite(marioSpritesheet);
        }

        public ISprite CreateRightRunningFireMarioSprite()
        {
            return new RightRunningFireMarioSprite(marioSpritesheet);
        }

        public ISprite CreateRightJumpingSmallMarioSprite()
        {
            return new RightJumpingSmallMarioSprite(marioSpritesheet);
        }

        public ISprite CreateRightJumpingBigMarioSprite()
        {
            return new RightJumpingBigMarioSprite(marioSpritesheet);
        }

        public ISprite CreateRightJumpingFireMarioSprite()
        {
            return new RightJumpingFireMarioSprite(marioSpritesheet);
        }

        public ISprite CreateLeftJumpingSmallMarioSprite()
        {
            return new LeftJumpingSmallMarioSprite(marioSpritesheet);
        }

        public ISprite CreateLeftJumpingBigMarioSprite()
        {
            return new LeftJumpingBigMarioSprite(marioSpritesheet);
        }

        public ISprite CreateLeftJumpingFireMarioSprite()
        {
            return new LeftJumpingFireMarioSprite(marioSpritesheet);
        }

        public ISprite CreateLeftCrouchingBigMarioSprite()
        {
            return new LeftCrouchingBigMarioSprite(marioSpritesheet);
        }

        public ISprite CreateLeftCrouchingFireMarioSprite()
        {
            return new LeftCrouchingFireMarioSprite(marioSpritesheet);
        }

        public ISprite CreateLeftCrouchingSmallMarioSprite()
        {
            return new LeftCrouchingSmallMarioSprite(marioSpritesheet);
        }

        public ISprite CreateRightCrouchingBigMarioSprite()
        {
            return new RightCrouchingBigMarioSprite(marioSpritesheet);
        }

        public ISprite CreateRightCrouchingFireMarioSprite()
        {
            return new RightCrouchingFireMarioSprite(marioSpritesheet);
        }

        public ISprite CreateRightCrouchingSmallMarioSprite()
        {
            return new RightCrouchingSmallMarioSprite(marioSpritesheet);
        }

        public ISprite CreateDeadMarioSprite()
        {
            return new DeadMarioSprite(marioSpritesheet);
        }

        public ISprite CreateLeftThrowingFireMarioSprite()
        {
            return new LeftThrowingFireMarioSprite(marioSpritesheet);
        }

        public ISprite CreateRightThrowingFireMarioSprite()
        {
            return new RightThrowingFireMarioSprite(marioSpritesheet);
        }

        public ISprite CreateLeftBigDamageTransitionCrouchingSprite()
        {
            return new LeftBigDamageTransitionCrouchingSprite(marioSpritesheet);
        }

        public ISprite CreateLeftBigDamageTransitionIdleSprite()
        {
            return new LeftBigDamageTransitionIdleSprite(marioSpritesheet);
        }

        public ISprite CreateLeftBigDamageTransitionWalkingSprite()
        {
            return new LeftBigDamageTransitionWalkingSprite(marioSpritesheet);
        }

        public ISprite CreateLeftBigDamageTransitionJumpingSprite()
        {
            return new LeftBigDamageTransitionJumpingSprite(marioSpritesheet);
        }

        public ISprite CreateRightBigDamageTransitionCrouchingSprite()
        {
            return new RightBigDamageTransitionCrouchingSprite(marioSpritesheet);
        }

        public ISprite CreateRightBigDamageTransitionIdleSprite()
        {
            return new RightBigDamageTransitionIdleSprite(marioSpritesheet);
        }

        public ISprite CreateRightBigDamageTransitionWalkingSprite()
        {
            return new RightBigDamageTransitionWalkingSprite(marioSpritesheet);
        }

        public ISprite CreateRightBigDamageTransitionJumpingSprite()
        {
            return new RightBigDamageTransitionJumpingSprite(marioSpritesheet);
        }

        public ISprite CreateLeftFireDamageTransitionCrouchingSprite()
        {
            return new LeftFireDamageTransitionCrouchingSprite(marioSpritesheet);
        }

        public ISprite CreateLeftFireDamageTransitionIdleSprite()
        {
            return new LeftFireDamageTransitionIdleSprite(marioSpritesheet);
        }

        public ISprite CreateLeftFireDamageTransitionWalkingSprite()
        {
            return new LeftFireDamageTransitionWalkingSprite(marioSpritesheet);
        }

        public ISprite CreateLeftFireDamageTransitionJumpingSprite()
        {
            return new LeftFireDamageTransitionJumpingSprite(marioSpritesheet);
        }

        public ISprite CreateRightFireDamageTransitionCrouchingSprite()
        {
            return new RightFireDamageTransitionCrouchingSprite(marioSpritesheet);
        }

        public ISprite CreateRightFireDamageTransitionIdleSprite()
        {
            return new RightFireDamageTransitionIdleSprite(marioSpritesheet);
        }

        public ISprite CreateRightFireDamageTransitionWalkingSprite()
        {
            return new RightFireDamageTransitionWalkingSprite(marioSpritesheet);
        }

        public ISprite CreateRightFireDamageTransitionJumpingSprite()
        {
            return new RightFireDamageTransitionJumpingSprite(marioSpritesheet);
        }

        public ISprite CreateLeftSmallToBigSprite()
        {
            return new LeftSmallToBigSprite(marioSpritesheet);
        }

        public ISprite CreateRightSmallToBigSprite()
        {
            return new RightSmallToBigSprite(marioSpritesheet);
        }

        public ISprite CreateLeftSmallToFireSprite()
        {
            return new LeftSmallToFireSprite(marioSpritesheet);
        }

        public ISprite CreateRightSmallToFireSprite()
        {
            return new RightSmallToFireSprite(marioSpritesheet);
        }

        public ISprite CreateLeftBigToFireSprite()
        {
            return new LeftBigToFireSprite(marioSpritesheet);
        }

        public ISprite CreateRightBigToFireSprite()
        {
            return new RightBigToFireSprite(marioSpritesheet);
        }

        public ISprite CreateRightFlagHoldingBigMarioSprite()
        {
            return new RightFlagHoldingBigMarioSprite(marioSpritesheet);
        }
        public ISprite CreateRightFlagHoldingFireMarioSprite()
        {
            return new RightFlagHoldingFireMarioSprite(marioSpritesheet);
        }

        public ISprite CreateRightFlagHoldingSmallMarioSprite()
        {
            return new RightFlagHoldingmallMarioSprite(marioSpritesheet);
        }

        public ISprite CreateRightWalkingMarthSprite()
        {
            return new RightWalkingMarthSprite(marthSpritesheet);
        }

        public ISprite CreateRightCrouchingMarthSprite()
        {
            return new RightCrouchingMarthSprite(marthSpritesheet);
        }

        public ISprite CreateRightIdleMarthSprite()
        {
            return new RightIdleMarthSprite(marthSpritesheet);
        }

        public ISprite CreateRightFallingMarthSprite()
        {
            return new RightFallingMarthSprite(marthSpritesheet);
        }

        public ISprite CreateRightJumpingMarthSprite()
        {
            return new RightJumpingMarthSprite(marthSpritesheet);
        }

        public ISprite CreateLeftWalkingMarthSprite()
        {
            return new LeftWalkingMarthSprite(marthSpritesheet);
        }

        public ISprite CreateLeftCrouchingMarthSprite()
        {
            return new LeftCrouchingMarthSprite(marthSpritesheet);
        }

        public ISprite CreateLeftIdleMarthSprite()
        {
            return new LeftIdleMarthSprite(marthSpritesheet);
        }

        public ISprite CreateLeftFallingMarthSprite()
        {
            return new LeftFallingMarthSprite(marthSpritesheet);
        }

        public ISprite CreateLeftJumpingMarthSprite()
        {
            return new LeftJumpingMarthSprite(marthSpritesheet);
        }

        public ISprite CreateRightSwingingMarthSprite()
        {
            return new RightSwingingMarthSprite(marthSpritesheet);
        }

        public ISprite CreateLeftSwingingMarthSprite()
        {
            return new LeftSwingingMarthSprite(marthSpritesheet);
        }

        public ISprite CreateLeftDamagingMarthSprite()
        {
            return new LeftDamagingMarthSprite(marthSpritesheet);
        }

        public ISprite CreateRightDamagingMarthSprite()
        {
            return new RightDamagingMarthSprite(marthSpritesheet);
        }

        public Texture2D CreateSword()
        {
            return swordSpritesheet;
        }
    }
}
