using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Storage.Wpf.Classes
{
    public class StorageCommand : ICommand
    {
        readonly Action<object> execute;

        readonly Predicate<object> canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }


        #region Constructor

        public StorageCommand(Action<object> _execute, Predicate<object> _canExecute)
        {
            execute = _execute;
            canExecute = _canExecute;
        }

        public StorageCommand(Action<object> _execute) : this(_execute, null) { }

        private StorageCommand() { }

        #endregion

        public bool CanExecute(object parameter)
        {
            if (canExecute != null)
                return canExecute(parameter);

            return true;
        }

        public void Execute(object parameter)
        {
            execute(parameter);
        }
    }
}
