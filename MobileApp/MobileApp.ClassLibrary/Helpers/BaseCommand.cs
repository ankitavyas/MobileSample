using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace MobileApp.Helpers
{
    public class BaseCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Action _action;
        public BaseCommand(Action action)
        {
            _action = action;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _action.Invoke();
        }
    }
}
