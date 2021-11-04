using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WPF_DataBinding
{
    /// <summary>
    /// ViewModel
    /// Das ViewModel kennt die View nicht.
    /// 
    /// </summary>
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public MainWindowViewModel()
        {
            this.ClearCommad = new DelegateCommad(
              (o) => !string.IsNullOrEmpty(_firstName) || !string.IsNullOrEmpty(_lastName),   // Predicate
              (o) => { this.FirstName = ""; this.LastName = ""; }                             // Action
            );
            FirstName = "firstName";
            LastName = "lastName";
        }

        public DelegateCommad ClearCommad { get; set; }

        private string _firstName;

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    //this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FirstName)));
                    //this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FullName)));
                    this.RaisePropertyChanged();
                    this.RaisePropertyChanged(nameof(FullName));
                    this.ClearCommad.RaiseCanExecuteChanged();
                }
            }
        }

        private string _lastName;

        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (_lastName != value)
                {
                    _lastName = value;
                }
                this.RaisePropertyChanged();
                this.RaisePropertyChanged(nameof(FullName));
                this.ClearCommad.RaiseCanExecuteChanged();
            }
        }

        // public string FirstName { get; set; }
        // public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public event PropertyChangedEventHandler PropertyChanged;   // event PropertyChanged

        private void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (!string.IsNullOrEmpty(propertyName))
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
