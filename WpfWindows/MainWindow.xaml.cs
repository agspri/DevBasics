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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfWindows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var vm = (MainWindowViewModel)DataContext;

            // V2:  Lösung mit einem Delegate
            vm.OpenDialog = (name, email) =>
            {
                DialogWindow dialog = new DialogWindow();
                if (dialog.ShowDialog() == true)
                {
                    var dialogViewModel = ((DialogWindowViewModel)dialog.DataContext);
                    return (dialogViewModel.Name, dialogViewModel.Email);
                } else
                {
                    return (string.Empty, string.Empty);
                }
            };

            // V2:  Wird für V2 nicht gebraucht:
            //vm.OpenDialog += (s, ev) =>
            //{
            //    DialogWindow dialog = new DialogWindow();

            //    bool retVal = dialog.ShowDialog() ?? false;

            //    if (retVal == true)
            //    {
            //        var dialogViewModel = ((DialogWindowViewModel)dialog.DataContext);
            //        vm.Email = dialogViewModel.Email;
            //        vm.Name = dialogViewModel.Name;
            //    }
            //};
        }
    }
}
