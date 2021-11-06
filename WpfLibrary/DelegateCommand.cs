using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace WpfLibrary
{
   public class DelegateCommand : ICommand
    {
        readonly Action<object> execute;         // Das object ist ein Command Parameter

        readonly Predicate<object> canExecute;

        public DelegateCommand(Predicate<object> canExecute, Action<object> execute)
          => (this.canExecute, this.execute) = (canExecute, execute);

        public DelegateCommand(Action<object> execute) : this(null, execute) { }

        public event EventHandler CanExecuteChanged;

        public void RaiseCanExecuteChanged() => this.CanExecuteChanged?.Invoke(this, EventArgs.Empty);


        /// <summary>
        /// prüft, ob das Command ausgeführt werden kann.
        /// Z.B.: Ist der Button aktiv/klickbar?
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter) => this.canExecute?.Invoke(parameter) ?? true;  // liefert true, wenn kein Filter


        /// <summary>
        /// führt den dahinterliegenden Code aus. Z.B. der Code, der bei einem Button-Click ausgeführt werden soll.
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter) => this.execute?.Invoke(parameter);

        //
        // Noch dazu:
        //
     

      

      
    }
}
