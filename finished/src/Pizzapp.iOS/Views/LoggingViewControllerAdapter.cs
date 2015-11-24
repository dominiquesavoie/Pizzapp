using System;
using Cirrious.MvvmCross.Touch.Views;
using Cirrious.CrossCore.Touch.Views;

namespace Pizzapp
{
    public class LoggingViewControllerAdapter: MvxBaseViewControllerAdapter
    {
        public LoggingViewControllerAdapter (IMvxEventSourceViewController viewController)
            :base(viewController)
        {
            
        }

        public override void HandleViewDidLoadCalled (object sender, EventArgs e)
        {
            Console.WriteLine (this.ViewController.GetType().Name + ": ViewDidLoad");
        }

        public override void HandleViewWillAppearCalled (object sender, Cirrious.CrossCore.Core.MvxValueEventArgs<bool> e)
        {
            Console.WriteLine (this.ViewController.GetType().Name + ": ViewWillAppear");
        }  

        public override void HandleViewDidAppearCalled (object sender, Cirrious.CrossCore.Core.MvxValueEventArgs<bool> e)
        {
            Console.WriteLine (this.ViewController.GetType().Name + ": ViewDidAppear");
        }

        public override void HandleViewWillDisappearCalled (object sender, Cirrious.CrossCore.Core.MvxValueEventArgs<bool> e)
        {
            Console.WriteLine (this.ViewController.GetType().Name + ": ViewWillDisappear");
        }

        public override void HandleViewDidDisappearCalled (object sender, Cirrious.CrossCore.Core.MvxValueEventArgs<bool> e)
        {
            Console.WriteLine (this.ViewController.GetType().Name + ": ViewDidDisappear");
        }

        public override void HandleDisposeCalled (object sender, EventArgs e)
        {
            Console.WriteLine (this.ViewController.GetType().Name + ": Dispose");
        }
    }
}

