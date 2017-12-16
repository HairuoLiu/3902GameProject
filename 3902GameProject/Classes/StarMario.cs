using _3902GameProject.Classes;
using _3902GameProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace _3902GameProject
{
    public class StarMario : IMario
    {
        public Boolean PUp { get; set; }
        public Boolean CanCollide { get; set; }
        public IObjectPhysics Physics
        {
            get
            {
                return this.decoratedMario.Physics;
            }
        }
        public IList<IWeapon> Fireballs
        {
            get
            {
                return this.decoratedMario.Fireballs;
            }
        }
        public Color Tint { get; set; }
        private IMario decoratedMario;
        private int starTimer = Classes.UtilityClasses.MiscUtilityClass.StarTimer;
        private int flashDelayCounter = 0;
        private int flashDelayTotal = Classes.UtilityClasses.MiscUtilityClass.FlashDelay;
        private int flashColorInt = 0;
        private Color[] flashingColors = { Color.White, Color.LightGreen, Color.Yellow, Color.LightSlateGray };

        public StarMario(Interfaces.IMario player)
        {
            decoratedMario = player;
            CanCollide = player.CanCollide;
        }

        public bool IsDead()
        {
            return decoratedMario.IsDead();
        }
        public Rectangle BoundingRectangle()
        {
            return decoratedMario.BoundingRectangle();
        }

        public void MakeFlag()
        {
            decoratedMario.MakeFlag();
        }

        public void Update()
        {
            flashDelayCounter++;
            if (flashDelayCounter >= flashDelayTotal)
            {
                flashDelayCounter = 0;
                flashColorInt = (flashColorInt + 1) % flashingColors.Length;
                decoratedMario.Tint = flashingColors[flashColorInt];
            }
            starTimer--;
            if (starTimer <= 0)
                RemoveDecorator();
            decoratedMario.Update();
        }

        public void Draw(SpriteBatch spritebatch)
        {
            decoratedMario.Draw(spritebatch);
        }

        private void RemoveDecorator()
        {
            decoratedMario.Tint = Color.White;
            Game1.GameInstance.GameLevel.SetPlayer(decoratedMario, this);
        }

        public void MoveLeft()
        {
            decoratedMario.MoveLeft();
        }

        public void MoveRight()
        {
            decoratedMario.MoveRight();
        }

        public void Jump()
        {
            decoratedMario.Jump();
        }

        public void ContinueJump()
        {
            decoratedMario.ContinueJump();
        }

        public void EndJump()
        {
            decoratedMario.EndJump();
        }

        public void BumpHead()
        {
            decoratedMario.BumpHead();
        }

        public void Crouch()
        {
            decoratedMario.Crouch();
        }

        public void Stand()
        {
            decoratedMario.Stand();
        }

        public void MakeSmall()
        {
            decoratedMario.MakeSmall();
        }

        public void MakeBig()
        {
            decoratedMario.MakeBig();
        }

        public void MakeFire()
        {
            decoratedMario.MakeFire();
        }

        public void MakeDead()
        {
            decoratedMario.MakeDead();
        }

        public bool IsTall()
        {
            return decoratedMario.IsTall();
        }

        public void Damage()
        {
        }

        public void SetGroundedState(bool isGrounded)
        {
            decoratedMario.SetGroundedState(isGrounded);
        }

        public void SetRunning(bool isRunning)
        {
            decoratedMario.SetRunning(isRunning);
        }

        public void ShootFireball()
        {
            decoratedMario.ShootFireball();
        }

        public void ShootOrangePortal()
        {
            decoratedMario.ShootOrangePortal();
        }

        public void ShootBluePortal()
        {
            decoratedMario.ShootBluePortal();
        }
    }
}
