// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Pizzapp
{
	[Register ("PickerView")]
	partial class PickerView
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIBarButtonItem btnDone { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (btnDone != null) {
				btnDone.Dispose ();
				btnDone = null;
			}
		}
	}
}
