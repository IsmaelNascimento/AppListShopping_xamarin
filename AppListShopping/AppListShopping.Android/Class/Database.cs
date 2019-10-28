using AppListShopping.DAL;
using AppListShopping.Droid.Class;
using SQLite;

[assembly: Xamarin.Forms.Dependency(typeof(Database))]
namespace AppListShopping.Droid.Class
{
    public class Database : IDatabase
    {
        public SQLiteConnection GetConnection()
        {
            var nameDB = "listShopping.db3";
            var rootPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var pathDB = string.Concat(rootPath, nameDB);
            return new SQLiteConnection(pathDB);
        }
    }
}