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
            //_execute = Execute ?? throw new ArgumentNullException(nameof(Execute));
            //_canExecute = CanExecute;
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
        //public CommandHelperT(Action<T> ExecuteAction, Func<T, bool>? CanExecute = null)
        //{
        //    _execute = ExecuteAction ?? throw new ArgumentNullException("ExecuteAction");
        //    _canExecute = (Func<T, bool>?)(MulticastDelegate)CanExecute;
        //}

        //public override bool CanExecute(object? parameter)
        //{
        //    Func<T, bool> canExecute = _canExecute;
        //    if (canExecute == null)
        //        return true;

        //    if (parameter != null)
        //    {
        //        if (parameter is T)
        //        {
        //            T arg = (T)parameter;
        //        }

        //        parameter = ConvertParameter(parameter);
        //        return canExecute((T)parameter);
        //    }
        //    return true;
        //}

        //public override void Execute(object? parameter)
        //{
        //    Action<T> action = _execute ?? throw new InvalidOperationException("Метод выполнения команды не определён");
        //    T val = ((!(parameter is T)) ? ((parameter == null) ? default(T) : ConvertParameter(parameter)) : ((T)parameter));


        //    if (!CanExecute(parameter))
        //        return;

        //    Func<T, bool>? canExecute = _canExecute;
        //    if (canExecute == null || canExecute!(val))
        //    {
        //        action(val);
        //    }
        //}
        //public static T ConvertParameter(object? parameter)
        //{
        //    if (parameter == null)
        //    {
        //        return default(T);
        //    }

        //    if (parameter is T)
        //    {
        //        return (T)parameter;
        //    }

        //    Type typeFromHandle = typeof(T);
        //    Type type = parameter!.GetType();
        //    if (typeFromHandle.IsAssignableFrom(type))
        //    {
        //        return (T)parameter;
        //    }

        //    TypeConverter converter = TypeDescriptor.GetConverter(typeFromHandle);
        //    if (converter.CanConvertFrom(type))
        //    {
        //        return (T)converter.ConvertFrom(parameter);
        //    }

        //    TypeConverter converter2 = TypeDescriptor.GetConverter(type);
        //    if (converter2.CanConvertTo(typeFromHandle))
        //    {
        //        return (T)converter2.ConvertFrom(parameter);
        //    }
        //    return default(T);
        //}
    }
}
