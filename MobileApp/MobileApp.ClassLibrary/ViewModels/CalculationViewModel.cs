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
        public BaseCommand CheckCommand { get; set; }
        public BaseCommand NewCommand { get; set; }

        private MathematicalOperation _MathematicalOperation;

        private string _feedback;
        public string Feedback { get { return _feedback; } set { _feedback = value; OnPropertyChanged("Feedback"); } }

        private Numerical _item;
        public Numerical Item { get { return _item; } set { _item = value; OnPropertyChanged("Item"); } }

        public CalculationViewModel(HomeSelection homeSelection)
        {
            _MathematicalOperation = homeSelection.MathematicalOperation;
            CheckCommand = new BaseCommand(SaveClick);
            NewCommand = new BaseCommand(NewClick);
            NewQuestion();
        }

        private void NewClick()
        {
            NewQuestion();
        }

        private void SaveClick()
        {
            this.Item.Result = false;

            switch (_MathematicalOperation)
            {
                case MathematicalOperation.Addition:
                    this.Item.Result = this.Item.Number1 + this.Item.Number2 == this.Item.Answer;
                    break;
                case MathematicalOperation.Subtraction:
                    this.Item.Result = this.Item.Number1 - this.Item.Number2 == this.Item.Answer;
                    break;
                case MathematicalOperation.Multiplication:
                    this.Item.Result = this.Item.Number1 * this.Item.Number2 == this.Item.Answer;
                    break;
                case MathematicalOperation.Division:
                    this.Item.Result = this.Item.Number1 / this.Item.Number2 == this.Item.Answer;
                    break;
            }


            this.Feedback = (this.Item.Result.Value) ? Constants.CORRECT_ANSWER : Constants.INCORRECT_ANSWER;
        }

        
        private void NewQuestion()
        {
            Random rndRandom = new Random(DateTime.Now.Millisecond);

            this.Item = new Numerical();


            Item.MathematicalOperation = _MathematicalOperation;

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
                    Item.Number1 = rndRandom.Next(2, 10 / 2) * 2;
                    if (Item.Number1 == 0)
                        Item.Number1 = 1;
                    Item.Number2 = rndRandom.Next(1, Item.Number1 / 2) * 2;

                    //if(Item.Number1 Mod )
                    break;
            }

            
            Item.Result = null;

            this.Feedback = null;
        }




    }

    

}
