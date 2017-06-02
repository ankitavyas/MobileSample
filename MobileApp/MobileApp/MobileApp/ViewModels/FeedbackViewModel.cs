using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
//using Android.Content.Res;
using MobileApp.Enum;
//using Android.Content;
using MobileApp.Helpers;
using MobileApp.Models;
using Xamarin.Forms;

namespace MobileApp.ViewModels
{
	public class FeedbackViewModel : BaseViewModel
	{
        private readonly Views.Feedback childPage;

        private Feedback _item;
	   
        
        public Feedback Item { get { return _item; } set { _item = value; OnPropertyChanged("Item"); } }

        private string _textDescription;
        public string TextDescription { get { return _textDescription; } set { _textDescription = value; OnPropertyChanged("TextDescription"); } }


        private IList<string> _feedbackCategories = new List<string>();
        public IList<string> FeedbackCategories { get { return _feedbackCategories; } set { _feedbackCategories = value; OnPropertyChanged("FeedbackCategories"); } }

        public BaseCommand EmailCommand { get; set; }

	    public string SelectedFeedback { get; set; }

      
	    private readonly ConfigHelper _confighelper;

        public static List<string> GetListOfDescription<T>() where T : struct
        {
            Type t = typeof(T);
            return !t.IsEnum ? null : System.Enum.GetValues(t).Cast<System.Enum>().Select(x => x.ToName()).ToList();
        }

        public FeedbackViewModel(Feedback feedbackModel, Views.Feedback navigation)
        {
            _confighelper = new ConfigHelper();
            this._item = feedbackModel;
            childPage = navigation;
            this.TextDescription = "Submit";

            FeedbackCategories = GetListOfDescription<FeedbackCategoryEnum>();

            //FeedbackCategories.Add(FeedbackCategoryEnum.General.ToName());
            //FeedbackCategories.Add(FeedbackCategoryEnum.Issue.ToName());

            SelectedFeedback = FeedbackCategoryEnum.General.ToName();

            string[] names = System.Enum.GetNames(typeof(FeedbackCategoryEnum)); 

            feedbackModel.Category = FeedbackCategoryEnum.General;
            EmailCommand = new BaseCommand(SendMail);
            
        }

	    private async void SendMail()
	    {
            this.TextDescription = "Processing... Please Wait...";

            MailMessage mm = new MailMessage(_confighelper.EmailFrom, _confighelper.EmailTo, "Feedback - " + SelectedFeedback, _item.Description)
            {
                BodyEncoding = Encoding.UTF8,
                DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
            };
            await SendMail(mm);


            await childPage.GoBack();

        }
        public async Task SendMail(MailMessage message)
        {
            using (var client = new SmtpClient())
            {
                client.Host = _confighelper.SmtpServer;
                client.Port = _confighelper.Port;
                client.UseDefaultCredentials = false;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(_confighelper.EmailUser, _confighelper.EmailPassword);
                await client.SendMailAsync(message);
            }


        }


    }
}
