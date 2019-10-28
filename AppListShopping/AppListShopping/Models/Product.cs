using SQLite;

namespace AppListShopping.Models
{
    [Table("Product")]
    public class Product
    {
        [PrimaryKey, AutoIncrement] public int Id { get; set; }
        public string Name { get; set; }
        public bool Buy { get; set; }
        public int Count { get; set; }

        public Product()
        {
            Buy = false;
        }
    }
}