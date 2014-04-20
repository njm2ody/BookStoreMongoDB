using System;
using System.Windows.Input;

namespace GUI
{
    public class RelayCommand : ICommand
    {
        public RelayCommand(Action<object> ExecuteHandler, Func<object, bool> CanExecuteHandler)
        {
            _executeHandler = ExecuteHandler;
            _canExecuteHandler = CanExecuteHandler;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecuteHandler.Invoke(parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(this, new EventArgs());
            }
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            _executeHandler.Invoke(parameter);
        }

        private Action<object> _executeHandler;

        private Func<object, bool> _canExecuteHandler;
    }
}
