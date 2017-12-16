using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3902GameProject.Interfaces
{
    public interface IEnemyState
    {
        void ChangeMovementToLeft();
        void ChangeMovementToRight();
        void MakeStomped();
        void MakeFlipped();
        void Update();
        void Draw(float x, float y, SpriteBatch spriteBatch);
    }
}
