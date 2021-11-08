using MvvmCross.ViewModels;
using MvxStarter.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MvxStarter.Core
{
    public class App : MvxApplication
    {
        public App() : base()
        {
        }

        public override void Initialize()
        {
            // base.Initialize();
            RegisterAppStart<GuestBookViewModel>();
        }
    }
}
