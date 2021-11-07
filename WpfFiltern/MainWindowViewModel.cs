using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfLibrary;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace WpfFiltern
{
    public class MainWindowViewModel : NotifyableBaseObject
    {
        //System.Collections.ObjectModel.
        ObservableCollection<Person> _listData = new ObservableCollection<Person>();
        public ObservableCollection<Person> FilteredList { get; set; } = new ObservableCollection<Person>();

        string _filter = "";

        public MainWindowViewModel()
        {
            this._listData.CollectionChanged += (s, e) =>
            {
                DoFiltering();
            };

            this._listData.Add(new Person { FirstName = "Max", LastName = "Muster", Job = "Developer" });
            this._listData.Add(new Person { FirstName = "Susi", LastName = "Müller", Job = "Sales" });
            this._listData.Add(new Person { FirstName = "Dev", LastName = "Dave", Job = "Entwickler" });

            this.AddNewPersonCommand = new DelegateCommand((o) =>
            {
                this._listData.Add(new Person { FirstName = "Herbert", LastName = "Bossinger", Job = "Boss" });
            });
        }

        public string Filter
        {
            get { return _filter; }
            set
            {
                if (_filter != value)
                {
                    _filter = value;
                    this.RaisePropertyChanged();
                    DoFiltering();
                }
            }
        }

        private void DoFiltering()
        {
            this.FilteredList.Clear();
            //string? value = this._filter?.ToLower();
            string value = this._filter?.ToLower() ?? "";

            foreach (var item in _listData)
            {
                if (String.IsNullOrEmpty(value) ||
                    item.FullName.ToLower().Contains(value) ||
                     item.Job.ToLower().Contains(value))
                {
                    this.FilteredList.Add(item);
                }
            }
            Console.WriteLine("filtering done.");
        }

        public ICommand AddNewPersonCommand { get; set; }
    }
}

