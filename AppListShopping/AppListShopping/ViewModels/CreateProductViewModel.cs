using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using AppListShopping.Models;
using AppListShopping.DAL;

namespace AppListShopping.ViewModels
{
    public class CreateProductViewModel : INotifyPropertyChanged
    {
        public Product ProductCurrent { get; set; }
        public ObservableCollection<Product> Products { get; set; }
        public Command ButtonSaveOrSaveEditionProduct { get; set; }
        public Command ButtonEditProduct { get; set; }
        public Command ButtonDeleteProduct { get; set; }
        public Command ButtonBuyProduct { get; set; }

        public CreateProductViewModel()
        {
            ProductCurrent = new Product();
            Products = new ObservableCollection<Product>(new ProductDAL().GetProducts(false));
            ButtonSaveOrSaveEditionProduct = new Command(SaveOrSaveEditionProductOnClicked);
            ButtonEditProduct = new Command<Product>(EditProductOnClicked);
            ButtonDeleteProduct = new Command<Product>(DeleteProductOnClicked);
            ButtonBuyProduct = new Command<Product>(BuyProductkOnClicked);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propetyName = null)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propetyName));
        }

        public void SaveOrSaveEditionProductOnClicked()
        {
            if (String.IsNullOrEmpty(ProductCurrent.Name))
            {
                return;
            }
            else if (ProductCurrent.Id == 0)
            {
                new ProductDAL().SaveProduct(ProductCurrent);
                Products.Add(ProductCurrent);
                ProductCurrent = new Product();
                OnPropertyChanged("ProductCurrent");
            }
            else
            {
                new ProductDAL().UpdateProduct(ProductCurrent);
                Products = new ObservableCollection<Product>(new ProductDAL().GetProducts(false));
                OnPropertyChanged("Products");
                ProductCurrent = new Product();
                OnPropertyChanged("ProductCurrent");
            }
        }

        public void EditProductOnClicked(Product product)
        {
            ProductCurrent = product;
            OnPropertyChanged("ProductCurrent");
        }

        public void DeleteProductOnClicked(Product product)
        {
            new ProductDAL().DeleteProduct(product);
            Products.Remove(product);
        }

        public void BuyProductkOnClicked(Product product)
        {
            product.Buy = true;
            new ProductDAL().UpdateProduct(product);
            Products = new ObservableCollection<Product>(new ProductDAL().GetProducts(false));
            OnPropertyChanged("Products");
        }
    }
}