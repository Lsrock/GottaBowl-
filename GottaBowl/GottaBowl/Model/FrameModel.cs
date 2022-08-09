using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GottaBowl.Model
{

    public class FrameModel : INotifyPropertyChanged
    {
        public FrameModel(int frameNum)
        {
            FrameNum = frameNum;
            FirstRollString = "";
            SecondRollString = "";
            BonusRollString = "";
            firstRollString = "";
            secondRollString = "";
            bonusRollString = "";
            Score = 0;
        }

        public int FrameNum { get; }
        private string firstRollString;

        //bools
        public bool HasBonusRoll { get; set; }

        public string FirstRollString {
            get => firstRollString;
            set {
                
                if(value.Equals("x", StringComparison.OrdinalIgnoreCase))
                {
                    firstRollString = value; // sets string as x

                    OnPropertyChanged(nameof(FirstRollString));
                    OnScoreEntered();

                }
                else if(int.TryParse(value, out int numScore))
                {
                    if(numScore >= 0 && numScore < 10)
                    {
                        firstRollString = value; // sets string as 0-9

                        OnPropertyChanged(nameof(FirstRollString));
                        OnScoreEntered();
                    }
                } else if (value == "")
                {
                    firstRollString = value;
                    OnPropertyChanged(nameof(FirstRollString));
                    OnScoreEntered();
                }
            }
        }
        private string secondRollString;
        public string SecondRollString
        {
            get => secondRollString;
            set
            {
                if (value.Equals("x", StringComparison.OrdinalIgnoreCase))
                {
                    secondRollString = value; // sets string as x

                    OnPropertyChanged(nameof(SecondRollString));
                    OnScoreEntered();

                }
                else if (value.Equals("/", StringComparison.OrdinalIgnoreCase))
                {
                    secondRollString = value; //sets string as /

                    OnPropertyChanged(nameof(SecondRollString));
                    OnScoreEntered();
                }
                else if(int.TryParse(value, out int numScore))
                {
                    if (numScore >= 0 && numScore < 10)
                    {
                        secondRollString = value; // sets string as 0-9

                        OnPropertyChanged(nameof(SecondRollString));
                        OnScoreEntered();
                    }
                }
                else if (value == "")
                {
                    secondRollString = value;
                    OnPropertyChanged(nameof(SecondRollString));
                    OnScoreEntered();
                }
            }

        }
        private string bonusRollString;
        public string BonusRollString
        {
            get => bonusRollString;
            set
            {
                 if (value.Equals("x", StringComparison.OrdinalIgnoreCase))
                {
                    bonusRollString = value; // sets string as x

                    OnPropertyChanged(nameof(BonusRollString));
                    OnScoreEntered();

                }
                else if (int.TryParse(value, out int numScore))
                {
                    if (numScore >= 0 && numScore < 10)
                    {
                        bonusRollString = value; // sets string as 0-9

                        OnPropertyChanged(nameof(BonusRollString));
                        OnScoreEntered();
                    }
                }
                else if (value == "")
                {
                    bonusRollString = value;
                    OnPropertyChanged(nameof(BonusRollString));
                    OnScoreEntered();
                }
            }
        }

        private int _frameScore;
        public int Score {
            get => _frameScore;
            set
            {
                _frameScore = value;
                OnPropertyChanged(nameof(Score));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event EventHandler? ScoreEntered;

        private void OnScoreEntered()
        {
            ScoreEntered?.Invoke(this, new EventArgs());
        }

    }
}
