using System;
using Cirrious.MvvmCross.ViewModels;

namespace Pizzapp.Core
{
    public class ConfirmationViewModel: MvxViewModel
    {
        readonly PizzaDeliveryViewModel _parent;

        public ConfirmationViewModel (PizzaDeliveryViewModel parent)
        {
            _parent = parent;
        }

        private string _address;
        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value;
                RaisePropertyChanged ();
            }
        }

        public IMvxCommand Confirm
        {
            get
            {
                return new MvxCommand (() => {

                    _parent.NextStep();

                });
            }
        }

        public IMvxCommand Cancel
        {
            get
            {
                return new MvxCommand (() => {

                    _parent.PreviousStep();

                });
            }
        }
    }
}

