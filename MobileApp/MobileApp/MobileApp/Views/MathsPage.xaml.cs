using System;
using System.ComponentModel;
using System.Threading;
using MobileApp.Enum;
using MobileApp.Models;
using MobileApp.ViewModels;
using Xamarin.Forms;

namespace MobileApp.Views
{
	public partial class MathsPage : ContentPage
	{
        //public Numerical Item { get; set; }

        public MathsPage (HomeSelection homeSelection, DifficultyLevelEnum difficultyLevelEnum)
		{
			InitializeComponent ();
		    this.BindingContext = new CalculationViewModel(homeSelection, difficultyLevelEnum);
            
        }
    }
}
