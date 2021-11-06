using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF_Calculator
{
    /// <summary>
    /// Interaction logic for PersonList.xaml
    /// </summary>
    public partial class PersonList : Window
    {
        public PersonList()
        {
            InitializeComponent();
            ((PersonListViewModel)DataContext).MissingData += (sender, eventArgs) => ShowError();
        }
        public void ShowError()
        {
            MessageBox.Show("Please enter first name and last name");
        }
    }
}
