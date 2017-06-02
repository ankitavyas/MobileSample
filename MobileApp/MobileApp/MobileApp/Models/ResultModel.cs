using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using MobileApp.Enum;

namespace MobileApp.Models
{
    public class ResultModel : NumberModel
    {
        private bool? _result;
        private string _answer ;

        public string Answer
        {
            get
            {
                return _answer;
            }
            set
            {
                _answer = value;
                OnPropertyChanged("Answer");
            }
        }


        public bool? Result
        {
            get
            {
                return _result; 
            }
            set
            {
                _result = value;
                OnPropertyChanged("Result");
            }
        }

        

       
    }
}
