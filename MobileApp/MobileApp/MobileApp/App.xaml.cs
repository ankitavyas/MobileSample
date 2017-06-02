using MobileApp.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MobileApp
{
	public partial class App : Application
	{
        public App()
		{
			InitializeComponent();

			SetMainPage();
		}

		public static void SetMainPage()
		{
            Current.MainPage = new TabbedPage
            {
                Children =
                {
                    new NavigationPage(new Home())
                    {
                        Title = "Maths",
                        Icon = Device.OnPlatform<string>("tab_about.png",null,null)
                    },
                    new NavigationPage(new ComparisionList())
                    {
                        Title = "Comparision",
                        Icon = Device.OnPlatform<string>("tab_about.png",null,null)
                    },
                    new NavigationPage(new AboutPage())
                    {
                        Title = "About",
                        Icon = Device.OnPlatform<string>("tab_about.png",null,null)
                    },
                    
                }
            };
        }
	}
}
