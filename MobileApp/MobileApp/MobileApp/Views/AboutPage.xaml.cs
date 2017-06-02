
using System.Net.Mail;
using System.Text;
using MobileApp.Helpers;
using Xamarin.Forms;

namespace MobileApp.Views
{
	public partial class AboutPage : ContentPage
	{

        public BaseCommand OpenFeedback { get; set; }

        public AboutPage()
		{
			InitializeComponent();
            BindingContext = this;

            Title = "About";

            OpenFeedback = new BaseCommand(OpenFeedbackPageAsync);

        }


        private void OpenFeedbackPageAsync()
        {
            Navigation.PushAsync(new Feedback());
        }
    }
}
