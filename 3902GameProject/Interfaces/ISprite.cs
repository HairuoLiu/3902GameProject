using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _3902GameProject.Interfaces
{
    public interface ISprite
    {
        float Depth { get; }
        void Update();
        void Draw(float x, float y, SpriteBatch spriteBatch, Color tint);
    }
}
