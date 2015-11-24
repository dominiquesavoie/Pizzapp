using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using Cirrious.MvvmCross.Binding.Touch.Views;
using Cirrious.MvvmCross.Binding.BindingContext;

namespace Pizzapp
{
	partial class PickerCell : MvxTableViewCell
	{
		public PickerCell (IntPtr handle) : base (handle)
		{
            this.DelayBind (() => {

                var set = this.CreateBindingSet<PickerCell, string>();

                set.Bind(lblValue).To(vm => vm);

                set.Apply();

            });
		}
	}
}
