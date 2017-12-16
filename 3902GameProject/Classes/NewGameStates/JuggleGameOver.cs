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
    public class JuggleGameOver : IGameState
    {
        private int timer;
        
        public JuggleGameOver(int timerTotal)
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

            Vector2 offset = new Vector2(-100, -0);
            Vector2 fullScreen = new Vector2(Game1.WINDOW_WIDTH_BASE * Game1.Scale / 2, Game1.WINDOW_HEIGHT_BASE * Game1.Scale);
            Vector2 oneThirdsScreen = new Vector2(fullScreen.X, fullScreen.Y / 3);
            Vector2 twoThirdsScreen = new Vector2(fullScreen.X, oneThirdsScreen.Y * 2);
            spriteBatch.DrawString(FontFactory.Instance.CreateHeadsUpFont(), "Game Over", oneThirdsScreen + offset, Color.White);
            spriteBatch.DrawString(FontFactory.Instance.CreateHeadsUpFont(), Game1.GameInstance.Scorekeeper.Points.ToString() + " Juggles", twoThirdsScreen + offset, Color.White);
            spriteBatch.End();
        }
    }
}
