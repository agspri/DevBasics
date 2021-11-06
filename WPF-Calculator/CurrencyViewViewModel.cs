using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Calculator
{
    class CurrencyViewViewModel : BaseViewModel
    {
        private decimal _value;

        public CurrencyViewViewModel()
        {
            this.Value = 123;
        }

        public decimal Value
        {
            get { return _value; }
            set {
                if (_value != value)
                {
                    _value = value;
                    this.RaisePropertyChanged();
                    this.RaisePropertyChanged(nameof(HasNonZeroValue));
                }
            }
        }

        public bool HasNonZeroValue => Value != 0.0m;
    }
}
