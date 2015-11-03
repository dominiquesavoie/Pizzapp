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
	[Register ("AddressBarView")]
	partial class AddressBarView
	{
		[Outlet]
		UIKit.UIButton btnGo { get; set; }

		[Outlet]
		UIKit.UITextField txtAddress { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (txtAddress != null) {
				txtAddress.Dispose ();
				txtAddress = null;
			}

			if (btnGo != null) {
				btnGo.Dispose ();
				btnGo = null;
			}
		}
	}
}
