using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Input;
using MobileApp.Enum;
using MobileApp.Helpers;
using MobileApp.Models;
using Xamarin.Forms;

namespace MobileApp.ViewModels
{
    
    public class CalculationViewModel: BaseDataObject
    {
        private readonly DifficultyLevelEnum _difficultyLevelEnum;
        public BaseCommand CheckCommand { get; set; }
        public BaseCommand NewCommand { get; set; }

        private MathematicalOperation _MathematicalOperation;

        public bool CheckVisible { get; set; }
        public bool NewVisible { get; set; }

        private string _feedback;
        public string Feedback { get { return _feedback; } set { _feedback = value; OnPropertyChanged("Feedback"); } }

        private CalculationModel _item;
        public CalculationModel Item { get { return _item; } set { _item = value; OnPropertyChanged("Item"); } }

        public CalculationViewModel(HomeSelection homeSelection, DifficultyLevelEnum difficultyLevelEnum)
        {
            _difficultyLevelEnum = difficultyLevelEnum;
            _MathematicalOperation = homeSelection.MathematicalOperation;
            CheckCommand = new BaseCommand(SaveClick);
            NewCommand = new BaseCommand(NewClick);
            NewQuestion();
            CheckVisible = true;
            NewVisible = false;
        }

        private void NewClick()
        {
            NewQuestion();
            CheckVisible = true;
            NewVisible = false;
        }

        private void SaveClick()
        {
            if (!string.IsNullOrWhiteSpace(this.Item.Answer))
            {
                this.Item.Result = false;
                var answer = int.Parse(this.Item.Answer);


                switch (_MathematicalOperation)
                {
                    case MathematicalOperation.Addition:
                        this.Item.Result = this.Item.Number1 + this.Item.Number2 == answer;
                        break;
                    case MathematicalOperation.Subtraction:
                        this.Item.Result = this.Item.Number1 - this.Item.Number2 == answer;
                        break;
                    case MathematicalOperation.Multiplication:
                        this.Item.Result = this.Item.Number1 * this.Item.Number2 == answer;
                        break;
                    case MathematicalOperation.Division:
                        this.Item.Result = this.Item.Number1 / this.Item.Number2 == answer;
                        break;
                }

                if (this.Item.Result.Value)
                {
                    this.Feedback = Constants.CORRECT_ANSWER;
                    this.NewVisible = true;
                    this.CheckVisible = !this.NewVisible;
                }
                else
                {
                    this.Feedback = Constants.INCORRECT_ANSWER;
                    this.CheckVisible = true;
                    this.NewVisible = !this.CheckVisible;
                }
                    


            }
        }

        
        private void NewQuestion()
        {
            Random rndRandom = new Random(DateTime.Now.Millisecond);

            this.Item = new CalculationModel();


            Item.MathematicalOperation = _MathematicalOperation;

            if (_difficultyLevelEnum == DifficultyLevelEnum.Easy)
            {
                switch (_MathematicalOperation)
                {
                    case MathematicalOperation.Addition:
                        Item.Number1 = rndRandom.Next(1, 10);
                        Item.Number2 = rndRandom.Next(1, 10);
                        break;
                    case MathematicalOperation.Subtraction:
                        Item.Number1 = rndRandom.Next(1, 10);
                        Item.Number2 = rndRandom.Next(1, Item.Number1);
                        break;
                    case MathematicalOperation.Multiplication:
                        Item.Number1 = rndRandom.Next(1, 10);
                        Item.Number2 = rndRandom.Next(1, 10);
                        break;
                    case MathematicalOperation.Division:
                        Item.Number2 = rndRandom.Next(1, 20);

                        Item.Number1 = Item.Number2 * rndRandom.Next(2, 5);
                        if (Item.Number1 == 0)
                            Item.Number1 = 1;

                        break;
                }
            }
            else if (_difficultyLevelEnum == DifficultyLevelEnum.Medium)
            {
                switch (_MathematicalOperation)
                {
                    case MathematicalOperation.Addition:
                        Item.Number1 = rndRandom.Next(1, 99);
                        Item.Number2 = rndRandom.Next(1, 99);
                        break;
                    case MathematicalOperation.Subtraction:
                        Item.Number1 = rndRandom.Next(1, 99);
                        Item.Number2 = rndRandom.Next(1, Item.Number1);
                        break;
                    case MathematicalOperation.Multiplication:
                        Item.Number1 = rndRandom.Next(1, 12);
                        Item.Number2 = rndRandom.Next(1, 10);
                        break;
                    case MathematicalOperation.Division:
                        Item.Number2 = rndRandom.Next(1, 50);

                        Item.Number1 = Item.Number2 * rndRandom.Next(2, 20);
                        if (Item.Number1 == 0)
                            Item.Number1 = 1;
                        
                        break;
                }
            }
            else if (_difficultyLevelEnum == DifficultyLevelEnum.Hard)
            {
                switch (_MathematicalOperation)
                {
                    case MathematicalOperation.Addition:
                        Item.Number1 = rndRandom.Next(1, 999);
                        Item.Number2 = rndRandom.Next(1, 999);
                        break;
                    case MathematicalOperation.Subtraction:
                        Item.Number1 = rndRandom.Next(1, 999);
                        Item.Number2 = rndRandom.Next(1, Item.Number1);
                        break;
                    case MathematicalOperation.Multiplication:
                        Item.Number1 = rndRandom.Next(1, 15);
                        Item.Number2 = rndRandom.Next(1, 10);
                        break;
                    case MathematicalOperation.Division:
                        Item.Number2 = rndRandom.Next(1, 90);

                        Item.Number1 = Item.Number2 * rndRandom.Next(2, 20);
                        if (Item.Number1 == 0)
                            Item.Number1 = 1;

                        break;
                }
            }


            Item.Result = null;

            this.Feedback = null;
        }




    }

    

}
