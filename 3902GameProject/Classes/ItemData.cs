using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3902GameProject.Classes
{
    public class ItemData
    {
        public float XVelocity { get; set; }
        public float YVelocity { get; set; }
        public float XPosition { get; set; }
        public float YPosition { get; set; }

        public int FramesToRise { get; private set; }
        public int FramesToFall { get; private set; }
        public float RisePerFrame { get; private set; }

        public bool Deployed { get; private set; }

        public ItemData(float risePerFrame, int framesToFall, int framesToRise)
        {
            FramesToFall = framesToFall;
            FramesToRise = framesToRise;
            RisePerFrame = risePerFrame;
            Deployed = false;
        }

        public void DeployItem()
        {
            if (FramesToRise > 0)
            {
                YPosition -= RisePerFrame;
                FramesToRise--;
            }
            else if (FramesToFall > 0)
            {
                YPosition += RisePerFrame;
                FramesToFall--;
            }
            else
            {
                Deployed = true;
            }
        }
    }
}
