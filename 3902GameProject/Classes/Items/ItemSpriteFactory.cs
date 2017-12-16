using _3902GameProject.Classes.UtilityClasses;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3902GameProject.Classes
{
    class ItemSpriteFactory
    {
        private Texture2D itemSpriteSheet;

        private static ItemSpriteFactory instance = new ItemSpriteFactory();
        
        public static ItemSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        } 

        private ItemSpriteFactory()
        {
        }

        public void LoadTextures(Microsoft.Xna.Framework.Content.ContentManager content)
        {
            itemSpriteSheet = content.Load<Texture2D>(StringConsts.ItemSpriteSheet);
        }

        public Interfaces.IItem CreateFireFlower(int x, int y)
        {
            return new FireFlower(x, y, itemSpriteSheet);
        }

        public Interfaces.IItem CreateStar(int x, int y)
        {
            return new SuperStar(x, y, itemSpriteSheet);
        }

        public Interfaces.IItem CreateLifeMushroom(int x, int y)
        {
            return new LifeMushroom(x, y, itemSpriteSheet);
        }

        public Interfaces.IItem CreateBigMushroom(int x, int y)
        {
            return new BigMushroom(x, y, itemSpriteSheet);
        }

        public Interfaces.IItem CreateCoin(int x, int y)
        {
            return new Coin(x, y, itemSpriteSheet);
        }

        public Interfaces.IItem CreateStaticCoin(int x, int y)
        {
            return new StaticCoin(x, y, itemSpriteSheet);
        }
    }
}
