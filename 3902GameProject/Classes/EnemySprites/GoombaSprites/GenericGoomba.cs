using _3902GameProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3902GameProject.Classes
{
    public abstract class GenericGoomba : GenericEnemy
    {
        protected GenericGoomba(Texture2D spritesheet) : base(spritesheet)
        {
            DrawWidth = UtilityClasses.SpriteUtilityConsts.SmallSprite;
            DrawHeight = UtilityClasses.SpriteUtilityConsts.SmallSprite;
        }
    }
}
