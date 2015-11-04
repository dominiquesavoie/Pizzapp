
using System;

using Foundation;
using UIKit;
using Cirrious.MvvmCross.Touch.Views;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.Binding.BindingContext;
using Pizzapp.Core;

namespace Pizzapp
{
    public partial class ConfirmationView : MvxViewController
    {
        public ConfirmationView (IntPtr handle)
        {
            Request = MvxViewModelRequest<MvxNullViewModel>.GetDefaultRequest();
            new LoggingViewControllerAdapter(this);
        }

        public ConfirmationView () : base ("ConfirmationView", null)
        {
            Request = MvxViewModelRequest<MvxNullViewModel>.GetDefaultRequest();
            new LoggingViewControllerAdapter(this);
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
            
            var set = this.CreateBindingSet<ConfirmationView, ConfirmationViewModel> ();

            set.Bind (lblAddress).To (vm => vm.Address);
            set.Bind (btnCancel).To (vm => vm.Cancel);
            set.Bind(btnConfirm).To(vm => vm.Confirm);

            set.Apply ();
        }
    }
}

