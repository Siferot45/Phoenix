using Phoenix.Helpers.Commands.Base;
using System;
using System.ComponentModel;

namespace Phoenix.Helpers.Commands
{
    internal class CommandHelperT<T> : CommandBase
    {
        private Action<T>? _execute;
        private Func<T, bool> _canExecute;

        public CommandHelperT(Action<T> Execute, Func<T, bool>? CanExecute = null)
        {
            _execute = Execute ?? throw new ArgumentNullException("ExecuteAction");
            _canExecute = (Func<T, bool>?)(MulticastDelegate)CanExecute;
        }

        public override bool CanExecute(object? parameter) => _canExecute?.Invoke((T)parameter) ?? true;

        public override void Execute(object? parameter)
        {
            if (!CanExecute(parameter))
                return;

            _execute((T)parameter);
        }
    }
}
