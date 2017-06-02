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
	public class HomeViewModel : BaseViewModel
	{
		public ObservableRangeCollection<Item> Items { get; set; }
		public Command LoadItemsCommand { get; set; }

		public HomeViewModel()
		{
			Title = "Basic Maths";
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
			        new Item() {Text = "EASY - Addition", Description = "Basic additions like 1+2=3", Id = ((int)MathematicalOperation.Addition).ToString(), DifficultyLevelEnum = DifficultyLevelEnum.Easy},
			        new Item() {Text = "EASY - Subtraction", Description = "Basic subtractions like 3-2=1", Id = ((int)MathematicalOperation.Subtraction).ToString() , DifficultyLevelEnum = DifficultyLevelEnum.Easy},
                    new Item() {Text = "EASY - Multiplication", Description = "Basic multiplications like 3X2=6", Id = ((int)MathematicalOperation.Multiplication).ToString() , DifficultyLevelEnum = DifficultyLevelEnum.Easy},
                    new Item() {Text = "EASY - Division", Description = "Basic divisions like 4/2=2", Id = ((int)MathematicalOperation.Division).ToString(), DifficultyLevelEnum = DifficultyLevelEnum.Easy},

                    new Item() {Text = "MEDIUM - Addition", Description = "Basic to Hard additions like 11+22=33", Id = ((int)MathematicalOperation.Addition).ToString(), DifficultyLevelEnum = DifficultyLevelEnum.Medium},
                    new Item() {Text = "MEDIUM - Subtraction", Description = "Basic to Hard subtractions like 33-22=11", Id = ((int)MathematicalOperation.Subtraction).ToString() , DifficultyLevelEnum = DifficultyLevelEnum.Medium},
                    new Item() {Text = "MEDIUM - Multiplication", Description = "Basic to Hard multiplications like 30X2=60", Id = ((int)MathematicalOperation.Multiplication).ToString() , DifficultyLevelEnum = DifficultyLevelEnum.Medium},
                    new Item() {Text = "MEDIUM - Division", Description = "Basic to Hard divisions like 40/2=20", Id = ((int)MathematicalOperation.Division).ToString(), DifficultyLevelEnum = DifficultyLevelEnum.Medium},

                    new Item() {Text = "HARD - Addition", Description = "Hard additions like 111+222=333", Id = ((int)MathematicalOperation.Addition).ToString(), DifficultyLevelEnum = DifficultyLevelEnum.Hard},
                    new Item() {Text = "HARD - Subtraction", Description = "Hard subtractions like 333-222=111", Id = ((int)MathematicalOperation.Subtraction).ToString() , DifficultyLevelEnum = DifficultyLevelEnum.Hard},
                    new Item() {Text = "HARD - Multiplication", Description = "Hard multiplications like 300X2=600", Id = ((int)MathematicalOperation.Multiplication).ToString() , DifficultyLevelEnum = DifficultyLevelEnum.Hard},
                    new Item() {Text = "HARD - Division", Description = "Hard divisions like 400/2=200", Id = ((int)MathematicalOperation.Division).ToString(), DifficultyLevelEnum = DifficultyLevelEnum.Hard}
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