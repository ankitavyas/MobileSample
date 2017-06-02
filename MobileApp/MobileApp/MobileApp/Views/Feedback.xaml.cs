using MobileApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileApp.Enum;
using MobileApp.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views
{
	public partial class Feedback : ContentPage
	{

        public Feedback ()
		{
			InitializeComponent ();

            this.BindingContext = new FeedbackViewModel(new Models.Feedback(), this);
        }

        internal async Task GoBack()
        {
            await Navigation.PopToRootAsync(true);
        }


	}
}
