using System;
using System.Windows.Input;
//using Android.Content;
using MobileApp.Helpers;

namespace MobileApp.ViewModels
{
	public class AboutViewModel : BaseViewModel
	{
        public BaseCommand EmailCommand { get; set; }

        public AboutViewModel()
		{
			Title = "About";

            EmailCommand = new BaseCommand(SendEmail);

            //OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://xamarin.com/platform")));
		}

        private void SendEmail()
        {
            //// https://blog.xamarin.com/cross-platform-messaging-for-ios-android-and-windows/
            //var emailTask = MessagingPlugin.EmailMessenger;
            //if (emailTask.CanSendEmail)
            //{
            //    // Send simple e-mail to single receiver without attachments, CC, or BCC.
            //    emailTask.SendEmail("plugins@xamarin.com", "Xamarin Messaging Plugin", "Hello from your friends at Xamarin!");

            //    // Send a more complex email with the EmailMessageBuilder fluent interface.
            //    var email = new EmailMessageBuilder()
            //      .To("plugins@xamarin.com")
            //      .Cc("plugins.cc@xamarin.com")
            //      .Bcc(new[] { "plugins.bcc@xamarin.com", "plugins.bcc2@xamarin.com" })
            //      .Subject("Xamarin Messaging Plugin")
            //      .Body("Hello from your friends at Xamarin!")
            //      .Build();

            //    emailTask.SendEmail(email);
            //}

            //var email = new Intent(Android.Content.Intent.ActionSend);
            //email.PutExtra(Android.Content.Intent.ExtraEmail, new string[] { "ankitavyas@gmail.com" });

            //email.PutExtra(Android.Content.Intent.ExtraCc,
            //new string[] { "ankitavyas@gmail.com" });

            //email.PutExtra(Android.Content.Intent.ExtraSubject, "Feedback from KiddyMath");

            //email.PutExtra(Android.Content.Intent.ExtraText,
            //"Write something here....");

            //email.SetType("message/rfc822");

            //StartActivity(email);
        }

        /// <summary>
        /// Command to open browser to xamarin.com
        /// </summary>
        public ICommand OpenWebCommand { get; }
	}
}
