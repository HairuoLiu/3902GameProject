using _3902GameProject.Classes.UtilityClasses;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3902GameProject.Classes.Portals
{
    class PortalSpriteFactory
    {
        private Texture2D PortalSpritesheet;

        private static PortalSpriteFactory instance = new PortalSpriteFactory();

        public static PortalSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private PortalSpriteFactory()
        {
        }

        public void LoadTextures(Microsoft.Xna.Framework.Content.ContentManager content)
        {
            PortalSpritesheet = content.Load<Texture2D>(StringConsts.PortalSpriteSheet);
        }


        public Interfaces.IPortal CreateOrangePortal(int x, int y)
        {
            return new OrangePortal(x, y, PortalSpritesheet);
        }

        public Interfaces.IPortal CreateBluePortal(int x, int y)
        {
            return new BluePortal(x, y, PortalSpritesheet);
        }
        public Interfaces.IPortal CreatePortalGun(int x, int y)
        {
            return new PortalGun(x, y, PortalSpritesheet);
        }

        public Interfaces.IPortal CreateFlippedPortalGun(int x, int y)
        {
            return new PortalGunFlipped(x, y, PortalSpritesheet);
        }
        public Interfaces.IPortal CreatePortalBlueBall(int x, int y, float vel)
        {
            return new BlueBall(x, y, vel, PortalSpritesheet);
        }
        public Interfaces.IPortal CreatePortalOrangeBall(int x, int y, float vel)
        {
            return new OrangeBall(x, y, vel, PortalSpritesheet);
        }
    }
}
