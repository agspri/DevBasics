using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfLibrary;

namespace WpfWindows
{
    class MainWindowViewModel : NotifyableBaseObject
    {
       // V1: public event EventHandler OpenDialog;

        // V2:
        public delegate (string name, string email) OpenDialogHandler(string name, string email);
        public OpenDialogHandler OpenDialog { get; set; }

        public MainWindowViewModel()
        {
            this.OpenDialogCommand = new DelegateCommand((o) =>
            {
                // V1:
                ////if (this.OpenDialog != null)
                ////    this.OpenDialog(this, EventArgs.Empty);
                //// kürzer:
                //this.OpenDialog?.Invoke(this, EventArgs.Empty);

                // V2:
                //(string name, string email) = OpenDialog(this.Name, this.Email);
                // kürzer:
                (Name, Email) = OpenDialog(this.Name, this.Email);


            });
        }

        //public ICommand OpenDialog { get; init; }
        public ICommand OpenDialogCommand { get; set; }

        private string _name;      

        public string Name
        {
            get { return _name; }
            set {
                if (_name != value) {
                    _name = value;
                    this.RaisePropertyChanged();
                }
            }
        }

        private string _email;

        public string Email
        {
            get { return _email; }
            set { 
                if (_email != value)
                {
                    _email = value;
                    this.RaisePropertyChanged();
                }
               
            }
        }

    }
}
