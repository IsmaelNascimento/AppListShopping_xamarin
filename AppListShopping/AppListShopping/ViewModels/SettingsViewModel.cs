using AppListShopping.DAL;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppListShopping.ViewModels
{
    public class SettingsViewModel : Page
    {
        public ICommand ButtonDeleteAllProductsBuyNo { get; set; }
        public ICommand ButtonDeleteAllProductsBuyYes { get; set; }
        public ICommand ButtonDeleteAllProductsBuy { get; set; }
        public ICommand ButtonSaveEmail { get; set; }

        public SettingsViewModel()
        {
            ButtonDeleteAllProductsBuyNo = new Command(async () => await DeleteAllProductsBuyNo());
            ButtonDeleteAllProductsBuyYes = new Command(async () => await DeleteAllProductsBuyYes());
            ButtonDeleteAllProductsBuy = new Command(async () => await DeleteAllProductsBuy());
            ButtonSaveEmail = new Command<string>(async (x) => await SaveEmail(x));
        }

        public async Task DeleteAllProductsBuyNo()
        {
            var decision = await Application.Current.MainPage.DisplayAlert("Alerta", "Tem certeza disso ?", "Sim", "Não");
            if (decision) new ProductDAL().DeleteAllProducts(false);
        }

        public async Task DeleteAllProductsBuyYes()
        {
            var decision = await Application.Current.MainPage.DisplayAlert("Alerta", "Tem certeza disso ?", "Sim", "Não");
            if (decision) new ProductDAL().DeleteAllProducts(true);
        }

        public async Task DeleteAllProductsBuy()
        {
            var decision = await Application.Current.MainPage.DisplayAlert("Alerta", "Tem certeza disso ?", "Sim", "Não");
            if (decision) new ProductDAL().DeleteAllProducts();
        }

        public async Task SaveEmail(string email)
        {
            if (String.IsNullOrEmpty(email))
                await Application.Current.MainPage.DisplayAlert("Erro", "Digite um email", "OK");
            else
                await Application.Current.MainPage.DisplayAlert("Obrigado !", "Você receberá as melhores promoções", "OK");
        }
    }
}