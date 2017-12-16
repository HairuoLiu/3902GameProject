using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace _3902GameProject.Classes
{
    public abstract class GenericTallMarioSprite : GenericMarioSprite
    {
        protected GenericTallMarioSprite(Texture2D spritesheet) : base(spritesheet)
        {
            DrawWidth = UtilityClasses.SpriteUtilityConsts.SmallSprite;
            DrawHeight = UtilityClasses.SpriteUtilityConsts.BigSprite;
        }
    }
}
