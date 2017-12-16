using _3902GameProject.Classes.SystemSprites;
using _3902GameProject.Classes.UtilityClasses;
using _3902GameProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3902GameProject.Classes
{
    public class MainMenu : IGameState
    {
        private static RenderTarget2D gameRenderTarget;
        private int menuWidthBase = 1024;
        private int menuHeightBase = 872;
        private IGameObject rectangle;
        private ISprite background;
        Song song = Game1.GameInstance.Content.Load<Song>(StringConsts.MenuMusic);

        public MainMenu()
        {
            Game1.GameInstance.Type = Game1.GameType.None;
            rectangle = BackgroundFactory.Instance.CreateWhiteRectangle();
            background = BackgroundFactory.Instance.CreateMenuBackground();
            gameRenderTarget = new RenderTarget2D(Game1.GameInstance.GraphicsDevice, menuWidthBase, menuHeightBase);
            Game1.GameInstance.InitializeMenuControllers();
            Game1.GameInstance.Scorekeeper = new Score();
            MediaPlayer.Play(song);
        }

        public void Update()
        {
            background.Update();
            IList<IController> controllers = Game1.GameInstance.controllers;
            foreach (IController c in controllers)
            {
                c.Update();
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Game1.GameInstance.GraphicsDevice.SetRenderTarget(gameRenderTarget);
            spriteBatch.Begin(SpriteSortMode.FrontToBack);
            DrawSprites(spriteBatch);
            spriteBatch.End();

            Game1.GameInstance.GraphicsDevice.SetRenderTarget(null);
            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, RasterizerState.CullNone, null, transformMatrix: null);
            spriteBatch.Draw(gameRenderTarget,
                new Rectangle(0, 0, Game1.GameInstance.Graphics.PreferredBackBufferWidth, Game1.GameInstance.Graphics.PreferredBackBufferHeight),
                new Rectangle(0, 0, menuWidthBase, menuHeightBase),
                Color.White);
            rectangle.Draw(spriteBatch);
            spriteBatch.End();
        }

        private void DrawSprites(SpriteBatch spriteBatch)
        {
            background.Draw(0, 872, spriteBatch, Color.White);
        }
    }
}
