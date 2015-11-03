// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace Pizzapp
{
	[Register ("ConfirmationView")]
	partial class ConfirmationView
	{
		[Outlet]
		UIKit.UIButton btnCancel { get; set; }

		[Outlet]
		UIKit.UIButton btnConfirm { get; set; }

		[Outlet]
		UIKit.UILabel lblAddress { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (lblAddress != null) {
				lblAddress.Dispose ();
				lblAddress = null;
			}

			if (btnConfirm != null) {
				btnConfirm.Dispose ();
				btnConfirm = null;
			}

			if (btnCancel != null) {
				btnCancel.Dispose ();
				btnCancel = null;
			}
		}
	}
}
