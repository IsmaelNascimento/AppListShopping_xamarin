using AppListShopping.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppListShopping.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateProductPage : ContentPage
    {
        public CreateProductPage()
        {
            InitializeComponent();
            BindingContext = new CreateProductViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = new CreateProductViewModel();
        }
    }
}