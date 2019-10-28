using AppListShopping.Views;
using Xamarin.Forms;

namespace AppListShopping
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();
			MainPage = new MainPage();
		}
	}
}