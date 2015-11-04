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
		UIBarButtonItem btnOk { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableViewCell cellCheese { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblCheese { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblCrust { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblRecipe { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblSize { get; set; }

		[Action ("btnOk_Activated:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void btnOk_Activated (UIBarButtonItem sender);

		void ReleaseDesignerOutlets ()
		{
			if (btnOk != null) {
				btnOk.Dispose ();
				btnOk = null;
			}
			if (cellCheese != null) {
				cellCheese.Dispose ();
				cellCheese = null;
			}
			if (lblCheese != null) {
				lblCheese.Dispose ();
				lblCheese = null;
			}
			if (lblCrust != null) {
				lblCrust.Dispose ();
				lblCrust = null;
			}
			if (lblRecipe != null) {
				lblRecipe.Dispose ();
				lblRecipe = null;
			}
			if (lblSize != null) {
				lblSize.Dispose ();
				lblSize = null;
			}
		}
	}
}
