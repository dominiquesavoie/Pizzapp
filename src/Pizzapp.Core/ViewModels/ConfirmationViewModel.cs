using System;
using Cirrious.MvvmCross.ViewModels;
using Pizzapp.Core.ViewModels;

namespace Pizzapp.Core
{
    public class ConfirmationViewModel: MvxViewModel
    {
        readonly HomeViewModel _parent;

        public ConfirmationViewModel (HomeViewModel parent)
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

