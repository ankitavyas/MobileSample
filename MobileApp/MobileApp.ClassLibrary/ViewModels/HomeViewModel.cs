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
			Title = "Browse";
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
			        new Item() {Text = "Addition", Description = "Basic additions like 1+2=3", Id = ((int)MathematicalOperation.Addition).ToString()},
			        new Item() {Text = "Subtraction", Description = "Basic subtractions like 3-2=1", Id = ((int)MathematicalOperation.Subtraction).ToString()},
			        new Item() {Text = "Multiplication", Description = "Basic multiplications like 3X2=6", Id = ((int)MathematicalOperation.Multiplication).ToString()},
                    new Item() {Text = "Division", Description = "Basic divisions like 4/2=2", Id = ((int)MathematicalOperation.Division).ToString()}
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