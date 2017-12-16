using Microsoft.Xna.Framework.Graphics;

namespace _3902GameProject.Interfaces
{
    public interface IGameState
    {
        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}
