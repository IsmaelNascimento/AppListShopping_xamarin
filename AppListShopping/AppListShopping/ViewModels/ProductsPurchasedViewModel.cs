using AppListShopping.DAL;
using AppListShopping.Models;
using System.Collections.ObjectModel;

namespace AppListShopping.ViewModels
{
    public class ProductsPurchasedViewModel
    {
        public ObservableCollection<Product> Products { get; set; }

        public ProductsPurchasedViewModel()
        {
            Products = new ObservableCollection<Product>(new ProductDAL().GetProducts(true));
        }
    }
}