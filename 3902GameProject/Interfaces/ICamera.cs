using Microsoft.Xna.Framework;

namespace _3902GameProject.Interfaces
{
    public interface ICamera
    {
        int XPosition { get; set; }
        int YPosition { get; set; }
        int Width { get; }
        int Height { get; }
        bool Fix { get; set; }
        
        void Update(Vector2 target);
    }
}
