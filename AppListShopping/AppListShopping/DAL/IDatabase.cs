using SQLite;

namespace AppListShopping.DAL
{
    public interface IDatabase
    {
        SQLiteConnection GetConnection();
    }
}