using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _3902GameProject
{
    public class KeyboardController : IController
    {
        private Dictionary<Keys, IList<ICommand>> onPressCommandMap;
        private Dictionary<Keys, IList<ICommand>> whilePressedCommandMap;
        private Dictionary<Keys, IList<ICommand>> onReleaseCommandMap;
        private Keys[] pressedLastUpdate;

        public KeyboardController()
        {
            onPressCommandMap = new Dictionary<Keys, IList<ICommand>>();
            whilePressedCommandMap = new Dictionary<Keys, IList<ICommand>>();
            onReleaseCommandMap = new Dictionary<Keys, IList<ICommand>>();
            pressedLastUpdate = new Keys[] {};
        }

        public void Update()
        {
            Keys[] pressed = Keyboard.GetState().GetPressedKeys();

            foreach (Keys key in pressed)
            {
                if (whilePressedCommandMap.ContainsKey(key))
                    ExecuteCommandList(whilePressedCommandMap[key]);

                if (!pressedLastUpdate.Contains(key) && onPressCommandMap.ContainsKey(key))
                    ExecuteCommandList(onPressCommandMap[key]);
            }
            foreach (Keys key in pressedLastUpdate)
            {
                if (!pressed.Contains(key) && onReleaseCommandMap.ContainsKey(key))
                    ExecuteCommandList(onReleaseCommandMap[key]);
            }

            pressedLastUpdate = pressed;
        }
        
        public void AddOnPressCommand(Keys key, ICommand command)
        {
            AddCommandToList(onPressCommandMap, key, command);
        }

        public void AddWhilePressedCommand(Keys key, ICommand command)
        {
            AddCommandToList(whilePressedCommandMap, key, command);
        }

        public void AddOnReleaseCommand(Keys key, ICommand command)
        {
            AddCommandToList(onReleaseCommandMap, key, command);
        }

        private static void ExecuteCommandList(IList<ICommand> l)
        {
            foreach (ICommand c in l)
                c.Execute();
        }

        private static void AddCommandToList(Dictionary<Keys, IList<ICommand>> dict, Keys key, ICommand command)
        {
            if (dict.ContainsKey(key))
                dict[key].Add(command);
            else
                dict.Add(key, new List<ICommand>() { command });
        }
    }
}
