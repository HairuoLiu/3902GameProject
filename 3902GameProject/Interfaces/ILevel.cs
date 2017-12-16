using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using _3902GameProject.Classes;

namespace _3902GameProject.Interfaces
{
    public interface ILevel : IGameObject
    {
        IList<IGameObject> MovingObjects { get; }
        IList<IGameObject> StaticObjects { get; }
        IList<IPlayer> Players { get; }

        void RemoveObject(IGameObject obj, bool isStatic);
        void AddObject(IGameObject obj, bool isStatic);
        IPlayer GetPlayer(int playerNum);
        void SetPlayer(IPlayer newPlayer);
        void SetPlayer(IPlayer replacementPlayer, int playerNum);
        void SetPlayer(IPlayer replacementPlayer, IPlayer playerToReplace); // May be unneccesarry depending on whether or not marios/players store own player number
    }
}
