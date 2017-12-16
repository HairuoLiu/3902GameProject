using _3902GameProject.Classes.SystemSprites;
using _3902GameProject.Classes.SceneSprites.Misc_Sprites;
using _3902GameProject.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using static _3902GameProject.Classes.CollisionGeneral;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using _3902GameProject.Classes.UtilityClasses;

namespace _3902GameProject.Classes.Collision
{
    public static class MarthCollision
    {
        public static void HandleCollisionsForMarth(IMarth marth, IList<IGameObject> collisions)
        {
            ILevel level = Game1.GameInstance.GameLevel;
            Rectangle marthBox = marth.BoundingRectangle();
           
            IList<Rectangle> solidsToCheckForCombining = new List<Rectangle>();
            foreach (IGameObject obj in collisions)
            {
                Rectangle rec = obj.BoundingRectangle();
                CollisionDirection dir = CollisionDir(marthBox, marth.Physics.YVelocity, rec);
                if (obj is IItem item)
                {
                    MarthHitsItem(item);
                    level.RemoveObject(item, false);
                }
                else if (obj is IPipe pipe)
                {
                    if (pipe.GetType().Equals(typeof(HorPipe)) && Keyboard.GetState().IsKeyDown(Keys.Right) && dir == CollisionDirection.Left && marth.Physics.YVelocity == 0)
                    {
                        Game1.GameInstance.State = new EnteringPipeToRight(MiscUtilityClass.PipeTransitionTime);
                    }
                    solidsToCheckForCombining.Add(rec);
                }
                else if (obj is IEnemy enemy)
                {
                    if (!enemy.IsDead)
                    {
                        EnemyCollision.EnemyHitsMarth(enemy, dir, rec.X < marthBox.X, marth.Physics.YVelocity > 0);
                        MarthHitsEnemy(marth, dir, enemy);
                    }
                }
                else if (obj is IBlock block)
                {
                    bool wasVisible = block.IsVisible;
                    block.CollisionWithPlayer(dir, marth);
                    if (wasVisible)
                    {
                        solidsToCheckForCombining.Add(rec);
                    }
                }
                else if (obj is IScenery)
                {
                    if (Game1.GameInstance.State is Playing && obj is FinishLineSprite)
                    {
                        Game1.GameInstance.State = new MarthCastleWalking();
                    }
                }
                else
                {
                    throw new NotImplementedException();
                }
            }

            CombineRectangles(solidsToCheckForCombining);
            foreach (Rectangle box in solidsToCheckForCombining)
                MarthHitsSolid(marth, CollisionDir(marthBox, marth.Physics.YVelocity, box), box);
        }

        public static void MarthHitsItem(IItem item)
        {
            if (item is BigMushroom)
            {
                Game1.GameInstance.Scorekeeper.HitPoints++;
            }
            Game1.GameInstance.Scorekeeper.CollectItem(item);
        }

        public static void MarthHitsSolid(IMarth marth, CollisionDirection dir, Rectangle blockBox)
        {
            SolveCollision(marth, dir, blockBox);
        }

        public static void MarthHitsEnemy(IPlayer marth, CollisionDirection dir, IEnemy enemy)
        {
            if (!(dir == CollisionDirection.Top) && enemy.XVelocity != 0)
            {
                marth.Damage();
            }
            else if (dir == CollisionDirection.Top && !CollisionDetector.CheckBoxForStanding(marth.BoundingRectangle()))
            {
                marth.Physics.YVelocity = -UtilityClasses.CollisionUtilityConsts.MaxVel;
                SoundControl.PlaySoundEffect(Sound.kickEffect);
            }
        }

        private static void SolveCollision(IMarth marth, CollisionDirection dir, Rectangle collidableBox)
        {
            int yOffset = marth.BoundingRectangle().Bottom - (int)marth.Physics.YPosition;
            int xOffset = marth.BoundingRectangle().Left - (int)marth.Physics.XPosition;
            if (dir == CollisionDirection.Bottom)
            {
                marth.Physics.YPosition = collidableBox.Bottom + marth.BoundingRectangle().Height - yOffset;
                marth.Physics.YVelocity = Math.Max(marth.Physics.YVelocity, 0f);
                marth.BumpHead();
            }
            else if (dir == CollisionDirection.Top)
            {
                marth.Physics.YPosition = collidableBox.Top - yOffset;
                marth.Physics.YVelocity = Math.Min(marth.Physics.YVelocity, 0f);
            }
            else if (dir == CollisionDirection.Left)
            {
                marth.Physics.XPosition = collidableBox.Left - marth.BoundingRectangle().Width - xOffset;
                marth.Physics.XVelocity = 0;
            }
            else if (dir == CollisionDirection.Right)
            {
                marth.Physics.XPosition = collidableBox.Right - xOffset;
                marth.Physics.XVelocity = 0;
            }
        }
    }
}
