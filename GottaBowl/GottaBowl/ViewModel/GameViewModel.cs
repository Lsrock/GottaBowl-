using GottaBowl.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GottaBowl.ViewModel
{
    public class GameViewModel
    {
        public GameViewModel()
        {

            gameFrames = new FrameModel[10];
            for (int i = 0; i < 10; i++)
            {
                var bowlingFrame = new FrameModel(i+1);
                bowlingFrame.ScoreEntered += BowlingFrame_ScoreEntered;
                gameFrames[i] = bowlingFrame;
            }
            Frame10.HasBonusRoll = true;
        }

        private void BowlingFrame_ScoreEntered(object? sender, EventArgs e)
        {
            UpdateGameScore();
        }

        public void Reset()
        {

            for (int i = 0; i < gameFrames.Length; i++)
            {
                
                gameFrames[i].FirstRollString = "";
                gameFrames[i].SecondRollString = "";
                gameFrames[i].BonusRollString = "";
                gameFrames[i].Score = 0;


            }
        }

        private void UpdateGameScore()
        {
            int runningTotal = 0;
            for(int i = 0; i < gameFrames.Length; i++)
            {
                FrameModel frame = gameFrames[i];

                int tempScore = 0;
                if (frame.FirstRollString != "")
                {
                    if (IsStrike(frame.FirstRollString)) // add next two rolls to total
                    {
                        tempScore += 10; //add 10 if first roll is a strike
                        if (frame.HasBonusRoll) { // if last frame
                            if(IsStrike(frame.SecondRollString)) // if second roll in last frame is a strike
                            {
                                tempScore += 10;
                                if (IsStrike(frame.BonusRollString)) // if bonus roll in last frame is a strike
                                {
                                    tempScore += 10;
                                }
                                else // add whatever pins were knocked down in last roll
                                {
                                    tempScore += ParseRoll(frame.BonusRollString);
                                }
                            } else 
                            {
                                tempScore += ParseRoll(frame.SecondRollString); // add second roll pins
                                if (IsSpare(frame.BonusRollString)){ // if spare on last roll in last frame
                                    tempScore += 10 - ParseRoll(frame.SecondRollString); // calculating pins that weren't knocked down and add them
                                } else
                                {
                                    tempScore += ParseRoll(frame.BonusRollString); // add whatever pins were knocked down in last roll
                                }
                            }

                        } else
                        {
                            // should probably check if i+1 is out of bounds
                            FrameModel nextFrame = gameFrames[i + 1]; // grabbing next frame
                            if (IsStrike(nextFrame.FirstRollString)) // checking if the next frame's first roll is a strike
                            {
                                tempScore += 10;
                                if (nextFrame.HasBonusRoll) //checking if the next frame is frame 10
                                {
                                    if (IsStrike(nextFrame.SecondRollString)) // checking if the next frame's second roll is a strike
                                    {
                                        tempScore += 10;
                                    } else
                                    {
                                        tempScore += ParseRoll(frame.SecondRollString); // add whatever pins were knocked down in second roll
                                    }
                                } else
                                {
                                    // really should check if i+2 is out of bounds
                                    FrameModel nexterFrame = gameFrames[i + 2]; // getting the frame after next frame
                                    if(IsStrike(nexterFrame.FirstRollString))
                                    {
                                        tempScore += 10;
                                    } else
                                    {
                                        tempScore += ParseRoll(nexterFrame.FirstRollString); // add whatever pins were knocked down in first roll
                                    }
                                }
                            }
                            else
                            {
                                tempScore += ParseRoll(nextFrame.FirstRollString); // add whatever pins were knocked down in first roll
                                if (IsSpare(nextFrame.SecondRollString))
                                {
                                    tempScore += 10 - ParseRoll(nextFrame.FirstRollString);
                                } else
                                {
                                    tempScore += ParseRoll(nextFrame.SecondRollString);
                                }
                            }

                        }

                    }
                    else
                    {
                        tempScore += ParseRoll(frame.FirstRollString);
                    }
                }


                if (frame.SecondRollString != "")
                {
                    if (IsSpare(frame.SecondRollString))
                    {
                        tempScore += 10 - ParseRoll(frame.FirstRollString); // adding pins that weren't knocked down in first roll
                        if (frame.HasBonusRoll)
                        {
                            if (IsStrike(frame.BonusRollString))
                            {
                                tempScore += 10;
                            } else
                            {
                                tempScore += ParseRoll(frame.BonusRollString); // add whatever pins were knocked down in bonus roll
                            }
                        } else
                        {
                            // noticing a pattern here
                            FrameModel nextFrame = gameFrames[i + 1]; // grabbing next frame
                            if (IsStrike(nextFrame.FirstRollString))
                            {
                                tempScore += 10;
                            } else
                            {
                                tempScore += ParseRoll(nextFrame.FirstRollString); // add whatever pins were knocked down in first roll
                            }
                        }
                    } else
                    {
                        tempScore += ParseRoll(frame.SecondRollString);

                    }
                }

                frame.Score = tempScore + runningTotal;

                runningTotal += tempScore;
            }
        }

        private bool IsStrike(string rollString)
        {
            if (rollString == null)
                return false;
            return rollString.Equals("x", StringComparison.OrdinalIgnoreCase);
        }
        private bool IsSpare(string rollString)
        {
            if(rollString == null)
                return false;
            return rollString.Equals("/", StringComparison.OrdinalIgnoreCase);
        }
        private int ParseRoll(string rollString)
        {
            if(rollString == null || rollString == "")
                return 0;
            return Convert.ToInt32(rollString);
        }

        private FrameModel[] gameFrames;

        public FrameModel Frame1 => gameFrames[0];
        public FrameModel Frame2 => gameFrames[1];
        public FrameModel Frame3 => gameFrames[2];
        public FrameModel Frame4 => gameFrames[3];
        public FrameModel Frame5 => gameFrames[4];
        public FrameModel Frame6 => gameFrames[5];
        public FrameModel Frame7 => gameFrames[6];
        public FrameModel Frame8 => gameFrames[7];
        public FrameModel Frame9 => gameFrames[8];
        public FrameModel Frame10 => gameFrames[9];
    }



}
