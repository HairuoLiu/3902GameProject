using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace _3902GameProject.Classes
{
    public abstract class GenericShortMarioSprite : GenericMarioSprite
    {
        protected GenericShortMarioSprite(Texture2D spritesheet) : base(spritesheet)
        {
            DrawWidth = UtilityClasses.SpriteUtilityConsts.SmallSprite;
            DrawHeight = UtilityClasses.SpriteUtilityConsts.SmallSprite;
        }
    }
}
