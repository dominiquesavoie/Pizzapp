using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Touch.Views;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using CoreLocation;
using MapKit;
using System;
using System.Linq;
using AddressBookUI;
using Pizzapp.Core;

namespace Pizzapp
{
	[Register("HomeView")]
    public class HomeView : MvxViewController<HomeViewModel>
    {
        public HomeView(IntPtr handle)
            :base(handle)
        {
            new LoggingViewControllerAdapter (this);    
        }

        public HomeView ()
        {
            new LoggingViewControllerAdapter (this);    
        }

        MKMapView _mapView;
        UIViewController _currentPresentedStep;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Title = "Pizza delivery";

            _mapView = new MapKit.MKMapView (View.Bounds);
            View.Add (_mapView);
            new GeocoderViewControllerAdapter (this, _mapView, ViewModel.NotifyAddressChanged);

            var  addressBar = new AddressBarView ();
            AddChildViewController (addressBar);
            View.Add (addressBar.View);
            addressBar.DidMoveToParentViewController (this);
            _currentPresentedStep = addressBar;

			var set = this.CreateBindingSet<HomeView, Core.HomeViewModel>();
            set.Bind (addressBar).For (v => v.DataContext).To (vm => vm.AddressBar);
            set.Bind ().For (v => v.Step).To (vm => vm.Step);
            set.Apply();
        }

        public override void ViewDidLayoutSubviews ()
        {
            base.ViewDidLayoutSubviews ();
            _currentPresentedStep.View.Frame = new CGRect (0, TopLayoutGuide.Length, View.Bounds.Width, _currentPresentedStep.View.Bounds.Height);

        }


        private OrderStep _step;
        public OrderStep Step
        {
            get
            {
                return _step;
            }
            set
            {
                var oldStep = _step;
                _step = value;
                HandleStepChanged (oldStep, value);
            }

        }

        private async void HandleStepChanged(OrderStep oldStep, OrderStep newStep)
        {
            if (oldStep == newStep)
            {
                return;
            }

            var fromController = _currentPresentedStep;
            var toController = default(UIViewController);

        }


    }
}