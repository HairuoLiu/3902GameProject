using _3902GameProject.Classes.SceneSprites.Misc_Sprites;
using _3902GameProject.Classes.UtilityClasses;
using _3902GameProject.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3902GameProject.Classes
{
    public class SceneSpriteFactory
    {
        internal Texture2D sceneSpriteSheet;

        private static SceneSpriteFactory instance = new SceneSpriteFactory();

        public static SceneSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private SceneSpriteFactory()
        {
        }

        public void LoadTextures(Microsoft.Xna.Framework.Content.ContentManager content)
        {
            sceneSpriteSheet = content.Load<Texture2D>(StringConsts.ScenerySpriteSheet);
        }

        public Interfaces.IPipe CreateLeftPipeTop(int x, int y)
        {
            return new LeftPipeTop(x, y, sceneSpriteSheet);
        }

        public Interfaces.IPipe CreateLeftPipePiece(int x, int y)
        {
            return new LeftPipePiece(x, y, sceneSpriteSheet);
        }

        public Interfaces.IPipe CreateRightPipeTop(int x, int y)
        {
            return new RightPipeTop(x, y, sceneSpriteSheet);
        }

        public Interfaces.IPipe CreateRightPipePiece(int x, int y)
        {
            return new RightPipePiece(x, y, sceneSpriteSheet);
        }

        public Interfaces.IPipe CreateHorPipe(int x, int y)
        {
            return new HorPipe(x, y, sceneSpriteSheet);
        }

        public CastleSprite CreateCastle(int x, int y)
        {
            return new CastleSprite(x, y, sceneSpriteSheet);
        }

        public FlagIdleSprites CreateIdleFlag(int x, int y)
        {
            return new FlagIdleSprites(x, y, sceneSpriteSheet);
        }

        public Flag4StepAnimationSprites CreateFlagSprites(int x, int y)
        {
            return new Flag4StepAnimationSprites(x, y, sceneSpriteSheet);
        }

        public IScenery CreateFlagPole(int x, int y)
        {
            return new FlagPoleSprite(x, y, sceneSpriteSheet);
        }

        public IScenery CreateFlag(int x, int y)
        {
            return new FlagSprite(x, y, sceneSpriteSheet);
        }

        public IScenery CreateFinishLine(int x, int y)
        {
            return new FinishLineSprite(x, y, sceneSpriteSheet);
        }
    }
}
