using MobileApp.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MobileApp.Models
{
    public class HomeSelection : BaseDataObject 
    {
        private MathematicalOperation _MathematicalOperation;
        
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

    }
}
