using _3902GameProject.Classes.SystemSprites;
using _3902GameProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static _3902GameProject.Game1;

namespace _3902GameProject.Classes
{
    public class Playing : IGameState
    {
        private int pauseTimer;
        private IList<IGameObject> unpausedObjects;
        private static RenderTarget2D gameRenderTarget;

        public static ILevel Level
        {
            get
            {
                return GameInstance.GameLevel;
            }
            set
            {
                GameInstance.GameLevel = value;
            }
        }
        public static ICamera Camera
        {
            get
            {
                return GameInstance.TempCamera;
            }
            set
            {
                GameInstance.TempCamera = value;
            }
        }
        public static GameType Type
        {
            get
            {
                return GameInstance.Type;
            }
        }

        public Playing(bool makeLevel)
        {
            if (makeLevel)
            {
                Level = new Level();
                Camera = new RestrictedTempCamera();
                Camera.Update(new Vector2(Level.GetPlayer(0).Physics.XPosition, Level.GetPlayer(0).Physics.YPosition));
            }

            SoundControl.PlaySong(Sound.mainTheme, true);
            pauseTimer = 0;
            gameRenderTarget = new RenderTarget2D(GameInstance.GraphicsDevice, GAME_WIDTH, GAME_HEIGHT);
            if (Type == GameType.MarioNormal || Type == GameType.MarioPortal) GameInstance.InitializeMarioControllers();
            else if (Type == GameType.MarthJuggle || Type == GameType.MarthNormal) GameInstance.InitializeMarthControllers();
            if (Type == GameType.MarioPortal)
            {
                Camera = new UnrestrictedTempCamera();
            }
        }

        public void Update()
        {
            if (Type == GameType.MarioNormal) MarioNormalGameUpdate();
            else if (Type == GameType.MarthJuggle) MarthJuggleGameUpdate();
            else if (Type == GameType.MarthNormal) MarthNormalGameUpdate();
            else if (Type == GameType.MarioPortal) MarioPortalGameUpdate();

            if (pauseTimer > 0)
            {
                pauseTimer--;
                foreach (IGameObject obj in unpausedObjects)
                    obj.Update();
            }
            else
            {
                IList<IController> controllers = GameInstance.controllers;
                foreach (IController c in controllers)
                {
                    c.Update();
                }

                Level.Update();
                CollisionHandler.CollisionCheck();
                GameInstance.Scorekeeper.Update();
            }
        }

        private static void MarioNormalGameUpdate()
        {
            if (Level.GetPlayer(0).IsDead())
            {
                GameInstance.State = new Dying(120);
            }
        }

        private static void MarthNormalGameUpdate()
        {
            if (Level.GetPlayer(0).IsDead())
            {
                GameInstance.State = new Dying(120);
            }
        }

        private static void MarthJuggleGameUpdate()
        {
            if (CollisionHandler.IsEnemyOnGround())
            {
                GameInstance.Scorekeeper.HitPoints = 1;
                GameInstance.GameLevel.GetPlayer(0).Damage();
                GameInstance.State = new Dying(120);
            }
            GameInstance.Scorekeeper.Time = 300;
        }

        private static void MarioPortalGameUpdate()
        {
            if (Level.GetPlayer(0).IsDead())
            {
                GameInstance.State = new Dying(120);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Camera.Update(new Vector2(Level.GetPlayer(0).Physics.XPosition, Level.GetPlayer(0).Physics.YPosition));
            GameInstance.GraphicsDevice.SetRenderTarget(gameRenderTarget);
            spriteBatch.Begin(SpriteSortMode.FrontToBack);
            DrawSprites(spriteBatch);
            spriteBatch.End();

            GameInstance.GraphicsDevice.SetRenderTarget(null);
            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, RasterizerState.CullNone, null, transformMatrix: null);
            spriteBatch.Draw(gameRenderTarget, 
                new Rectangle(0, 0, GameInstance.Graphics.PreferredBackBufferWidth, GameInstance.Graphics.PreferredBackBufferHeight), 
                new Rectangle(Camera.XPosition, Camera.YPosition, WINDOW_WIDTH_BASE, WINDOW_HEIGHT_BASE), 
                Color.White);
            GameInstance.HeadsUpDisplay.Draw(spriteBatch);
            spriteBatch.End();
        }

        private static void DrawSprites(SpriteBatch spriteBatch)
        {
            GameInstance.BackgroundSprite.Draw(0, 0, spriteBatch, Color.White);
            Level.Draw(spriteBatch);
        }

        public void PauseAllButOne(IGameObject exceptionalObj, int pauseTime)
        {
            unpausedObjects = new List<IGameObject> { exceptionalObj };
            pauseTimer = pauseTime;
        }
    }
}
