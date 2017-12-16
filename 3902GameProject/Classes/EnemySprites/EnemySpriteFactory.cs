using _3902GameProject.Classes.UtilityClasses;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3902GameProject.Classes
{
    public class EnemySpriteFactory
    {
        private Texture2D enemySpriteSheet;

        private static EnemySpriteFactory instance = new EnemySpriteFactory();

        public static EnemySpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private EnemySpriteFactory()
        {
        }

        public void LoadTextures(Microsoft.Xna.Framework.Content.ContentManager content)
        {
            enemySpriteSheet = content.Load<Texture2D>(StringConsts.EnemySpriteSheet);
        }

        public Interfaces.ISprite CreateRightWalkingTurtle()
        {
            return new RightTurtle(enemySpriteSheet);
        }

        public Interfaces.ISprite CreateLeftWalkingTurtle()
        {
            return new LeftTurtle(enemySpriteSheet);
        }

        public Interfaces.ISprite CreateDeadTurtle()
        {
            return new DeadTurtle(enemySpriteSheet);
        }

        public Interfaces.ISprite CreateFlippedTurtle()
        {
            return new FlippedTurtle(enemySpriteSheet);
        }

        public Interfaces.ISprite CreateGoomba()
        {
            return new WalkingGoomba(enemySpriteSheet);
        }

        public Interfaces.ISprite StompedGoomba()
        {
            return new StompedGoomba(enemySpriteSheet);
        }

        public Interfaces.ISprite FlippedGoomba()
        {
            return new FlippedGoomba(enemySpriteSheet);
        }

        public Texture2D CreateFireball()
        {
            return enemySpriteSheet;
        }
    }
}
