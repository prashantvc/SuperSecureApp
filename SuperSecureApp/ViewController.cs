using System;

using AppKit;
using Foundation;
using LocalAuthentication;

namespace SuperSecureApp
{
	public partial class ViewController : NSViewController
	{
		public ViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			UseTouchID();
		}

		void UseTouchID()
		{
			var contex = new LAContext();
			NSError authError;
			if (contex.CanEvaluatePolicy(LAPolicy.DeviceOwnerAuthenticationWithBiometrics, out authError))
			{
				replyHandler = new LAContextReplyHandler((success, error) =>
				{
					if (success)
					{
						InvokeOnMainThread(()=>ShowMessage());
					}
				});
			}

			contex.EvaluatePolicy(LAPolicy.DeviceOwnerAuthenticationWithBiometrics, "authenticate", replyHandler);
		}


		partial void SignUpClicked(NSObject sender)
		{
			string username = Username.StringValue;
			if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(Password.StringValue))
				return;

			KeychainHelpers.SetPasswordForUsername(username, Password.StringValue, SecureId,
												   Security.SecAccessible.Always, true);

			NSUserDefaults.StandardUserDefaults.SetString(username, "username");
			NSUserDefaults.StandardUserDefaults.Synchronize();

		}

		partial void LoginClicked(NSObject sender)
		{
			string username = NSUserDefaults.StandardUserDefaults.StringForKey("username");
			string password = KeychainHelpers.GetPasswordForUsername(Username.StringValue, SecureId, true);

			if (Username.StringValue == "guest")
			{
				ShowMessage();
			}
		}

		partial void TouchIDClicked(NSObject sender)
		{
			UseTouchID();
		}

		void ShowMessage(string message = "Here's your message Mr. Archer")
		{
			var alert = new NSAlert();
			alert.MessageText = "Secrete Message";
			alert.InformativeText = message;

			alert.AlertStyle = NSAlertStyle.Informational;

			alert.BeginSheet(this.View.Window);

		}


		public override NSObject RepresentedObject
		{
			get
			{
				return base.RepresentedObject;
			}
			set
			{
				base.RepresentedObject = value;
				// Update the view, if already loaded.
			}
		}

		const string SecureId = "SuperSecureApp";
		LAContextReplyHandler replyHandler;
	}
}
