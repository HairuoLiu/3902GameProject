using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _3902GameProject.Interfaces;
using _3902GameProject.Classes.SceneSprites.Misc_Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _3902GameProject.Classes
{
    public class Level : ILevel
    {
        public Boolean PUp { get; set; }
        public Boolean PickedUp { get; set; }
        public IList<IGameObject> MovingObjects { get; private set; }
        public IList<IGameObject> StaticObjects { get; private set; }
        public IList<IPlayer> Players { get; private set; }

        public Level()
        {
            Players = new List<IPlayer>();
            MovingObjects = new List<IGameObject>();
            StaticObjects = new List<IGameObject>();
            CSVLevelLoader.LoadFromFile(this, Game1.GameInstance.LevelFile);
        }

        public Rectangle BoundingRectangle()
        {
            return new Rectangle(0, 0, 0, 0);
        }

        public IPlayer GetPlayer(int playerNum)
        {
            return Players[playerNum];
        }

        public void SetPlayer(IPlayer newPlayer)
        {
            Players.Add(newPlayer);
        }

        public void SetPlayer(IPlayer replacementPlayer, int playerNum)
        {
            Players[playerNum] = replacementPlayer;
        }

        public void SetPlayer(IPlayer replacementPlayer, IPlayer playerToReplace)
        {
            if (Players.IndexOf(playerToReplace) >= 0)
            {
                Players[Players.IndexOf(playerToReplace)] = replacementPlayer;
            }
        }

        public void RemoveObject(IGameObject obj, bool isStatic)
        {
            if (isStatic)
            {
                StaticObjects.Remove(obj);
            }
            else
            {
                MovingObjects.Remove(obj);
            }
        }

        public void AddObject(IGameObject obj, bool isStatic)
        {
            if (isStatic)
            {
                StaticObjects.Add(obj);
            }
            else
            {
                MovingObjects.Add(obj);
            }
        }

        public void Update()
        {
            foreach (IGameObject obj in StaticObjects.ToArray())
            {
                obj.Update();
            }
            foreach (IGameObject obj in MovingObjects.ToArray())
            {
                obj.Update();
            }
            foreach (IPlayer mario in Players.ToArray())
            {
                mario.Update();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (IGameObject obj in StaticObjects)
            {
                obj.Draw(spriteBatch);
            }
            foreach (IGameObject obj in MovingObjects)
            {
                obj.Draw(spriteBatch);
            }
            foreach (IPlayer mario in Players)
            {
                mario.Draw(spriteBatch);
            }
        }
    }
}
