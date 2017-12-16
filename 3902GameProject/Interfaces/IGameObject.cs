using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace _3902GameProject
{
    public interface IGameObject
    {
        Boolean PUp { get; set; }
        Rectangle BoundingRectangle();
        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}
