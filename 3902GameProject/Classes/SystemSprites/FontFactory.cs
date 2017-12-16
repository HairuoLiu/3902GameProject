using _3902GameProject.Classes.UtilityClasses;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3902GameProject.Classes
{
    public class FontFactory
    {
        private SpriteFont HeadsUpFont;

        private static FontFactory instance = new FontFactory();

        public static FontFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private FontFactory()
        {

        }

        public void LoadFonts(ContentManager content)
        {
            HeadsUpFont = content.Load<SpriteFont>(StringConsts.FontHeadsUp);
        }

        public SpriteFont CreateHeadsUpFont()
        {
            return HeadsUpFont;
        }
    }
}
