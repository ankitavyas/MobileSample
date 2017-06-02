using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using MobileApp.Enum;

namespace MobileApp.Models
{
    public class NumberModel : BaseDataObject 
    {
        private int _number1;
        private int _number2;
        
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

       
    }
}
