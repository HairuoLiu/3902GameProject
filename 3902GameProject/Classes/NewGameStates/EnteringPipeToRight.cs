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
    public class EnteringPipeToRight : IGameState
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

        public EnteringPipeToRight(int timerTotal)
        {
            SoundControl.PlaySoundEffect(Sound.pipeEffect);
            timer = timerTotal;
            gameRenderTarget = new RenderTarget2D(Game1.GameInstance.GraphicsDevice, Game1.GAME_WIDTH, Game1.GAME_HEIGHT);
            Level.GetPlayer(0).Physics.YVelocity = 0;
            Level.GetPlayer(0).Physics.XVelocity = 0;
            Level.GetPlayer(0).Update();
            displacement = 18.0f / timerTotal;
        }

        public void Update()
        {
            IPlayer player = Level.GetPlayer(0);
            if (timer > 0)
            {
                timer--;
                float xPos = player.Physics.XPosition + displacement;
                player.MoveRight();
                player.Update();
                player.Physics.XPosition = xPos;
            }
            else
            {
                player.Physics.YPosition = MiscUtilityClass.SidePipeDestY;
                player.Physics.XPosition = MiscUtilityClass.SidePipeDestX;
                Camera.XPosition = MiscUtilityClass.SidePipeDestX - 16;
                Camera.YPosition = 0;
                Game1.GameInstance.State = new ExitingPipeUp(MiscUtilityClass.PipeTransitionTime);
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
