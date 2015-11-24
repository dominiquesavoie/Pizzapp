
using System;

using Foundation;
using UIKit;
using Cirrious.MvvmCross.Touch.Views;
using Cirrious.MvvmCross.Binding.BindingContext;
using Pizzapp.Core;
using Cirrious.MvvmCross.ViewModels;

namespace Pizzapp
{
    public partial class StatusView : MvxViewController<StatusViewModel>
    {
        public StatusView () : base ("StatusView", null)
        {
            Request = MvxViewModelRequest<MvxNullViewModel>.GetDefaultRequest();
            new LoggingViewControllerAdapter (this);
        }

        public override void DidReceiveMemoryWarning ()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning ();

            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();
            
            var set = this.CreateBindingSet<StatusView, StatusViewModel> ();

            set.Bind (progressBar).To (vm => vm.Progress);

            set.Apply ();
        }

        public override void ViewDidAppear (bool animated)
        {
            ViewModel.StartProgress ();
        }
    }
}

