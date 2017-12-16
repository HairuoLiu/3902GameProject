using _3902GameProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3902GameProject.Classes
{
    public class PortalInstructionScreen : IGameState
    {
        
        public PortalInstructionScreen()
        {
            Game1.GameInstance.Type = Game1.GameType.None;
        }

        public void Update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                Game1.GameInstance.Type = Game1.GameType.MarioPortal;
                Game1.GameInstance.State = new Playing(true);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Game1.GameInstance.Graphics.GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            Texture2D texture = BackgroundFactory.Instance.CreatePortalInstructionTexture();
            spriteBatch.Draw(texture, new Rectangle(0, 0, (int)(Game1.WINDOW_WIDTH_BASE * Game1.Scale), (int)(Game1.WINDOW_HEIGHT_BASE * Game1.Scale)), Color.White);
            spriteBatch.End();
        }
    }
}
