using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DollarConverter.Client
{
    class GenericCommand : ICommand
    {
        private Action _action;

        public event EventHandler CanExecuteChanged;

        public GenericCommand(Action act)
        {
            _action = act;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _action();
        }
    }
}
