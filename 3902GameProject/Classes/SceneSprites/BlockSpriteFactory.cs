using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static _3902GameProject.Classes.GenericBlock;
using _3902GameProject.Interfaces;
using _3902GameProject.Classes.UtilityClasses;

namespace _3902GameProject.Classes
{
    public class BlockSpriteFactory
    {
        private Texture2D blockSpritesheet;

        private static BlockSpriteFactory instance = new BlockSpriteFactory();

        public static BlockSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private BlockSpriteFactory()
        {
        }

        public void LoadTextures(Microsoft.Xna.Framework.Content.ContentManager content)
        {
            blockSpritesheet = content.Load<Texture2D>(StringConsts.BlockSpriteSheet);
        }


        public Interfaces.IBlock CreateStoneBlock(int x, int y)
        {
            return new StoneBlock(x, y, blockSpritesheet, null);
        }

        public Interfaces.IBlock CreateQuestionBlock(int x, int y, Func<int, int, IItem> func)
        {
            return new QuestionBlock(x, y, blockSpritesheet, func);
        }

        public Interfaces.IBlock CreateHiddenBlock(int x, int y, Func<int, int, IItem> func)
        {
            return new HiddenBlock(x, y, blockSpritesheet, func);
        }

        public Interfaces.IBlock CreateGroundBlock(int x, int y)
        {
            return new GroundBlock(x, y, blockSpritesheet, null);
        }

        public Interfaces.IBlock CreateDarkGroundBlock(int x, int y)
        {
            return new DarkGroundBlock(x, y, blockSpritesheet, null);
        }

        public Interfaces.IBlock CreateBrickBlock(int x, int y, Func<int, int, IItem> func)
        {
            return new BrickBlock(x, y, blockSpritesheet, func);
        }

        public Interfaces.IBlock CreateDarkBrickBlock(int x, int y, Func<int, int, IItem> func)
        {
            return new DarkBrickBlock(x, y, blockSpritesheet, func);
        }

        public Interfaces.IBlock CreateMultiHitBrickBlock(int x, int y, Func<int, int, IItem> func, int hits)
        {
            return new MultiHitBrickBlock(x, y, blockSpritesheet, func, hits);
        }
    }
}
