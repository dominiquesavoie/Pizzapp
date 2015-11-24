
using System;

using Foundation;
using UIKit;
using Cirrious.MvvmCross.Touch.Views;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.Binding.BindingContext;
using Pizzapp.Core;

namespace Pizzapp
{
    public partial class AddressBarView : MvxViewController
    {
        public AddressBarView (IntPtr handle)
            :base(handle)
        {
            Request = MvxViewModelRequest<MvxNullViewModel>.GetDefaultRequest();
            new LoggingViewControllerAdapter (this);
        }

        public AddressBarView () : base ("AddressBarView", null)
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
            
            var set = this.CreateBindingSet<AddressBarView, AddressBarViewModel> ();

            set.Bind (txtAddress).To (vm => vm.Address);
            set.Bind(btnGo).To(vm => vm.Go);

            set.Apply ();
        }


    }
}

