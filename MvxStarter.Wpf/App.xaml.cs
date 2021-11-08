using MvvmCross.Core;
using MvvmCross.Platforms.Wpf.Core;
using MvvmCross.Platforms.Wpf.Views;
using MvvmCross;

//base.RegisterSetup();
//this.RegisterSetupType<MvxWpfSetup<MvxStarter.Core.App>>();

namespace MvxStarter.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : MvxApplication
    {
        protected override void RegisterSetup()
        {
            //this.RegisterSetupType<MvxWpfSetup<MvxStarter.Core.App>>();
            this.RegisterSetupType<MvxWpfSetup<Core.App>>();
        }     
    }
}
