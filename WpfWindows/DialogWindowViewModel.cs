using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfLibrary;

namespace WpfWindows
{
   public class DialogWindowViewModel : NotifyableBaseObject
    {
        public event EventHandler Ok;
        public event EventHandler Cancel;


        public DialogWindowViewModel()
        {
            this.OkCommand = new DelegateCommand((o) => this.Ok?.Invoke(this, EventArgs.Empty));
            this.CancelCommand = new DelegateCommand((o) => this.Cancel?.Invoke(this, EventArgs.Empty));
        }

        private string name;

        public string Name
        {
            get { return name; }
            set {
                if (name != value)
                {
                    name = value;
                    this.RaisePropertyChanged();
                }
            }
        }
        private string email;

      

        public string Email
        {
            get { return email; }
            set
            {
                if (email != value)
                {
                    email = value;
                    this.RaisePropertyChanged();
                }
            }
        }

        //public ICommand OkCommand { get; init; }
        public ICommand OkCommand { get; set; }
        //public ICommand CancelCommand { get; init; }
        public ICommand CancelCommand { get; set; }


    }
}
