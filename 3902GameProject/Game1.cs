using _3902GameProject.Classes;
using _3902GameProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using _3902GameProject.Classes.SystemSprites;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using System.Threading;
using _3902GameProject.Classes.UtilityClasses;
using _3902GameProject.Classes.Portals;

namespace _3902GameProject
{
    public class Game1 : Game
    {
        private static Game1 gameInstance;
        public static Game1 GameInstance { get { return gameInstance; } }

        public enum GameType
        {
            None,
            MarioNormal,
            MarthNormal,
            MarthJuggle,
            MarioPortal
        };
        public GameType Type { get; set; }

        private GraphicsDeviceManager graphics;
        public GraphicsDeviceManager Graphics
        {
            get { return graphics; }
            set { graphics = value; }
        }
        public static SpriteBatch spriteBatch;

        private ISprite backgroundSprite;
        public ISprite BackgroundSprite
        {
            get { return backgroundSprite; }
            set { backgroundSprite = value; }
        }
        public ICamera TempCamera { get; set; }

        private IController systemController;
        internal IList<IController> controllers;
        public ILevel GameLevel { get; set; }
        public string LevelFile { get; set; }
        public bool UserPause { get; set; }
        public IGameState State { get; set; }
        public IScore Scorekeeper { get; set; }
        public IHeadsUp HeadsUpDisplay { get; set; }

        public static float Scale { get; set; }
        public const int GAME_WIDTH = 3376;
        public const int GAME_HEIGHT = 1000;
        public const int WINDOW_WIDTH_BASE = 256;
        public const int WINDOW_HEIGHT_BASE = 208;

        public Game1()
        {
            gameInstance = this;
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        public void SetWindow()
        {
            graphics.PreferredBackBufferHeight = (int)(Scale * WINDOW_HEIGHT_BASE);
            graphics.PreferredBackBufferWidth = (int)(Scale * WINDOW_WIDTH_BASE);
            graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            Scale = 3f;
            SetWindow();

            LevelFile = StringConsts.Level1File;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            Sound.InitializeSounds(Content);
            MediaPlayer.Volume = 20; // Remove to get sound
            systemController = InitializeSystemKeyboard();

            spriteBatch = new SpriteBatch(GraphicsDevice);
            PlayerSpriteFactory.Instance.LoadTextures(Content);
            BlockSpriteFactory.Instance.LoadTextures(Content);
            ItemSpriteFactory.Instance.LoadTextures(Content);
            SceneSpriteFactory.Instance.LoadTextures(Content);
            EnemySpriteFactory.Instance.LoadTextures(Content);
            FontFactory.Instance.LoadFonts(Content);
            BackgroundFactory.Instance.LoadBackgrounds(Content);
            PortalSpriteFactory.Instance.LoadTextures(Content);
            backgroundSprite = new WorldBackground(Content);

            UserPause = false;
            State = new MainMenu();
            Scorekeeper = new Score();
            HeadsUpDisplay = new MarioHeadsUp();
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            systemController.Update();
            if (UserPause) return;

            State.Update();
        }

        protected override void Draw(GameTime gameTime)
        {
            State.Draw(spriteBatch);
        }

        public void ResetLevel(){
            Thread.Sleep(500);
            State = new MainMenu();
            UserPause = false;
        }

        public void PauseAllButOne(IGameObject obj, int pause)
        {
            if (State is Playing state)
            {
                state.PauseAllButOne(obj, pause);
            }
        }

        public void InitializeMarioControllers()
        {
            controllers = new List<IController>()
            {
                ControllerUtility.InitializeKeyboardMario(),
                ControllerUtility.InitializeGamePadMario()
            };
        }

        public void InitializeMarthControllers()
        {
            controllers = new List<IController>()
            {
                ControllerUtility.InitializeKeyboardMarth()
            };
        }

        public void InitializeMenuControllers()
        {
            controllers = new List<IController>()
            {
                ControllerUtility.InitializeKeyboardMenu(),
                ControllerUtility.InitializeGamePadMenu()
            };
        }

        private IController InitializeSystemKeyboard()
        {
            KeyboardController keyboard = new KeyboardController();
            keyboard.AddOnPressCommand(Keys.Q, new Classes.QuitCommand(this));
            keyboard.AddOnPressCommand(Keys.R, new Classes.ResetCommand(this));
            keyboard.AddOnReleaseCommand(Keys.P, new Classes.PauseResumeCommand(this));
            keyboard.AddOnReleaseCommand(Keys.F1, new Classes.ToggleFullScreenCommand(this));
            return (IController)keyboard;
        }
    }
}
