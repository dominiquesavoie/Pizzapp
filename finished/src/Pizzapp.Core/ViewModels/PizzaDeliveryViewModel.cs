using Cirrious.MvvmCross.ViewModels;
using System;

namespace Pizzapp.Core
{
    public class PizzaDeliveryViewModel 
		: MvxViewModel
    {
        public PizzaDeliveryViewModel ()
        {
            AddressBar = new AddressBarViewModel (this);    
            Confirmation = new ConfirmationViewModel (this);    
            Status = new StatusViewModel (this);    
        }


        public AddressBarViewModel AddressBar { get; }
        public ConfirmationViewModel Confirmation { get; }
        public StatusViewModel Status { get; }

        private OrderStep _step;
        public OrderStep Step
        {
            get
            {
                return _step;
            }
            set
            {
                _step = value;
                RaisePropertyChanged ();
            }
        }

        public void NextStep()
        {
            if (Step == OrderStep.AwaitingDelivery)
            {
                throw new InvalidOperationException ();
            }
            if (Step == OrderStep.EnterDeliveryAddress)
            {
                Confirmation.Address = AddressBar.Address;
            }
            Step += 1;
        }

        public void PreviousStep()
        {
            if (Step == OrderStep.ConfirmDelivery)
            {
                Step -= 1;
            }
            else
            {
                throw new InvalidOperationException ();
            } 
        }

        public void InitialStep()
        {
            Step = OrderStep.EnterDeliveryAddress;
        }

        public void NotifyAddressChanged(string address)
        {
            AddressBar.Address = address;
        }
    }
}
