using AppListShopping.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppListShopping.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductsPurchasedPage : ContentPage
    {
        public ProductsPurchasedPage()
        {
            InitializeComponent();
            BindingContext = new ProductsPurchasedViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = new ProductsPurchasedViewModel();
        }
    }
}