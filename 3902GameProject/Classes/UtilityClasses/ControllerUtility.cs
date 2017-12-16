using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3902GameProject.Classes
{
    public static class ControllerUtility
    {
        public static IController InitializeKeyboardMario()
        {
            KeyboardController keyboard = new KeyboardController();
            keyboard.AddWhilePressedCommand(Keys.Left, new MovePlayerLeftCommand(0));
            keyboard.AddWhilePressedCommand(Keys.Right, new MovePlayerRightCommand(0));
            keyboard.AddOnPressCommand(Keys.Z, new MakePlayerJumpCommand(0));
            keyboard.AddWhilePressedCommand(Keys.Z, new MakePlayerContinueJumpCommand(0));
            keyboard.AddWhilePressedCommand(Keys.Down, new MakePlayerCrouchCommand(0));
            keyboard.AddOnReleaseCommand(Keys.Down, new MakePlayerStandCommand(0));
            keyboard.AddOnPressCommand(Keys.X, new MakeMarioRunCommand(0));
            keyboard.AddOnReleaseCommand(Keys.X, new MakeMarioStopRunCommand(0));
            keyboard.AddOnPressCommand(Keys.X, new MakeMarioShootFireCommand(0));
            keyboard.AddOnPressCommand(Keys.C, new MakeMarioShootOPortalCommand(0));
            keyboard.AddOnPressCommand(Keys.V, new MakeMarioShootBPortalCommand(0));
            return (IController)keyboard;
        }

        public static IController InitializeGamePadMario()
        {
            GamepadController gamePad = new GamepadController();
            gamePad.AddWhilePressedCommand(Buttons.DPadLeft, new MovePlayerLeftCommand(0));
            gamePad.AddWhilePressedCommand(Buttons.DPadRight, new MovePlayerRightCommand(0));
            gamePad.AddOnPressCommand(Buttons.A, new MakePlayerJumpCommand(0));
            gamePad.AddWhilePressedCommand(Buttons.A, new MakePlayerContinueJumpCommand(0));
            gamePad.AddWhilePressedCommand(Buttons.DPadDown, new MakePlayerCrouchCommand(0));
            gamePad.AddOnReleaseCommand(Buttons.DPadDown, new MakePlayerStandCommand(0));
            gamePad.AddOnPressCommand(Buttons.B, new MakeMarioRunCommand(0));
            gamePad.AddOnReleaseCommand(Buttons.B, new MakeMarioStopRunCommand(0));
            gamePad.AddOnPressCommand(Buttons.B, new MakeMarioShootFireCommand(0));
            return (IController)gamePad;
        }

        public static IController InitializeKeyboardMenu()
        {
            KeyboardController keyboard = new KeyboardController();
            keyboard.AddOnReleaseCommand(Keys.Enter, new EnterMarioGameCommand());
            keyboard.AddOnReleaseCommand(Keys.Tab, new EnterMarioPortalGameCommand());
            keyboard.AddOnReleaseCommand(Keys.Z, new EnterMarthNormalGameCommand());
            keyboard.AddOnReleaseCommand(Keys.LeftShift, new EnterMarthJuggleGameCommand());
            keyboard.AddOnReleaseCommand(Keys.RightShift, new EnterMarthJuggleGameCommand());
            keyboard.AddOnPressCommand(Keys.Left, new LowerScaleCommand());
            keyboard.AddOnPressCommand(Keys.Right, new RaiseScaleCommand());
            keyboard.AddOnReleaseCommand(Keys.C, new EnterControlsScrenCommand());
            return (IController)keyboard;
        }

        public static IController InitializeGamePadMenu()
        {
            GamepadController gamePad = new GamepadController();
            gamePad.AddOnPressCommand(Buttons.Start, new EnterMarioGameCommand());
            return gamePad;
        }

        public static IController InitializeKeyboardMarth()
        {
            KeyboardController keyboard = new KeyboardController();
            keyboard.AddWhilePressedCommand(Keys.Left, new MovePlayerLeftCommand(0));
            keyboard.AddWhilePressedCommand(Keys.Right, new MovePlayerRightCommand(0));
            keyboard.AddOnPressCommand(Keys.Z, new MakePlayerJumpCommand(0));
            keyboard.AddWhilePressedCommand(Keys.Z, new MakePlayerContinueJumpCommand(0));
            keyboard.AddOnReleaseCommand(Keys.Z, new MakePlayerEndJumpCommand(0));
            keyboard.AddWhilePressedCommand(Keys.Down, new MakePlayerCrouchCommand(0));
            keyboard.AddOnReleaseCommand(Keys.Down, new MakePlayerStandCommand(0));
            keyboard.AddOnPressCommand(Keys.X, new MakeMarthSwingCommand(0));
            return (IController)keyboard;
        }
    }
}
