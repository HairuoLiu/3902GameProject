using _3902GameProject.Classes.Collision;
using _3902GameProject.Classes.EnemyStates;
using _3902GameProject.Classes.SystemSprites;
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
    public static class FireballCollision
    {
        public static void CollisionCheck(IMario mario)
        {
            ILevel level = Game1.GameInstance.GameLevel;

            List<IWeapon> tempFireballs = new List<IWeapon>();
            tempFireballs.AddRange(mario.Fireballs);
            foreach (Fireball f in tempFireballs)
            {
                Rectangle fireballBox = f.BoundingRectangle();
                foreach (IGameObject obj in level.MovingObjects)
                {
                    Rectangle rec = obj.BoundingRectangle();
                    if (fireballBox.Intersects(rec) && obj is IEnemy enemy && !(enemy.IsDead))
                    {
                        SoundControl.PlaySoundEffect(Sound.kickEffect);
                        f.Destroy();
                        EnemyCollision.EnemyHitsMario(enemy, CollisionDirection.Top, true, f.Physics.XVelocity < 0, true); ////Placeholder with bad naming but same reaction
                    }
                }

                fireballBox.Inflate(2, 0);
                IList<Rectangle> collisionBoxes = new List<Rectangle>();
                foreach (IGameObject obj in level.StaticObjects)
                {
                    Rectangle objBox = obj.BoundingRectangle();
                    if (objBox.Intersects(fireballBox))
                    {
                        collisionBoxes.Add(obj.BoundingRectangle());
                    }
                }
                CombineRectangles(collisionBoxes);
                foreach (Rectangle box in collisionBoxes)
                {
                    if (CollisionDir(fireballBox, box) == CollisionDirection.Top)
                        f.Bounce(box.Top);
                    else
                        f.Destroy();
                }
            }
        }
    }
}
