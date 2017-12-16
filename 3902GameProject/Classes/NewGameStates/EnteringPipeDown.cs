using _3902GameProject.Classes.SystemSprites;
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
    public class EnteringPipeDown : IGameState
    {
        private int timer;
        private static RenderTarget2D gameRenderTarget;
        private float displacement;

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

        public EnteringPipeDown(int timerTotal)
        {
            SoundControl.PlaySoundEffect(Sound.pipeEffect);
            timer = timerTotal;
            gameRenderTarget = new RenderTarget2D(Game1.GameInstance.GraphicsDevice, Game1.GAME_WIDTH, Game1.GAME_HEIGHT);
            Level.GetPlayer(0).Physics.YVelocity = 0;
            Level.GetPlayer(0).Physics.XVelocity = 0;
            Level.GetPlayer(0).Update();
            displacement = 34.0f / timerTotal;
        }

        public void Update()
        {
            if (timer > 0)
            {
                timer--;
                Level.GetPlayer(0).Physics.YPosition += displacement;
            }
            else
            {
                IPlayer player = Level.GetPlayer(0);
                player.Physics.YPosition = MiscUtilityClass.PipeDestY;
                player.Physics.XPosition = MiscUtilityClass.PipeDestX;
                player.Stand();
                Camera.XPosition = MiscUtilityClass.PipeDestX - 16;
                Camera.YPosition = MiscUtilityClass.PipeDestY;
                Game1.GameInstance.State = new Playing(false);
                Camera.Fix = true;
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
