// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace SuperSecureApp
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		AppKit.NSButton Login { get; set; }

		[Outlet]
		AppKit.NSSecureTextField Password { get; set; }

		[Outlet]
		AppKit.NSButton SignUpButton { get; set; }

		[Outlet]
		AppKit.NSButton TouchIDButton { get; set; }

		[Outlet]
		AppKit.NSTextField Username { get; set; }

		[Action ("LoginClicked:")]
		partial void LoginClicked (Foundation.NSObject sender);

		[Action ("SignUpClicked:")]
		partial void SignUpClicked (Foundation.NSObject sender);

		[Action ("TouchIDClicked:")]
		partial void TouchIDClicked (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (Password != null) {
				Password.Dispose ();
				Password = null;
			}

			if (Username != null) {
				Username.Dispose ();
				Username = null;
			}

			if (TouchIDButton != null) {
				TouchIDButton.Dispose ();
				TouchIDButton = null;
			}

			if (SignUpButton != null) {
				SignUpButton.Dispose ();
				SignUpButton = null;
			}

			if (Login != null) {
				Login.Dispose ();
				Login = null;
			}
		}
	}
}
