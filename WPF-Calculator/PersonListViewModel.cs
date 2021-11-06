using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Calculator
{
    public class PersonListViewModel : NotifyableBaseObject
    {
        private ObservableCollection<Person> _persons = new ObservableCollection<Person>();

        public ObservableCollection<Person> Persons {
            get => _persons;
            set  { 
                if (_persons != value)
                {
                    _persons = value;
                    this.RaisePropertyChanged();
                }
            }
        }

        Person _newPerson = new Person();

        public PersonListViewModel()
        {
            this.AddPersonCommand = new DelegateCommad((o) =>
            {
                // will be called on button click
                this.Persons.Add(NewPerson);
                NewPerson = new Person();
            });
        }

        public Person NewPerson
        {
            get => _newPerson;
            set
            {
                if (_newPerson != value)
                {
                    _newPerson = value;
                    this.RaisePropertyChanged();
                }
            }
        }

        public DelegateCommad AddPersonCommand { get; set; }

    }
}
