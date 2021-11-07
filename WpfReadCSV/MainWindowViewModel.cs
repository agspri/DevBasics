using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfLibrary;

namespace WpfReadCSV
{
    public class MainWindowViewModel : NotifyableBaseObject
    {
        public MainWindowViewModel()
        {
            this.LoadCsv = new DelegateCommand((o) => ExecLoadCsv());
            this.Communities = new ObservableCollection<Community>();
        }

        public ObservableCollection<Community> Communities { get; set; }

        private async void ExecLoadCsv()
        {
            this.IsLoading = true;

            using (var service = new CsvService("ortsliste.csv"))
            {
                //IAsyncEnumerable<Community> 
                var result = service.ReadCSV();

                await foreach (var item in result)
                {
                    this.Communities.Add(item);
                }
            }
            this.IsLoading = false;
        }

        private bool _isLoading;

        public bool IsLoading
        {
            get { return _isLoading; }
            set {
                if (_isLoading !=  value)
                {
                    _isLoading = value;
                    this.RaisePropertyChanged();
                }               
            }
        }


        public DelegateCommand LoadCsv { get; set; }
    }
}
