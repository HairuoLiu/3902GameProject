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
using static _3902GameProject.Game1;

namespace _3902GameProject.Classes.Collision
{
    public static class EnemyCollision
    {
        public static void HandleCollisionsForEnemy(IEnemy enemy, IList<IGameObject> collisions)
        {
            Rectangle enemyBox = enemy.BoundingRectangle();
            IList<Rectangle> solidsToCheckForCombining = new List<Rectangle>();
            foreach (IGameObject obj in collisions)
            {
                CollisionDirection dir = CollisionDir(enemyBox, obj.BoundingRectangle());
                Rectangle objRectangle = obj.BoundingRectangle();
                if (obj is IEnemy otherEnemy)
                {
                    if (otherEnemy.IsDead) continue; 

                    if (!enemy.Equals(otherEnemy))
                    {
                        EnemyHitsEnemy(enemy, dir, otherEnemy);
                    }
                }
                else if (obj is IItem)
                {
                }
                else if (obj is IBlock block)
                {
                    if (block.IsBouncing)
                    {
                        EnemyHitsBouncingBlock(enemy, dir, objRectangle);
                    }
                    solidsToCheckForCombining.Add(objRectangle);
                }
                else if (obj is ISword)
                {

                }
                else if (obj is IPortal)
                {
                    EnemyHitsPortal(enemy, (GenericPortal)obj, GameInstance.GameLevel.StaticObjects);
                }
                else
                {
                    solidsToCheckForCombining.Add(objRectangle);
                }
            }

            CombineRectangles(solidsToCheckForCombining);
            foreach (Rectangle box in solidsToCheckForCombining)
                EnemyHitsSolid(enemy, CollisionDir(enemyBox, box), box);
        }

        private static void EnemyHitsSolid(IEnemy enemy, CollisionDirection dir, Rectangle box)
        {
            if (dir == CollisionDirection.Top)
            {
                enemy.YPosition = box.Y;
            }
            else if (dir == CollisionDirection.Right)
            {
                enemy.XPosition = box.Right;
                enemy.XVelocity = Math.Abs(enemy.XVelocity);
                enemy.YVelocity = UtilityClasses.CollisionUtilityConsts.VelocityInitEnemies;
            }
            else if (dir == CollisionDirection.Left)
            {
                enemy.XPosition = box.Left - enemy.BoundingRectangle().Width - (enemy.BoundingRectangle().X - enemy.XPosition);
                enemy.XVelocity = -Math.Abs(enemy.XVelocity);
                enemy.YVelocity = UtilityClasses.CollisionUtilityConsts.VelocityInitEnemies;
            }
        }

        private static void EnemyHitsBouncingBlock(IEnemy enemy, CollisionDirection dir, Rectangle blockBox)
        {
            IScore scorekeeper = GameInstance.Scorekeeper;
            enemy.MakeFlipped(enemy.BoundingRectangle().X < blockBox.X);
            EnemyHitsSolid(enemy, dir, blockBox);
            scorekeeper.KillEnemy(enemy, false);
        }

        private static void EnemyHitsEnemy(IEnemy enemy, CollisionDirection dir, IEnemy enemy2)
        {
            if (enemy.Stomped)
            {
                enemy2.MakeFlipped(enemy.BoundingRectangle().X < enemy.BoundingRectangle().X);
                GameInstance.Scorekeeper.KillEnemy(enemy2, false);
            }
            else
            {
                if (dir == CollisionDirection.Top)
                {
                    enemy.YPosition = enemy2.BoundingRectangle().Y;
                }
                else if (dir == CollisionDirection.Right || dir == CollisionDirection.Left)
                {
                    enemy.XVelocity = -enemy.XVelocity;
                    enemy2.XVelocity = -enemy2.XVelocity;
                    EnemyHitsSolid(enemy, dir, enemy2.BoundingRectangle());
                    CollisionDirection d = (dir == CollisionDirection.Right ? CollisionDirection.Left : CollisionDirection.Right);
                    EnemyHitsSolid(enemy2, d, enemy.BoundingRectangle());
                }
            }
        }

        public static void EnemyHitsMario(IEnemy enemy, CollisionDirection dir, bool isStar, bool isToLeftOfMario, bool marioMovingDown)
        {
            IScore scorekeeper = GameInstance.Scorekeeper;
            if (isStar)
            {
                enemy.MakeFlipped(isToLeftOfMario);
                scorekeeper.KillEnemy(enemy, false);
            }
            else if (dir == CollisionDirection.Top && marioMovingDown)
            {
                enemy.MakeStomped();
                if (GameInstance.Type != GameType.MarthJuggle) scorekeeper.KillEnemy(enemy, true);
                if (enemy is Turtle turtle)
                {
                    turtle.XVelocity = isToLeftOfMario ? -UtilityClasses.CollisionUtilityConsts.VelocityInitEnemies : UtilityClasses.CollisionUtilityConsts.VelocityInitEnemies;
                }
            }
        }

        public static void EnemyHitsMarth(IEnemy enemy, CollisionDirection dir, bool isToLeftOfMarth, bool marthMovingDown)
        {
            IScore scorekeeper = Game1.GameInstance.Scorekeeper;
            if (dir == CollisionDirection.Top && marthMovingDown)
            {
                enemy.MakeStomped();
                scorekeeper.KillEnemy(enemy, true);
                if (enemy is Turtle turtle)
                {
                    turtle.XVelocity = isToLeftOfMarth ? -UtilityClasses.CollisionUtilityConsts.VelocityInitEnemies : UtilityClasses.CollisionUtilityConsts.VelocityInitEnemies;
                }
            }
        }
        public static void EnemyHitsPortal(IEnemy enemy, GenericPortal portal, IList<IGameObject> objs)
        {
            if (portal.PortalO)
            {
                foreach (IGameObject obj in objs)
                {
                    if (obj is IPortal)
                    {
                        GenericPortal bportal = (GenericPortal)obj;
                        if (!bportal.PortalO)
                        {
                            enemy.XPosition = bportal.PosX + SpriteUtilityConsts.SmallGap;
                            enemy.YPosition = bportal.PosY;
                        }
                    }
                }
            }
            else if (!portal.Ball && !portal.Gun)
            {
                foreach (IGameObject obj in objs)
                {
                    if (obj is IPortal)
                    {
                        GenericPortal oportal = (GenericPortal)obj;
                        if (oportal.PortalO)
                        {
                            enemy.XPosition = oportal.PosX + SpriteUtilityConsts.SmallGap;
                            enemy.YPosition = oportal.PosY;
                        }
                    }
                }
            }
        }

        public static bool IsEnemyOnGround(IGameObject enemy)
        {
            Rectangle enemyBox = enemy.BoundingRectangle();
            enemyBox.Inflate(0, 1);
            foreach (IGameObject obj in Game1.GameInstance.GameLevel.StaticObjects)
            {
                Rectangle objBox = obj.BoundingRectangle();
                if (obj is GroundBlock && objBox.Intersects(enemyBox)) return true;
            }
            return false;
        }
    }
}
