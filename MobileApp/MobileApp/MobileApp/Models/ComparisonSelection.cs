using MobileApp.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MobileApp.Models
{
    public class ComparisonSelection : BaseDataObject 
    {
        private ComparisionOperation _ComparisionOperation;
        
        public ComparisionOperation ComparisionOperation
        {
            get
            {
                return _ComparisionOperation;
            }
            set
            {
                _ComparisionOperation = value;
                OnPropertyChanged("ComparisionOperation");
            }
        }

    }
}
