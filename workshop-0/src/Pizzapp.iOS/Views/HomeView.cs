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
using Cirrious.MvvmCross.ViewModels;

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

            // Create address bar view and add it as a child view controller
            var addressBar = new AddressBarView();
            AddChildViewController(addressBar);
            View.Add(addressBar.View);
            addressBar.DidMoveToParentViewController(this);
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

        private MvxViewController SelectStep(OrderStep newStep)
        {
            switch (newStep)
            {
                case OrderStep.ConfirmDelivery:
                    return new ConfirmationView();
                case OrderStep.EnterDeliveryAddress:
                    return new AddressBarView();
                case OrderStep.AwaitingDelivery:
                    return new StatusView();
                default: 
                    return null;
                  
            }
        }

        private async void HandleStepChanged(OrderStep oldStep, OrderStep newStep)
        {
            if (oldStep == newStep)
            {
                return;
            }

            var fromController = _currentPresentedStep;
            var toController = SelectStep(newStep);

            // Construct the new controller
         
            // Set its DataContext
            var set = this.CreateBindingSet<HomeView, Core.HomeViewModel>();
            if (newStep == OrderStep.AwaitingDelivery)
            {
                set.Bind(toController)
                    .For(v => v.DataContext)
                    .To(vm => vm.Status); 
            }
            else if(newStep == OrderStep.ConfirmDelivery)
            {
                set.Bind(toController)
                    .For(v => v.DataContext)
                    .To(vm => vm.Confirmation); 
            }
            else if(newStep == OrderStep.EnterDeliveryAddress)
            {
                set.Bind(toController)
                    .For(v => v.DataContext)
                    .To(vm => vm.AddressBar); 
            }
            set.Apply();
            
            // Add the controller as a child view Controller
            AddChildViewController(toController);

            // Setup the controller's view frame
            toController.View.Frame = new CGRect (0, TopLayoutGuide.Length, View.Bounds.Width, toController.View.Bounds.Height);

            // Transition between the two controllers using TransitionAsync
            // You need to call fromController.WillMoveToParentViewController(null)
            // toController.DidMoveToParentViewController(this) and fromController.RemoveFromParentViewController()
            fromController.WillMoveToParentViewController(null);
            await this.TransitionAsync(fromController, 
                toController, 
                .6, 
                UIViewAnimationOptions.TransitionCrossDissolve,
                () => { });

            toController.DidMoveToParentViewController(this);
            fromController.RemoveFromParentViewController();
            fromController.Dispose();

            // Update the _currentPresentedStep variable
            _currentPresentedStep = toController;
        }


    }
}