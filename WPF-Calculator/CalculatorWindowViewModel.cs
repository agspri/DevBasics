using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Calculator
{
    public class CalculatorWindowViewModel : NotifyableBaseObject
    {
        public CalculatorWindowViewModel()
        {
            this.NumberCommand = new DelegateCommad((value) =>
              {
                  int val = int.Parse((string)value);
                  this.CurrentValue = this.CurrentValue * 10.0 + val;
              });

            this.OperatorCommand = new DelegateCommad(ExecuteOperation);
            // this.ExecuteCommand = new DelegateCommad(ExecuteOperation);    Mögliche Verbesserung:
            // this.OperatorCommand = new DelegateCommad(Operation);            Aufteilung in 2 Commands.
        }

        void ExecuteOperation(object o)
        {
            string op = (string)o;

            if (op == "=")
            {
                switch (operatorToExecute)
                {
                    case "+":
                        CurrentValue += lastValue;
                        break;
                    case "-":
                        CurrentValue = lastValue - currValue;
                        break;
                    case "*":
                        CurrentValue *= lastValue;
                        break;
                    case "/":
                        CurrentValue = lastValue / currValue;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                this.operatorToExecute = op;
                lastValue = currValue;
                CurrentValue = 0.0D;
            }
        }

        double currValue;

        public double CurrentValue
        {
            get => currValue;
            set
            {
                if (currValue != value)
                {
                    this.currValue = value;
                    this.RaisePropertyChanged();
                }
            }
        }

        double lastValue;

        string operatorToExecute;

        public DelegateCommad NumberCommand { get; set; }
        public DelegateCommad OperatorCommand { get; set; }

    }
}
