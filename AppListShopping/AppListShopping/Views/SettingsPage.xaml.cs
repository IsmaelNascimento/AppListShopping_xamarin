using AppListShopping.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppListShopping.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
            BindingContext = new SettingsViewModel();
        }
    }
}