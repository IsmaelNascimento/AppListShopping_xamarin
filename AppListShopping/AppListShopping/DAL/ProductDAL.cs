using SQLite;
using System.Collections.Generic;
using Xamarin.Forms;
using AppListShopping.Models;
using System.Linq;

namespace AppListShopping.DAL
{
    public class ProductDAL
    {
        private SQLiteConnection database;

        public ProductDAL()
        {
            database = DependencyService.Get<IDatabase>().GetConnection();
            database.CreateTable<Product>();
        }

        /// <summary>
        /// Get All Task
        /// </summary>
        /// <returns></returns>
        public List<Product> GetProducts()
        {
            return database.Table<Product>().ToList();
        }

        /// <summary>
        /// Get Task with parameters closed
        /// </summary>
        /// <param name="buy"></param>
        /// <returns></returns>
        public List<Product> GetProducts(bool buy)
        {
            return database.Table<Product>().Where(x => x.Buy == buy).ToList();
        }

        public int SaveProduct(Product product)
        {
            return database.Insert(product);
        }

        public int UpdateProduct(Product product)
        {
            return database.Update(product);
        }

        public int DeleteProduct(Product product)
        {
            return database.Delete(product);
        }

        public void DeleteAllProducts()
        {
            var productsForDelete = GetProducts();

            for (int i = 0; i < productsForDelete.Count; i++)
            {
                DeleteProduct(productsForDelete[i]);
            }
        }

        public void DeleteAllProducts(bool buy)
        {
            var productsForDelete = database.Table<Product>().Where(x => x.Buy == buy).ToList();

            for (int i = 0; i < productsForDelete.Count; i++)
            {
                DeleteProduct(productsForDelete[i]);
            }
        }
    }
}