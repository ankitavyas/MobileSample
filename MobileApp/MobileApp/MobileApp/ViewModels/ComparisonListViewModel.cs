using System;
using System.Diagnostics;
using System.Threading.Tasks;
using MobileApp.Enum;
using MobileApp.Helpers;
using MobileApp.Models;
using MobileApp.Views;

using Xamarin.Forms;

namespace MobileApp.ViewModels
{
	public class ComparisonListViewModel : BaseViewModel
	{
		public ObservableRangeCollection<Item> Items { get; set; }
		public Command LoadItemsCommand { get; set; }

		public ComparisonListViewModel()
		{
			Title = "Comparison";
			Items = new ObservableRangeCollection<Item>();
			LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

			
		}

		async Task ExecuteLoadItemsCommand()
		{
            

            if (IsBusy)
				return;

			IsBusy = true;

			try
			{
				Items.Clear();
			    var items = new ObservableRangeCollection<Item>
			    {
			        new Item() {Text = "EASY - Find Big Number", Description = "Choose Big Number out of two numbers", Id = ((int)ComparisionOperation.Big).ToString(), DifficultyLevelEnum = DifficultyLevelEnum.Easy},
			        new Item() {Text = "EASY - Find Small Number", Description = "Choose Small Number out of two numbers", Id = ((int)ComparisionOperation.Small).ToString() , DifficultyLevelEnum = DifficultyLevelEnum.Easy},
                    new Item() {Text = "MEDIUM - Find Big Number", Description = "Choose Big Number out of three numbers", Id = ((int)ComparisionOperation.Big).ToString(), DifficultyLevelEnum = DifficultyLevelEnum.Medium},
                    new Item() {Text = "MEDIUM - Find Small Number", Description = "Choose Small Number out of three numbers", Id = ((int)ComparisionOperation.Small).ToString() , DifficultyLevelEnum = DifficultyLevelEnum.Medium},

                };
			    Items.ReplaceRange(items);
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
				MessagingCenter.Send(new MessagingCenterAlert
				{
					Title = "Error",
					Message = "Unable to load items.",
					Cancel = "OK"
				}, "message");
			}
			finally
			{
				IsBusy = false;
			}
		}
	}
}