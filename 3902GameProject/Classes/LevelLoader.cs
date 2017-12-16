using _3902GameProject.Classes.SceneSprites.Misc_Sprites;
using _3902GameProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3902GameProject.Classes
{
    public static class LevelLoader
    {
        public static Mario LoadFromFile(IList<IBlock> blocks, IList<IEnemy> enemies, IList<IItem> items, IList<IPipe> pipes, IList<GenericScenery> scenes, String file)
        {
            String[] inputLines = System.IO.File.ReadAllLines(file);
            Mario mario = null;
            for (int i = 0; i < inputLines.Length; i++)
            {
                for (int j = 0; j < inputLines[i].Length; j++)
                {
                    String currentLine = inputLines[i];
                    if(currentLine[j] == 'S')
                    {
                        blocks.Add(Classes.BlockSpriteFactory.Instance.CreateStoneBlock(16 * j, 16 * i));
                    }
                    else if(currentLine[j] == 'H') {
                        blocks.Add(Classes.BlockSpriteFactory.Instance.CreateHiddenBlock(16 * j, 16 * i, null));
                    }
                    else if (currentLine[j] == 'Q')
                    {
                        blocks.Add(Classes.BlockSpriteFactory.Instance.CreateQuestionBlock(16 * j, 16 * i, null));
                    }
                    else if (currentLine[j] == 'B')
                    {
                        blocks.Add(Classes.BlockSpriteFactory.Instance.CreateBrickBlock(16 * j, 16 * i, null));
                    }
                    else if (currentLine[j] == 'R')
                    {
                        blocks.Add(Classes.BlockSpriteFactory.Instance.CreateGroundBlock(16 * j, 16 * i));
                    }
                    else if (currentLine[j] == 'F')
                    {
                        items.Add(Classes.ItemSpriteFactory.Instance.CreateFireFlower(16 * j, 16 * (i + 1)));
                    }
                    else if (currentLine[j] == 'U')
                    {
                        items.Add(Classes.ItemSpriteFactory.Instance.CreateBigMushroom(16 * j, 16 * (i + 1)));
                    }
                    else if (currentLine[j] == 'L')
                    {
                        items.Add(Classes.ItemSpriteFactory.Instance.CreateLifeMushroom(16 * j, 16 * (i + 1)));
                    }
                    else if (currentLine[j] == '$')
                    {
                        items.Add(Classes.ItemSpriteFactory.Instance.CreateCoin(16 * j, 16 * (i + 1)));
                    }
                    else if (currentLine[j] == '*')
                    {
                        items.Add(Classes.ItemSpriteFactory.Instance.CreateStar(16 * j, 16 * (i + 1)));
                    }
                    else if (currentLine[j] == '[')
                    {
                        pipes.Add(Classes.SceneSpriteFactory.Instance.CreateLeftPipeTop(16 * j, 16 * i));
                    }
                    else if (currentLine[j] == ']')
                    {
                        pipes.Add(Classes.SceneSpriteFactory.Instance.CreateRightPipeTop(16 * j, 16 * i));
                    }
                    else if (currentLine[j] == '(')
                    {
                        pipes.Add(Classes.SceneSpriteFactory.Instance.CreateLeftPipePiece(16 * j, 16 * i));
                    }
                    else if (currentLine[j] == ')')
                    {
                        pipes.Add(Classes.SceneSpriteFactory.Instance.CreateRightPipePiece(16 * j, 16 * i));
                    }
                    else if (currentLine[j] == '&')
                    {
                        scenes.Add(Classes.SceneSpriteFactory.Instance.CreateCastle(16 * j, 16 * i));
                    }
                    else if (currentLine[j] == '|')
                    {
                        scenes.Add(Classes.SceneSpriteFactory.Instance.CreateIdleFlag(16 * j, 16 * i));
                    }
                    else if (currentLine[j] == 'G')
                    {
                        enemies.Add(new Classes.Goomba(16 * j, 16 * i));
                    }
                    else if (currentLine[j] == 'T')
                    {
                        enemies.Add(new Classes.Turtle(16 * j, 16 * i));
                    }
                    else if (currentLine[j] == 'M')
                    {
                        mario = (new Classes.Mario(16 * j, 16 * i));
                    }
                }
            }
            return mario;
        }
    }
}
