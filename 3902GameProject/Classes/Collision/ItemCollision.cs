using _3902GameProject.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static _3902GameProject.Classes.CollisionGeneral;

namespace _3902GameProject.Classes.Collision
{
    public static class ItemCollision
    {
        public static void HandleCollisionsForItem(IItem item, IList<IGameObject> collisions)
        {
            Rectangle itemBox = item.BoundingRectangle();
            IList<Rectangle> collisionBoxes = new List<Rectangle>();
            foreach (IGameObject obj in collisions)
            {
                collisionBoxes.Add(obj.BoundingRectangle());
            }
            CombineRectangles(collisionBoxes);
            foreach (Rectangle objBox in collisionBoxes)
            {
                ItemHitsSolid(item, CollisionDir(itemBox, objBox), objBox);
            }
        }

        private static void ItemHitsSolid(IItem item, CollisionDirection dir, Rectangle rec)
        {
            if (item.GetType().Equals(typeof(SuperStar)))
            {
                SuperStar star = (SuperStar)item;
                star.BounceUp = true;
                star.Arc = UtilityClasses.CollisionUtilityConsts.ArcInit;
            }
            if (dir == CollisionDirection.Top)
            {
                item.ItemInfo.YPosition = rec.Top;
            }
            if (dir == CollisionDirection.Right)
            {
                item.ItemInfo.XPosition = rec.Right;
                item.ItemInfo.XVelocity = -item.ItemInfo.XVelocity;
            }
            else if (dir == CollisionDirection.Left)
            {
                item.ItemInfo.XPosition = rec.Left - item.BoundingRectangle().Width - UtilityClasses.CollisionUtilityConsts.PosReadjusterItems;
                item.ItemInfo.XVelocity = -item.ItemInfo.XVelocity;
            }
        }
    }
}
