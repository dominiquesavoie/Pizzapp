using System;
using Cirrious.MvvmCross.ViewModels;
using Pizzapp.Core.ViewModels;

namespace Pizzapp.Core
{
    public class AddressBarViewModel: MvxViewModel
    {
        readonly HomeViewModel _parent;

        public AddressBarViewModel (HomeViewModel parent)
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

