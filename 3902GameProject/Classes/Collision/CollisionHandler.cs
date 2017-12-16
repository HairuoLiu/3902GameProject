using _3902GameProject.Classes.Collision;
using _3902GameProject.Classes.EnemyStates;
using _3902GameProject.Classes.Portals;
using _3902GameProject.Classes.SystemSprites;
using _3902GameProject.Classes.UtilityClasses;
using _3902GameProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static _3902GameProject.Classes.CollisionGeneral;

namespace _3902GameProject.Classes
{
    public static class CollisionHandler
    {
        public static void CollisionCheck()
        {
            ILevel level = Game1.GameInstance.GameLevel;
            IPlayer player = level.GetPlayer(0);
            Rectangle playerBox = player.BoundingRectangle();

            IList<IGameObject> detectedCollisions = new List<IGameObject>();
            CollisionDetector.PlayerCollisions(playerBox, detectedCollisions);

            if (player is IMario mario)
            {
                MarioCollision.HandleCollisionsForMario(mario, detectedCollisions);
                Rectangle marioBox = mario.BoundingRectangle();
                mario.SetGroundedState(CollisionDetector.CheckBoxForStanding(marioBox));
                PipeCheck(marioBox);
                FireballCollision.CollisionCheck(mario);
            }
            else if (player is IMarth marth)
            {
                MarthCollision.HandleCollisionsForMarth(marth, detectedCollisions);
                Rectangle marthBox = marth.BoundingRectangle();
                marth.SetGroundedState(marth.Physics.YVelocity >= 0 && CollisionDetector.CheckBoxForStanding(marthBox));
            }
            List<IGameObject> temp = new List<IGameObject>();
            temp.AddRange(level.MovingObjects);
            foreach (IGameObject obj in temp)
            {
                Rectangle objRectangle = obj.BoundingRectangle();
                if (obj is IEnemy enemy && !enemy.IsDead)
                {
                    CollisionDetector.EnemyCollisions(objRectangle, detectedCollisions);
                    EnemyCollision.HandleCollisionsForEnemy(enemy, detectedCollisions);
                }
                else if (obj is IItem item)
                {
                    CollisionDetector.ItemCollisions(objRectangle, detectedCollisions);
                    ItemCollision.HandleCollisionsForItem(item, detectedCollisions);
                }
                else if (obj is ISword sword)
                {
                    CollisionDetector.SwordCollisions(objRectangle, detectedCollisions);
                    SwordCollision.HandleCollisionsForSword(sword, detectedCollisions);
                }
                else if (obj is GenericPortal ball && ball.Ball)
                {
                    CollisionDetector.PortalCollisions(obj.BoundingRectangle(), detectedCollisions);
                    PortalCollision.HandleCollisionForPortals(ball, detectedCollisions);
                }
            }
        }

        public static bool IsEnemyOnGround()
        {
            foreach (IGameObject obj in Game1.GameInstance.GameLevel.MovingObjects)
            {
                if (obj is IEnemy enemy)
                {
                    if (EnemyCollision.IsEnemyOnGround(enemy)) return true;
                }
            }
            return false;
        }

        private static void PipeCheck(Rectangle playerBox)
        {
            Rectangle beneathPlayer = new Rectangle(playerBox.Left, playerBox.Top + 1, playerBox.Width, playerBox.Height);
            foreach (IGameObject obj in Game1.GameInstance.GameLevel.StaticObjects)
            {
                if (obj is IPipe pipe && pipe.Psg)
                {
                    int delta = UtilityClasses.CollisionUtilityConsts.DeltaInit;
                    Rectangle pipeBox = pipe.BoundingRectangle();
                    pipeBox.Inflate(-delta, 0);
                    if (pipe is LeftPipeTop)
                    {
                        pipeBox.Offset(new Point(delta, 0));
                    }
                    else if (pipe is RightPipeTop)
                    {
                        pipeBox.Offset(new Point(-delta, 0));
                    }
                    if (pipeBox.Intersects(beneathPlayer))
                    {
                        CollisionDirection dir = CollisionDir(beneathPlayer, pipe.BoundingRectangle());
                        if (Keyboard.GetState().IsKeyDown(Keys.Down) && dir == CollisionDirection.Top)
                        {
                            Game1.GameInstance.State = new EnteringPipeDown(MiscUtilityClass.PipeTransitionTime);
                        }
                    }
                }
            }
        }
    }
}
