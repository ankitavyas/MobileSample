using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using MobileApp.Enum;

namespace MobileApp.Models
{
    public class CalculationModel : NumberModel
    {
        private bool? _result;
        private string _answer ;
        private MathematicalOperation _mathematicalOperation;

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

        public MathematicalOperation MathematicalOperation
        {
            get
            {
                return _mathematicalOperation;
            }
            set
            {
                _mathematicalOperation = value;
                OnPropertyChanged("MathematicalOperation");
            }
        }

        public string Symbol
        {
            get
            {
                var type = typeof(MathematicalOperation);
                var memInfo = type.GetMember(MathematicalOperation.ToString());
                var attributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                var description = ((DescriptionAttribute)attributes[0]).Description;
                return description;
            }
        }

       
    }
}
