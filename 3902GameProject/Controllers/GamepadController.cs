using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using _3902GameProject;
using _3902GameProject.Controllers;

namespace _3902GameProject
{
    public class GamepadController : IController
    {
        private Dictionary<Buttons, IList<ICommand>> onPressCommandMap;
        private Dictionary<Buttons, IList<ICommand>> whilePressedCommandMap;
        private Dictionary<Buttons, IList<ICommand>> onReleaseCommandMap;
        private GamePadState pressedLastUpdate;

        public GamepadController()
        {
            onPressCommandMap = new Dictionary<Buttons, IList<ICommand>>();
            whilePressedCommandMap = new Dictionary<Buttons, IList<ICommand>>();
            onReleaseCommandMap = new Dictionary<Buttons, IList<ICommand>>();
            pressedLastUpdate = GamePad.GetState(PlayerIndex.One);
        }

        public void Update()
        {
            GamePadState gamePadState = GamePad.GetState(PlayerIndex.One);
            if (gamePadState.IsConnected)
            {
                foreach (Buttons button in whilePressedCommandMap.Keys)
                {
                    if (gamePadState.IsButtonDown(button))
                    {
                        ExecuteCommandList(whilePressedCommandMap[button]);
                    }
                }

                foreach (Buttons button in onPressCommandMap.Keys)
                {
                    if (gamePadState.IsButtonDown(button) && !pressedLastUpdate.IsButtonDown(button))
                    {
                        ExecuteCommandList(onPressCommandMap[button]);
                    }
                }

                foreach (Buttons button in onReleaseCommandMap.Keys)
                {
                    if (!gamePadState.IsButtonDown(button) && pressedLastUpdate.IsButtonDown(button))
                    {
                        ExecuteCommandList(onReleaseCommandMap[button]);
                    }
                }
            }
            pressedLastUpdate = gamePadState;
        }

        public void AddOnPressCommand(Buttons button, ICommand command)
        {
            AddCommandToList(onPressCommandMap, button, command);
        }

        public void AddWhilePressedCommand(Buttons button, ICommand command)
        {
            AddCommandToList(whilePressedCommandMap, button, command);
        }

        public void AddOnReleaseCommand(Buttons button, ICommand command)
        {
            AddCommandToList(onReleaseCommandMap, button, command);
        }

        private static void ExecuteCommandList(IList<ICommand> l)
        {
            foreach (ICommand c in l)
                c.Execute();
        }

        private static void AddCommandToList(Dictionary<Buttons, IList<ICommand>> dict, Buttons button, ICommand command)
        {
            if (dict.ContainsKey(button))
                dict[button].Add(command);
            else
                dict.Add(button, new List<ICommand>() { command });
        }
    }
}
