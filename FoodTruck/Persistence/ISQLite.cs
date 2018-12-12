using System;
using SQLite;

namespace FoodTruck.Persistence
{
    public interface ISQLite
    {
        SQLiteAsyncConnection GetConnection();
    }
}
