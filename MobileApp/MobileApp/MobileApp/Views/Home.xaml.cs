using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileApp.Enum;
using MobileApp.Models;
using MobileApp.ViewModels;
using Xamarin.Forms;

namespace MobileApp.Views
{

	public partial class Home : ContentPage
	{
        HomeViewModel viewModel;

        public Home()
        {
            InitializeComponent();

            BindingContext = viewModel = new HomeViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Item;
            if (item == null)
                return;


            HomeSelection hs = new HomeSelection();
            hs.MathematicalOperation = (MathematicalOperation)int.Parse(item.Id);

            await Navigation.PushAsync(new MathsPage(hs, item.DifficultyLevelEnum));

            // Manually deselect item
            ItemsListView.SelectedItem = null;
        }

        

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}
