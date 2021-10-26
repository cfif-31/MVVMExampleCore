using MVVMExampleCore.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMExampleCore.ViewModel
{
    class ViewModel : ObserverObject
    {

        private int _ClickCoint;
        public int ClickCount
        {
            get { return _ClickCoint; }
            set {
                _ClickCoint = value;
                OnPropertyChanged();
            }
        }

        private bool IsClick(object parameter)
        {
            return ClickCount < 10;
        }

        private void ClickEvent(object parameter)
        {
            ClickCount++;
        }

        public RelayCommand ClickCommand => new RelayCommand(ClickEvent, IsClick);
    }
}
