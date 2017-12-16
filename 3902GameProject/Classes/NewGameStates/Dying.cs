using _3902GameProject.Classes.SystemSprites;
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
    public class Dying : IGameState
    {
        int timer;
        private static RenderTarget2D gameRenderTarget;

        public static ILevel Level
        {
            get
            {
                return Game1.GameInstance.GameLevel;
            }
            set
            {
                Game1.GameInstance.GameLevel = value;
            }
        }
        public static ICamera Camera
        {
            get
            {
                return Game1.GameInstance.TempCamera;
            }
            set
            {
                Game1.GameInstance.TempCamera = value;
            }
        }

        public Dying(int timerTotal)
        {
            // Sound cue for dying mario should go here
            timer = timerTotal;
            gameRenderTarget = new RenderTarget2D(Game1.GameInstance.GraphicsDevice, Game1.GAME_WIDTH, Game1.GAME_HEIGHT);
            Level.GetPlayer(0).Physics.YVelocity = -2;
            Level.GetPlayer(0).Physics.XVelocity = 0;
            Level.GetPlayer(0).Physics.Gravity = 1.0f / 12;
        }

        public void Update()
        {
            if (timer > 0)
            {
                timer--;
                Level.GetPlayer(0).Update();
            }
            else if (Game1.GameInstance.Type == Game1.GameType.MarthJuggle)
            {
                Game1.GameInstance.State = new JuggleGameOver(240);
            }
            else if (Game1.GameInstance.Scorekeeper.Lives > 0)
            {
                Game1.GameInstance.State = new TransitioningLifeScreen(120);
                Game1.GameInstance.Scorekeeper.ResetTime();
            }
            else
            {
                Game1.GameInstance.State = new GameOver(120);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Camera.Update(new Vector2(Level.GetPlayer(0).Physics.XPosition, Level.GetPlayer(0).Physics.YPosition));
            Game1.GameInstance.GraphicsDevice.SetRenderTarget(gameRenderTarget);
            spriteBatch.Begin(SpriteSortMode.FrontToBack);
            DrawSprites(spriteBatch);
            spriteBatch.End();

            Game1.GameInstance.GraphicsDevice.SetRenderTarget(null);
            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, RasterizerState.CullNone, null, transformMatrix: null);
            spriteBatch.Draw(gameRenderTarget, 
                new Rectangle(0, 0, Game1.GameInstance.Graphics.PreferredBackBufferWidth, Game1.GameInstance.Graphics.PreferredBackBufferHeight), 
                new Rectangle(Camera.XPosition, Camera.YPosition, Game1.WINDOW_WIDTH_BASE, Game1.WINDOW_HEIGHT_BASE), 
                Color.White);
            Game1.GameInstance.HeadsUpDisplay.Draw(spriteBatch);
            spriteBatch.End();
        }

        private static void DrawSprites(SpriteBatch spriteBatch)
        {
            Game1.GameInstance.BackgroundSprite.Draw(0, 0, spriteBatch, Color.White);
            Level.Draw(spriteBatch);
        }
    }
}
