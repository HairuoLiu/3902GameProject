using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _3902GameProject.Interfaces
{
    public interface IState
    {
        void LoadContent();

        void Draw(SpriteBatch spriteBatch);
    }
}
