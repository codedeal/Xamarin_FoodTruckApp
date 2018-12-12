using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FoodTruck.Model;
using FoodTruck.Persistence;
using SQLite;
using Xamarin.Forms;

namespace FoodTruck.Data
{
    public class FoodTruckDatabase
    {

        private SQLiteAsyncConnection _connection;
        public FoodTruckDatabase()
        {
            Console.WriteLine("Creating Table ...");
            _connection = DependencyService.Get<ISQLite>().GetConnection();
            _connection.CreateTableAsync<Product>().Wait();
        }

        public Task<List<Product>> GetItemsAsync()
        {
            return _connection.Table<Product>().ToListAsync();
        }

        public Task<int> SaveItem(Product food)
        {
            if (food.Id != 0)
            {
                return _connection.UpdateAsync(food);
            }
            return _connection.InsertAsync(food);
        }

        public async Task<int> DeleteProduct(Product product)
        {
            return await _connection.DeleteAsync(product);
        }
    }
}
