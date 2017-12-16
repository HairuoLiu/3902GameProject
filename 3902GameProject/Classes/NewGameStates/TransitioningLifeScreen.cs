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
    public class TransitioningLifeScreen : IGameState
    {
        private int timer;
        private Texture2D background = Game1.GameInstance.Content.Load<Texture2D>(StringConsts.BackgroundStart);

        public TransitioningLifeScreen(int timerTotal)
        {
            timer = timerTotal;
        }

        public void Update()
        {
            if (timer > 0) timer--;
            else Game1.GameInstance.State = new Playing(true);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Game1.GameInstance.Graphics.GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            
            Vector2 screen = new Vector2(Game1.WINDOW_WIDTH_BASE, Game1.WINDOW_HEIGHT_BASE);
            screen = screen * Game1.Scale;
            spriteBatch.Draw(background,new Rectangle(0, 0, (int)screen.X, (int)screen.Y),Color.White);
            Game1.GameInstance.HeadsUpDisplay.Draw(spriteBatch);

            spriteBatch.End();
        }
    }
}
