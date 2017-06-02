using System;
using System.ComponentModel;
using System.Threading;
using MobileApp.Enum;
using MobileApp.Models;
using MobileApp.ViewModels;
using Xamarin.Forms;

namespace MobileApp.Views
{
	public partial class CompareNumber : ContentPage
	{
        public CompareNumber(ComparisonSelection comparisonSelection, DifficultyLevelEnum difficultyLevelEnum)
		{
			InitializeComponent ();
		    this.BindingContext = new ComparisonViewModel(comparisonSelection, difficultyLevelEnum);
            
        }
    }
}
