using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using MobileApp.Enum;

namespace MobileApp.Models
{
    public class Numerical : BaseDataObject 
    {
        private bool? _result;
        private int _number1;
        private int _number2;
        private int _answer ;
        private MathematicalOperation _MathematicalOperation;
        public int Number1
        {
            get
            {
                return _number1;
            }
            set
            {
                _number1 = value;
                OnPropertyChanged("Number1");
            }
        }

        public int Number2
        {
            get
            {
                return _number2;
            }
            set
            {
                _number2 = value;
                OnPropertyChanged("Number2");
            }
        }

        public int Answer
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
                return _MathematicalOperation;
            }
            set
            {
                _MathematicalOperation = value;
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
