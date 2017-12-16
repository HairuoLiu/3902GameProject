using _3902GameProject.Classes.Collision;
using _3902GameProject.Classes.EnemyStates;
using _3902GameProject.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static _3902GameProject.Classes.CollisionGeneral;

namespace _3902GameProject.Classes
{
    public static class CollisionDetector
    {
        public static void PlayerCollisions(Rectangle playerBox, IList<IGameObject> detectedCollisions)
        {
            ILevel level = Game1.GameInstance.GameLevel;
            detectedCollisions.Clear();

            foreach (IGameObject obj in level.MovingObjects)
            {
                if (playerBox.Intersects(obj.BoundingRectangle()) && !obj.PUp)
                    detectedCollisions.Add(obj);
            }
            foreach (IGameObject obj in level.StaticObjects)
            {
                if (playerBox.Intersects(obj.BoundingRectangle()) && !obj.PUp)
                    detectedCollisions.Add(obj);
            }
        }

        public static bool CheckBoxForStanding(Rectangle box)
        {
            ILevel level = Game1.GameInstance.GameLevel;
            Rectangle playerFootBox = new Rectangle(box.Left, box.Bottom, box.Width, 1);

            foreach (IGameObject obj in level.StaticObjects)
            {
                if (obj is IBlock block && !block.IsVisible) continue;
                if (obj is IScenery) continue;
                if (playerFootBox.Intersects(obj.BoundingRectangle()))
                    return true;
            }
            return false;
        }

        public static void EnemyCollisions(Rectangle enemyBox, IList<IGameObject> detectedCollisions)
        {
            ILevel level = Game1.GameInstance.GameLevel;
            detectedCollisions.Clear();

            foreach (IGameObject obj in level.MovingObjects)
            {
                if (enemyBox.Intersects(obj.BoundingRectangle()))
                {
                    detectedCollisions.Add(obj);
                }
            }
            foreach (IGameObject obj in level.StaticObjects)
            {
                if (enemyBox.Intersects(obj.BoundingRectangle()))
                {
                    detectedCollisions.Add(obj);
                }
            }
        }

        public static void SwordCollisions(Rectangle swordBox, IList<IGameObject> detectedCollisions)
        {
            ILevel level = Game1.GameInstance.GameLevel;
            detectedCollisions.Clear();

            foreach (IGameObject obj in level.MovingObjects)
            {
                if (swordBox.Intersects(obj.BoundingRectangle()))
                {
                    detectedCollisions.Add(obj);
                }
            }
        }

        public static void PortalCollisions(Rectangle portalBox, IList<IGameObject> detectedCollisions)
        {
            ILevel level = Game1.GameInstance.GameLevel;
            detectedCollisions.Clear();
            foreach (IGameObject obj in level.StaticObjects)
            {
                if (portalBox.Intersects(obj.BoundingRectangle()))
                {
                    detectedCollisions.Add(obj);
                }

            }
        }

        public static void ItemCollisions(Rectangle itemBox, IList<IGameObject> detectedCollisions)
        {
            ILevel level = Game1.GameInstance.GameLevel;
            detectedCollisions.Clear();

            foreach (IGameObject obj in level.StaticObjects)
            {
                if (!(obj is IPortal) && itemBox.Intersects(obj.BoundingRectangle()))
                {
                    detectedCollisions.Add(obj);
                }

            }
        }
    }
}
