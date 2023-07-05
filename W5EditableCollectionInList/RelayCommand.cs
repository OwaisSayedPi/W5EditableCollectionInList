using System;
using System.Windows.Input;

namespace W5EditableCollectionInList
{
    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        Action vm;
        Action<int> vmAction;
        public RelayCommand(Action action)
        {
            vm = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            vm?.Invoke();
        }
    }
}