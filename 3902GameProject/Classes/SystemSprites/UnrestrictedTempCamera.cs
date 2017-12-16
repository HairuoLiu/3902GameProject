using _3902GameProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _3902GameProject.Classes.UtilityClasses;

namespace _3902GameProject.Classes.SystemSprites
{
    public class UnrestrictedTempCamera : ICamera
    {
        public int XPosition { get; set; }
        public int YPosition { get; set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public bool Fix { get; set; }

        public UnrestrictedTempCamera()
        {
            XPosition = 0;
            Width = Game1.WINDOW_WIDTH_BASE;
            Height = Game1.WINDOW_HEIGHT_BASE;
            Fix = false;
        }

        public void Update(Vector2 target)
        {
            if (Fix) return;
            int newCameraXPosition = (int)target.X - SystemUtilityConsts.CameraXOffset;
            XPosition = newCameraXPosition;
            if (XPosition > SystemUtilityConsts.CameraMaxX) XPosition = SystemUtilityConsts.CameraMaxX;
        }
    }

}