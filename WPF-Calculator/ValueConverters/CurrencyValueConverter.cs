using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WPF_Calculator.ValueConverters
{
    public class CurrencyValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            decimal val = (decimal)value;
            //return val.ToString("0.00€");
            return val.ToString("0.00") + (string)parameter;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string val = (string)value;
            //val = val.Replace("€", "").Trim();    // keine gute Implementierung
            val = val.Replace((string)parameter, "").Trim();    // keine gute Implementierung
            decimal res = decimal.Parse(val);
            return res;
        }
    }
}
