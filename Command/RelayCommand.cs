using System;
using System.Windows.Input;

namespace VaccineManagement.Command
{
    public class RelayCommand<T> : ICommand
    {
        private readonly Predicate<T> _canExecute;
        private readonly Action<T> _execute;

        public RelayCommand(Action<T> execute, Predicate<T> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        // Kiểm tra xem command có thể thực thi không
        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute((T)parameter);
        }

        // Thực thi hành động khi command được gọi
        public void Execute(object parameter)
        {
            _execute((T)parameter);
        }

        // Sự kiện thay đổi khả năng thực thi của command
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
