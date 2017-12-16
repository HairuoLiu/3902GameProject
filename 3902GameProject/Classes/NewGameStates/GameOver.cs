using _3902GameProject.Classes.UtilityClasses;
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
    public class GameOver : IGameState
    {
        private int timer;
        private Texture2D background = Game1.GameInstance.Content.Load<Texture2D>(StringConsts.BackgroundGameover);

        public GameOver(int timerTotal)
        {
            timer = timerTotal;
            Game1.GameInstance.Type = Game1.GameType.None;
        }

        public void Update()
        {
            if (timer > 0) timer--;
            else Game1.GameInstance.State = new MainMenu();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Game1.GameInstance.Graphics.GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            spriteBatch.Draw(background, new Rectangle(0, 0, (int)(Game1.WINDOW_WIDTH_BASE * Game1.Scale), (int)(Game1.WINDOW_HEIGHT_BASE * Game1.Scale)), Color.White);
            spriteBatch.End();
        }
    }
}
