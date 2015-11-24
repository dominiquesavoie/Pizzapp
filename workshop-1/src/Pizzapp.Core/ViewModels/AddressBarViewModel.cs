using System;
using Cirrious.MvvmCross.ViewModels;

namespace Pizzapp.Core
{
    public class AddressBarViewModel: MvxViewModel
    {
        readonly PizzaDeliveryViewModel _parent;

        public AddressBarViewModel (PizzaDeliveryViewModel parent)
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

        public IMvxCommand Go
        {
            get
            {
                return new MvxCommand (() => {

                    _parent.NextStep();

                });
            }
        }

    }
}

