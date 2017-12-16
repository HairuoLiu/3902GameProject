using _3902GameProject.Classes.Portals;
using _3902GameProject.Classes.UtilityClasses;
using _3902GameProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3902GameProject.Classes
{
    public static class CSVLevelLoader
    {
        public static void LoadFromFile(ILevel level, String file)
        {
            String[] inputLines = System.IO.File.ReadAllLines(file);
            for (int i = 0; i < inputLines.Length; i++)
            {
                String[] currLine = inputLines[i].Split(',');
                for (int j = 0; j < currLine.Length; j++)
                {
                    String[] currentInput = currLine[j].Split('+');
                    String baseInput = currentInput[0];
                    Func<int, int, IItem> additionalInput = null;
                    if (currentInput.Length == 2)
                    {
                        additionalInput = AdditionalInputFunciton(currentInput[1]);
                    }
                    else if (currentInput.Length > 2)
                    {
                        throw new NotImplementedException();
                    }
                    GenericPipe pipe;
                    switch (baseInput)
                    {
                        case "LeftPipeTop":
                            level.AddObject(SceneSpriteFactory.Instance.CreateLeftPipeTop(16 * j, 16 * i), true);
                            break;
                        case "RightPipeTop":
                            pipe = (GenericPipe) SceneSpriteFactory.Instance.CreateRightPipeTop(16 * j, 16 * i);
                            level.AddObject(pipe, true);
                            break;
                        case "LeftPipeTopP":
                            pipe = (GenericPipe)SceneSpriteFactory.Instance.CreateLeftPipeTop(16 * j, 16 * i);
                            pipe.Psg = true;
                            level.AddObject(pipe, true);
                            break;
                        case "RightPipeTopP":
                            pipe = (GenericPipe)SceneSpriteFactory.Instance.CreateRightPipeTop(16 * j, 16 * i);
                            pipe.Psg = true;
                            level.AddObject(pipe, true);
                            break;
                        case "LeftPipePiece":
                            level.AddObject(SceneSpriteFactory.Instance.CreateLeftPipePiece(16 * j, 16 * i), true);
                            break;
                        case "RightPipePiece":
                            level.AddObject(SceneSpriteFactory.Instance.CreateRightPipePiece(16 * j, 16 * i), true);
                            break;
                        case "Castle":
                            level.AddObject(SceneSpriteFactory.Instance.CreateCastle(16 * j, 16 * i), true);
                            break;
                        case "Flag":
                            level.AddObject(SceneSpriteFactory.Instance.CreateFlagPole(16 * j, 16 * i), true);
                            level.AddObject(SceneSpriteFactory.Instance.CreateFlag(16 * j - 8, 16 * i - 124), true);
                            break;
                        case "FinishLine":
                            level.AddObject(SceneSpriteFactory.Instance.CreateFinishLine(16 * j, 16 * i), true);
                            break;
                        case "Goomba":
                            level.AddObject(new Goomba(16 * j, 16 * i), false);
                            break;
                        case "JuggleGoomba":
                            level.AddObject(new JuggleEnemy(new Goomba(16 * j, 16 * i)), false);
                            break;
                        case "Turtle":
                            level.AddObject(new Turtle(16 * j, 16 * i), false);
                            break;
                        case "JuggleTurtle":
                            level.AddObject(new JuggleEnemy(new Turtle(16 * j, 16 * i)), false);
                            break;
                        case "Mario":
                            level.SetPlayer(new Mario(16 * j, 16 * i));
                            break;
                        case "Marth":
                            level.SetPlayer(new Marth(16 * j, 16 * i));
                            break;
                        case "StoneBlock":
                            level.AddObject(BlockSpriteFactory.Instance.CreateStoneBlock(16 * j, 16 * i), true);
                            break;
                        case "GroundBlock":
                            level.AddObject(BlockSpriteFactory.Instance.CreateGroundBlock(16 * j, 16 * i), true);
                            break;
                        case "DarkGroundBlock":
                            level.AddObject(BlockSpriteFactory.Instance.CreateDarkGroundBlock(16 * j, 16 * i), true);
                            break;
                        case "HiddenBlock":
                            level.AddObject(BlockSpriteFactory.Instance.CreateHiddenBlock(16 * j, 16 * i, additionalInput), true);
                            break;
                        case "QuestionBlock":
                            level.AddObject(BlockSpriteFactory.Instance.CreateQuestionBlock(16 * j, 16 * i, additionalInput), true);
                            break;
                        case "BrickBlock":
                            level.AddObject(BlockSpriteFactory.Instance.CreateBrickBlock(16 * j, 16 * i, additionalInput), true);
                            break;
                        case "DarkBrickBlock":
                            level.AddObject(BlockSpriteFactory.Instance.CreateDarkBrickBlock(16 * j, 16 * i, additionalInput), true);
                            break;
                        case "Coin":
                            level.AddObject(ItemSpriteFactory.Instance.CreateStaticCoin(16 * j, 16 * i), false);
                            break;
                        case "1HitBrickBlock":
                        case "9HitBrickBlock":
                            level.AddObject(BlockSpriteFactory.Instance.CreateMultiHitBrickBlock(16 * j, 16 * i, additionalInput, (int)baseInput[0] - (int)'0'), true);
                            break;
                        case "HorPipe":
                            level.AddObject(SceneSpriteFactory.Instance.CreateHorPipe(16 * j, 16 * i), true);
                            break;
                        case "OrangePortal":
                            level.AddObject(PortalSpriteFactory.Instance.CreateOrangePortal(16*j,16*i), true);
                            break;
                        case "BluePortal":
                            level.AddObject(PortalSpriteFactory.Instance.CreateBluePortal(16 * j, 16 * i), true);
                            break;
                        case "PortalGun":
                            level.AddObject(PortalSpriteFactory.Instance.CreatePortalGun(16 * j, (16 * i) - SpriteUtilityConsts.SmallGap), true);
                            break;
                        case "BigMushroom":
                            level.AddObject(ItemSpriteFactory.Instance.CreateBigMushroom(16 * j, 16 * i),false);
                            break;
                        case "*":
                        case "":
                            break;
                        default:
                            throw new NotImplementedException();
                    }
                }
            }
        }

        private static Func<int, int, IItem> AdditionalInputFunciton(String str)
        {
            switch (str)
            {
                case "FireFlower":
                    return ItemSpriteFactory.Instance.CreateFireFlower;
                case "BigMushroom":
                    return ItemSpriteFactory.Instance.CreateBigMushroom;
                case "LifeMushroom":
                    return ItemSpriteFactory.Instance.CreateLifeMushroom;
                case "Coin":
                    return ItemSpriteFactory.Instance.CreateCoin;
                case "Star":
                    return ItemSpriteFactory.Instance.CreateStar;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
