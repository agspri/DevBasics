using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF_Calculator
{
    /// <summary>
    /// DelegateCommad:
    /// Nimmt die Benutzeraktionen entgegen und führt einen Code aus.
    /// Es arbeitet mit Delegates.
    /// Wird oft auch mit 'RelayCommand' benannt.
    /// Dieses Command ist in vielen Libraries.
    /// </summary>
    public class DelegateCommad : ICommand
    {
        public event EventHandler CanExecuteChanged;

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
        readonly Action<object> execute;         // Das object ist ein Command Parameter
        readonly Predicate<object> canExecute;

        public DelegateCommad(Predicate<object> canExecute, Action<object> execute)
            => (this.canExecute, this.execute) = (canExecute, execute);

        public DelegateCommad(Action<object> execute) : this(null, execute) { }

        public void RaiseCanExecuteChanged() => this.CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}
