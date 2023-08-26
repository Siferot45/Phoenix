using Phoenix.Helpers.Commands.Base;
using System;

namespace Phoenix.Helpers.Commands
{
    internal class CommandHelper : CommandBase
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        public CommandHelper(Action<object> Execute, Func<object, bool> CanExecute = null)
        {
            _execute = Execute ?? throw new ArgumentNullException(nameof(Execute));
            _canExecute = CanExecute;
        }

        public override bool CanExecute(object? parameter) => _canExecute?.Invoke(parameter) ?? true;

        public override void Execute(object? parameter)
        {
            if(!CanExecute(parameter))
                return;

            _execute(parameter);
        }
    }
}
