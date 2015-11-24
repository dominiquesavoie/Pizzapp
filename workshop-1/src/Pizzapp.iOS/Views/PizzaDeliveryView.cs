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
	[Register("PizzaDeliveryView")]
    public class PizzaDeliveryView : MvxViewController<PizzaDeliveryViewModel>
    {
        public PizzaDeliveryView(IntPtr handle)
            :base(handle)
        {
            new LoggingViewControllerAdapter (this);    
        }

        public PizzaDeliveryView ()
        {
            new LoggingViewControllerAdapter (this);    
        }

        MKMapView _mapView;
        UIViewController _currentPresentedStep;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            _mapView = new MapKit.MKMapView (View.Bounds);
            View.Add (_mapView);
            new GeocoderViewControllerAdapter (this, _mapView, ViewModel.NotifyAddressChanged);

            var  addressBar = new AddressBarView ();
            AddChildViewController (addressBar);
            View.Add (addressBar.View);
            addressBar.DidMoveToParentViewController (this);
            _currentPresentedStep = addressBar;

            var set = this.CreateBindingSet<PizzaDeliveryView, Core.PizzaDeliveryViewModel>();
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

            if (newStep == OrderStep.EnterDeliveryAddress)
            {
                toController = new AddressBarView
                {
                    ViewModel = this.ViewModel.AddressBar,
                };
            }
            else if (newStep == OrderStep.ConfirmDelivery)
            {
                toController = new ConfirmationView()
                {
                    ViewModel = this.ViewModel.Confirmation,
                };

            }
            else if (newStep == OrderStep.AwaitingDelivery)
            {
                toController = new StatusView()
                {
                    ViewModel = this.ViewModel.Status,
                };
            }
            else
            {
                throw new InvalidOperationException ();
            }   

            fromController.WillMoveToParentViewController (null);
            toController.View.Frame = new CGRect (0, TopLayoutGuide.Length, View.Bounds.Width, toController.View.Bounds.Height);
            AddChildViewController (toController);

            await this.TransitionAsync (fromController, toController, .6, UIViewAnimationOptions.TransitionCrossDissolve, () => {
                fromController.RemoveFromParentViewController();
                fromController.Dispose();
                toController.DidMoveToParentViewController(this);
            });

            _currentPresentedStep = toController;
        }


    }
}