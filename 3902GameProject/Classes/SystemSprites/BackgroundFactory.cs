using _3902GameProject.Classes.UtilityClasses;
using _3902GameProject.Interfaces;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3902GameProject.Classes
{
    public class BackgroundFactory
    {
        private Texture2D menuTexture;
        private Texture2D juggleInstructionTexture;
        private Texture2D controlsTexture;
        private Texture2D portalInstructionTexture;

        private static BackgroundFactory instance = new BackgroundFactory();

        public static BackgroundFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private BackgroundFactory()
        {

        }

        public void LoadBackgrounds(ContentManager content)
        {
            menuTexture = content.Load<Texture2D>("Background/menu");
            juggleInstructionTexture = content.Load<Texture2D>("Background/juggleinstructions");
            controlsTexture = content.Load<Texture2D>("Background/controls");
            portalInstructionTexture = content.Load<Texture2D>("Background/portalinstructions");
        }

        public ISprite CreateMenuBackground()
        {
            return new MenuBackground(menuTexture);
        }

        public Texture2D CreateJuggleInstructionTexture()
        {
            return juggleInstructionTexture;
        }

        public Texture2D CreateControlsTexture()
        {
            return controlsTexture;
        }

        public Texture2D CreatePortalInstructionTexture()
        {
            return portalInstructionTexture;
        }

        public IGameObject CreateWhiteRectangle()
        {
            return new YellowRectangle(menuTexture);
        }
    }
}
