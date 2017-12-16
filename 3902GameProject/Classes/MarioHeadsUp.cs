using _3902GameProject.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using _3902GameProject.Classes.UtilityClasses;

namespace _3902GameProject.Classes
{
    class MarioHeadsUp : IHeadsUp
    {
        private SpriteFont headsUpFont;

        public MarioHeadsUp()
        {
            headsUpFont = FontFactory.Instance.CreateHeadsUpFont();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            IScore scorekeeper = Game1.GameInstance.Scorekeeper;
            int offset = (int) (Game1.WINDOW_WIDTH_BASE * Game1.Scale) / 5;

            DrawString(spriteBatch, StringConsts.WorldTitle, new Vector2(MiscUtilityClass.WorldXOffset, MiscUtilityClass.TopLevelYOffset));
            DrawString(spriteBatch, scorekeeper.Level, new Vector2(MiscUtilityClass.WorldXOffset, MiscUtilityClass.BottomLevelYOffset));
            DrawString(spriteBatch, StringConsts.CoinTitle, new Vector2(MiscUtilityClass.WorldXOffset + offset, MiscUtilityClass.TopLevelYOffset));
            DrawString(spriteBatch, scorekeeper.Coins.ToString(), new Vector2(MiscUtilityClass.WorldXOffset + offset, MiscUtilityClass.BottomLevelYOffset));
            DrawString(spriteBatch, StringConsts.PointTitle, new Vector2(MiscUtilityClass.WorldXOffset + offset * 2, MiscUtilityClass.TopLevelYOffset));
            DrawString(spriteBatch, scorekeeper.Points.ToString(), new Vector2(MiscUtilityClass.WorldXOffset + offset * 2, MiscUtilityClass.BottomLevelYOffset));
            DrawString(spriteBatch, StringConsts.TimeTitle, new Vector2(MiscUtilityClass.WorldXOffset + offset * 3, MiscUtilityClass.TopLevelYOffset));
            DrawString(spriteBatch, scorekeeper.Time.ToString(), new Vector2(MiscUtilityClass.WorldXOffset + offset * 3, MiscUtilityClass.BottomLevelYOffset));
            DrawString(spriteBatch, StringConsts.LivesTitle, new Vector2(MiscUtilityClass.WorldXOffset + offset * 4, MiscUtilityClass.TopLevelYOffset));
            DrawString(spriteBatch, scorekeeper.Lives.ToString(), new Vector2(MiscUtilityClass.WorldXOffset + offset * 4, MiscUtilityClass.BottomLevelYOffset));
        }

        private void DrawString(SpriteBatch spriteBatch, string str, Vector2 vec)
        {
            spriteBatch.DrawString(headsUpFont, str, vec, Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.None, 1f);
        }
    }
}
