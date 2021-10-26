﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMExampleCore.Core
{
    class RelayCommand : ICommand
    {
        private readonly Func<object, bool> _canExecute;
        private readonly Action<object> _execute;
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this._canExecute = canExecute;
            this._execute = execute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return this._canExecute == null || this._canExecute(parameter); ;
        }

        public void Execute(object parameter)
        {
            this._execute(parameter);
        }
    }
}
