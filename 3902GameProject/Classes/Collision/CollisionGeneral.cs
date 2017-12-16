using _3902GameProject.Classes.Collision;
using _3902GameProject.Classes.EnemyStates;
using _3902GameProject.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _3902GameProject.Classes
{
    public static class CollisionGeneral
    {
        public enum CollisionDirection
        {
            Left,
            Right,
            Top,
            Bottom,
            None
        };

        public static CollisionDirection CollisionDir(Rectangle recOne, Rectangle recTwo)
        {
            CollisionDirection colDirection = CollisionDirection.None;

            Rectangle overlap = Rectangle.Intersect(recOne, recTwo);
            if (overlap.Width >= overlap.Height)
            {
                if (recOne.Y < recTwo.Y)
                    colDirection = CollisionDirection.Top;
                else
                    colDirection = CollisionDirection.Bottom;
            }
            else
            {
                if (recOne.X > recTwo.X)
                    colDirection = CollisionDirection.Right;
                else
                    colDirection = CollisionDirection.Left;
            }

            return colDirection;
        }

        public static CollisionDirection CollisionDir(Rectangle recOne, float recOneYVelocity, Rectangle recTwo)
        {
            Rectangle overlap = Rectangle.Intersect(recOne, recTwo);
            if ((recOne.Y < recTwo.Y) && (overlap.Width > overlap.Height - UtilityClasses.CollisionUtilityConsts.BigOverlapCheck) && (recOneYVelocity > UtilityClasses.CollisionUtilityConsts.VelocityCheck))
            {
                return CollisionDirection.Top;
            }
            return CollisionDir(recOne, recTwo);
        }

        private static bool CanCombineRectangles(Rectangle recA, Rectangle recB)
        {
            if (recA.Top == recB.Top && recA.Bottom == recB.Bottom)
            {
                if (recA.Left - recB.Right <= UtilityClasses.CollisionUtilityConsts.SmallOverlapCheck && recA.Right - recB.Left >= -UtilityClasses.CollisionUtilityConsts.SmallOverlapCheck)
                    return true;
                else if (recB.Left - recA.Right <= UtilityClasses.CollisionUtilityConsts.SmallOverlapCheck && recB.Right - recA.Left >= -UtilityClasses.CollisionUtilityConsts.SmallOverlapCheck)
                    return true;
            }
            else if (recA.Left == recB.Left && recA.Right == recB.Right)
            {
                if (recA.Top - recB.Bottom <= UtilityClasses.CollisionUtilityConsts.SmallOverlapCheck && recA.Bottom - recB.Top >= -UtilityClasses.CollisionUtilityConsts.SmallOverlapCheck)
                    return true;
                else if (recB.Top - recA.Bottom <= UtilityClasses.CollisionUtilityConsts.SmallOverlapCheck && recB.Bottom - recA.Top >= -UtilityClasses.CollisionUtilityConsts.SmallOverlapCheck)
                    return true;
            }
            return false;
        }

        private static Rectangle CombineRectangles(Rectangle recA, Rectangle recB)
        {
            if (recA.Top == recB.Top && recA.Bottom == recB.Bottom)
                return new Rectangle(Math.Min(recA.Left, recB.Left), recA.Top, Math.Max(recA.Right - recB.Left, recB.Right - recA.Left), recA.Height);
            else
                return new Rectangle(recA.Left, Math.Min(recA.Top, recB.Top), recA.Width, Math.Max(recA.Bottom - recB.Top, recB.Bottom - recA.Top));
        }

        public static void CombineRectangles(IList<Rectangle> rectangles)
        {
            int prevLength = 0;
            int newLength = rectangles.Count;
            while (newLength != prevLength)
            {
                prevLength = rectangles.Count;
                int i, j;
                Rectangle recA, recB;
                for (i = 0; i < prevLength; i++)
                {
                    for (j = i + 1; j < prevLength; j++)
                    {
                        recA = rectangles.ElementAt(i);
                        recB = rectangles.ElementAt(j);
                        if (CanCombineRectangles(recA, recB))
                        {
                            rectangles.Remove(recA);
                            rectangles.Remove(recB);
                            rectangles.Add(CombineRectangles(recA, recB));
                            i = prevLength;
                            j = prevLength;
                        }
                    }
                }
                newLength = rectangles.Count;
            }
        }
    }
}
