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
        public event EventHandler MissingData;

        public PersonListViewModel()
        {
            this.AddPersonCommand = new DelegateCommad((o) =>
            {
                // will be called on button click
                if (String.IsNullOrEmpty(NewPerson.FirstName) || String.IsNullOrEmpty(NewPerson.LastName))
                {
                    MissingData?.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    this.Persons.Add(NewPerson);
                    NewPerson = new Person();
                }
            });

            AddSeveralPersons();
        }


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

        private void AddSeveralPersons()
        {
            this.Persons.Add(new Person()
            {
                FirstName = "Susi",
                LastName = "Müller",
                Department = "Back Office"
            });

            this.Persons.Add(new Person()
            {
                FirstName = "Dave",
                LastName = "Dev",
                Department = "Software Development"
            });

            this.Persons.Add(new Person()
            {
                FirstName = "Hugo",
                LastName = "Bossinger",
                Department = "Managment"
            });

        }
    }
}
