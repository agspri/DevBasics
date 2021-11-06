using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Calculator
{
    public class Person : NotifyableBaseObject
    {
        private string _firstName;

        public string FirstName
        {
            get { return _firstName; }
            set {
                if (_firstName != value)
                {
                    _firstName = value;
                    this.RaisePropertyChanged();
                    this.RaisePropertyChanged(nameof(Fullname));
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
                    this.RaisePropertyChanged();
                    this.RaisePropertyChanged(nameof(Fullname));
                }
            }
        }
        public string Fullname => $"{FirstName} {LastName}";

        private string _department;

        public string Department
        {
            get { return _department; }
            set
            {
                if (_department != value)
                {
                    _department = value;
                    this.RaisePropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
