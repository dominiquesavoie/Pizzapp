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
	[Register ("PizzaBuilderView")]
	partial class PizzaBuilderView
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblCrust { get; set; }

		[Action ("btnOk_Activated:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void btnOk_Activated (UIBarButtonItem sender);

		void ReleaseDesignerOutlets ()
		{
			if (lblCrust != null) {
				lblCrust.Dispose ();
				lblCrust = null;
			}
		}
	}
}
