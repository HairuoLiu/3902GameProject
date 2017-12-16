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
using _3902GameProject.Classes.Portals;

namespace _3902GameProject.Classes.Collision
{
    public static class MarioCollision
    {
        public static void HandleCollisionsForMario(IMario mario, IList<IGameObject> collisions)
        {
            ILevel level = Game1.GameInstance.GameLevel;
            Rectangle marioBox = mario.BoundingRectangle();
           
            IList<Rectangle> solidsToCheckForCombining = new List<Rectangle>();
            foreach (IGameObject obj in collisions)
            {
                Rectangle rec = obj.BoundingRectangle();
                CollisionDirection dir = CollisionDir(marioBox, mario.Physics.YVelocity, rec);
                if (obj is IItem item)
                {
                    MarioHitsItem(mario, item);
                    level.RemoveObject(item, false);
                }
                else if (obj is IPipe pipe)
                {
                    if (pipe.GetType().Equals(typeof(HorPipe)) && Keyboard.GetState().IsKeyDown(Keys.Right) && dir == CollisionDirection.Left && mario.Physics.YVelocity == 0)
                    {
                        Game1.GameInstance.State = new EnteringPipeToRight(MiscUtilityClass.PipeTransitionTime);
                    }
                    if(mario.CanCollide)
                    {
                        solidsToCheckForCombining.Add(rec);
                    }
                    

                }
                else if (obj is IEnemy enemy)
                {
                    if (!enemy.IsDead)
                    {
                        EnemyCollision.EnemyHitsMario(enemy, dir, mario is StarMario, rec.X < marioBox.X, mario.Physics.YVelocity > 0);
                        MarioHitsEnemy(mario, dir, enemy);
                    }
                }
                else if (obj is IBlock block)
                {
                    bool wasVisible = block.IsVisible;
                    block.CollisionWithPlayer(dir, mario);
                    if (wasVisible)
                    {
                        solidsToCheckForCombining.Add(rec);
                    }
                }
                else if (obj is IScenery)
                {
                    if (Game1.GameInstance.State is Playing && obj is FlagPoleSprite)
                    {
                        mario.MakeFlag();
                        Game1.GameInstance.Scorekeeper.GetFlag((float) Math.Abs(marioBox.Bottom - obj.BoundingRectangle().Bottom) / obj.BoundingRectangle().Height);
                        Game1.GameInstance.State = new FlagSliding();
                    }
                }
                else if (obj is IPortal)
                {
                    PortalCollision(Game1.GameInstance.GameLevel.StaticObjects, (GenericPortal)obj);
                }
                else
                {
                    throw new NotImplementedException();
                }
            }

            CombineRectangles(solidsToCheckForCombining);
            foreach (Rectangle box in solidsToCheckForCombining)
                MarioHitsSolid(mario, CollisionDir(marioBox, mario.Physics.YVelocity, box), box);
        }

        public static void MarioHitsItem(IMario mario, IItem item)
        {
            if (item is BigMushroom)
            {
                mario.MakeBig();
                SoundControl.PlaySoundEffect(Sound.powerupEffect);
            }
            else if (item is FireFlower)
            {
                SoundControl.PlaySoundEffect(Sound.powerupEffect);
                mario.MakeFire();   
            }
            else if (item is SuperStar)
            {
                SoundControl.PlaySoundEffect(Sound.powerupAppearsEffect);
                Game1.GameInstance.GameLevel.SetPlayer(new StarMario(mario), mario); 
            }
            else if (item is StaticCoin)
            {
                SoundControl.PlaySoundEffect(Sound.coinEffect);
            }
            else if (item is LifeMushroom)
            {
                SoundControl.PlaySoundEffect(Sound.powerupEffect);
            }
            Game1.GameInstance.Scorekeeper.CollectItem(item);

        }

        public static void PortalCollision(IList<IGameObject> objs, GenericPortal portal)
        {
            if (portal.PortalO)
            {
                foreach (IGameObject obj in objs)
                {
                    if (obj is IPortal o && !o.Gun && !o.Ball)
                    {
                        GenericPortal bportal = (GenericPortal)obj;
                        if (!bportal.PortalO)
                        {
                            if (bportal.Left)
                            {
                                Game1.GameInstance.GameLevel.GetPlayer(0).Physics.XPosition = bportal.PosX - SpriteUtilityConsts.SmallSprite;
                                Game1.GameInstance.GameLevel.GetPlayer(0).Physics.YPosition = bportal.PosY;
                            }
                            else
                            {
                                Game1.GameInstance.GameLevel.GetPlayer(0).Physics.XPosition = bportal.PosX + SpriteUtilityConsts.SmallGap;
                                Game1.GameInstance.GameLevel.GetPlayer(0).Physics.YPosition = bportal.PosY;
                            }
                        }
                    }
                }
            }
            else if (!portal.Gun && !portal.Ball)
            {
                foreach(IGameObject obj in objs)
                {
                    if(obj is IPortal o && !o.Gun && !o.Ball)
                    {
                        GenericPortal bportal = (GenericPortal)obj;
                        if (bportal.PortalO)
                        {
                            if (bportal.Left)
                            {
                                Game1.GameInstance.GameLevel.GetPlayer(0).Physics.XPosition = bportal.PosX - SpriteUtilityConsts.SmallSprite;
                                Game1.GameInstance.GameLevel.GetPlayer(0).Physics.YPosition = bportal.PosY;
                            }
                            else
                            {
                                Game1.GameInstance.GameLevel.GetPlayer(0).Physics.XPosition = bportal.PosX + SpriteUtilityConsts.SmallGap;
                                Game1.GameInstance.GameLevel.GetPlayer(0).Physics.YPosition = bportal.PosY;
                            }
                        }
                    }
                }
            }
            else
            {
                portal.PUp = true;
                Mario m = (Mario)Game1.GameInstance.GameLevel.GetPlayer(0);
                m.PortalMode = true;
            }
        }
        public static void MarioHitsSolid(IMario mario, CollisionDirection dir, Rectangle blockBox)
        {
            
            SolveCollision(mario, dir, blockBox);
        }

        public static void MarioHitsEnemy(IMario mario, CollisionDirection dir, IEnemy enemy)
        {
            if (!(dir == CollisionDirection.Top) && enemy.XVelocity != 0)
            {
                mario.Damage();
            }
            else if (dir == CollisionDirection.Top && !CollisionDetector.CheckBoxForStanding(mario.BoundingRectangle()))
            {
                if (!(mario is StarMario)) mario.Physics.YVelocity = -UtilityClasses.CollisionUtilityConsts.MaxVel;
                SoundControl.PlaySoundEffect(Sound.kickEffect);
            }
        }

        private static void SolveCollision(IMario mario, CollisionDirection dir, Rectangle collidableBox)
        {
            int yOffset = mario.BoundingRectangle().Bottom - (int)mario.Physics.YPosition;
            int xOffset = mario.BoundingRectangle().Left - (int)mario.Physics.XPosition;
            if (dir == CollisionDirection.Bottom)
            {
                mario.Physics.YPosition = collidableBox.Bottom + mario.BoundingRectangle().Height - yOffset;
                mario.Physics.YVelocity = Math.Max(mario.Physics.YVelocity, 0f);
                mario.BumpHead();
            }
            else if (dir == CollisionDirection.Top)
            {
                mario.Physics.YPosition = collidableBox.Top - yOffset;
                mario.Physics.YVelocity = Math.Min(mario.Physics.YVelocity, 0f);
            }
            else if (dir == CollisionDirection.Left)
            {
                mario.Physics.XPosition = collidableBox.Left - mario.BoundingRectangle().Width - xOffset;
                mario.Physics.XVelocity = 0;
            }
            else if (dir == CollisionDirection.Right)
            {
                mario.Physics.XPosition = collidableBox.Right - xOffset;
                mario.Physics.XVelocity = 0;
            }
        }
    }
}
