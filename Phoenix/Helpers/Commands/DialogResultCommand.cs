﻿using System;
using System.Windows.Input;

namespace Phoenix.Helpers.Commands
{
    class DialogResultCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool? DialogResult { get; set; }

        public bool CanExecute(object? parameter) => App.CurrentWindow != null;

        public void Execute(object? parameter)
        {
            var window = App.CurrentWindow;

            var dialogResult = DialogResult;

            if (parameter != null)
                dialogResult = Convert.ToBoolean(parameter);

            window.DialogResult = dialogResult;
            window.Close();
        }
    }
}
