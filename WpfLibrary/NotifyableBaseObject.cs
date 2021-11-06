using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfLibrary
{
    public class NotifyableBaseObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;   // event PropertyChanged

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (!string.IsNullOrEmpty(propertyName))
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
