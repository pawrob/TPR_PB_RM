using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
    public class Command : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Action m_action;

        public Command(Action action)
        {
            this.m_action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Task.Run(() =>
            {
                this.m_action();
            });
        }
    }
}
