using _3902GameProject.Classes.Portals;
using _3902GameProject.Classes.UtilityClasses;
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
    static class PortalCollision
    {
        public static void HandleCollisionForPortals(GenericPortal portalBall, IList<IGameObject> collisions)
        {
            List<IGameObject> temp = new List<IGameObject>();
            temp.AddRange(Game1.GameInstance.GameLevel.StaticObjects);
            foreach (IGameObject obj in temp)
            {
                if (obj is OrangePortal && portalBall is OrangeBall)
                {
                    Game1.GameInstance.GameLevel.StaticObjects.Remove(obj);
                }
                else if (obj is BluePortal && portalBall is BlueBall)
                {
                    Game1.GameInstance.GameLevel.StaticObjects.Remove(obj);
                }
            }
            foreach (IGameObject obj in collisions)
            {
                if (obj is IBlock)
                {
                    if (portalBall.Orange)
                    {
                        IPortal portal = null;
                        if (portalBall.Vel > 0)
                        {
                            portal = PortalSpriteFactory.Instance.CreateOrangePortal(obj.BoundingRectangle().X - SpriteUtilityConsts.SmallGap, obj.BoundingRectangle().Y + SpriteUtilityConsts.SmallSprite);
                            portal.Left = true;
                        }
                        else
                        {
                            portal = PortalSpriteFactory.Instance.CreateOrangePortal(obj.BoundingRectangle().X + obj.BoundingRectangle().Width, obj.BoundingRectangle().Y + SpriteUtilityConsts.SmallSprite);
                        }
                        Game1.GameInstance.GameLevel.StaticObjects.Add(portal);
                    }
                    else
                    {
                        IPortal portal = null;
                        if (portalBall.Vel > 0)
                        {
                            portal = PortalSpriteFactory.Instance.CreateBluePortal(obj.BoundingRectangle().X - SpriteUtilityConsts.SmallGap, obj.BoundingRectangle().Y + SpriteUtilityConsts.SmallSprite);
                            portal.Left = true;
                        }
                        else
                        {
                            portal = PortalSpriteFactory.Instance.CreateBluePortal(obj.BoundingRectangle().X + obj.BoundingRectangle().Width, obj.BoundingRectangle().Y + SpriteUtilityConsts.SmallSprite);
                        }
                        Game1.GameInstance.GameLevel.StaticObjects.Add(portal);
                    }
                    Game1.GameInstance.GameLevel.MovingObjects.Remove(portalBall);
                }
                else if (obj is IPipe)
                {

                    if (portalBall.Orange)
                    {
                        IPortal portal = null;
                        if (portalBall.Vel > 0)
                        {
                            portal = PortalSpriteFactory.Instance.CreateOrangePortal(obj.BoundingRectangle().X - SpriteUtilityConsts.SmallGap, obj.BoundingRectangle().Y + SpriteUtilityConsts.SmallSprite);
                            portal.Left = true;
                        }
                        else
                        {
                            portal = PortalSpriteFactory.Instance.CreateOrangePortal(obj.BoundingRectangle().X + SpriteUtilityConsts.SmallSprite, obj.BoundingRectangle().Y + SpriteUtilityConsts.SmallSprite);
                        }
                        Game1.GameInstance.GameLevel.StaticObjects.Add(portal);
                    }
                    else
                    {
                        IPortal portal = null;
                        if (portalBall.Vel > 0)
                        {
                            portal = PortalSpriteFactory.Instance.CreateBluePortal(obj.BoundingRectangle().X - SpriteUtilityConsts.SmallGap, obj.BoundingRectangle().Y + SpriteUtilityConsts.SmallSprite);
                            portal.Left = true;
                        }
                        else
                        {
                            portal = PortalSpriteFactory.Instance.CreateBluePortal(obj.BoundingRectangle().X + obj.BoundingRectangle().Width, obj.BoundingRectangle().Y + SpriteUtilityConsts.SmallSprite);
                        }
                        Game1.GameInstance.GameLevel.StaticObjects.Add(portal);
                    }
                    Game1.GameInstance.GameLevel.MovingObjects.Remove(portalBall);
                }
            }
        }
    }
}
