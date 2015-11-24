using System;
using Cirrious.MvvmCross.ViewModels;
using System.Collections.Generic;

namespace Pizzapp.Core
{
    public class PickerViewModel: MvxViewModel
    {
        
        public PickerViewModel (IList<string> values, Action<string> selectionChanged)
        {
            Values = values;
            SelectValue = new MvxCommand<string>(selectionChanged);
        }

        public IList<string> Values { get; }

        public IMvxCommand SelectValue { get; }

        public string SelectedValue { get; set; }
    }
}

