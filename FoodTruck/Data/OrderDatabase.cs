using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using FoodTruck.Model;
using FoodTruck.Persistence;
using SQLite;
using Xamarin.Forms;

namespace FoodTruck.Data
{
    public class OrderDatabase
    {
        private SQLiteAsyncConnection _connection;
        public OrderDatabase()
        {
            Console.WriteLine("Creating Table ...");
            _connection = DependencyService.Get<ISQLite>().GetConnection();
            _connection.CreateTableAsync<Order>().Wait();
        }

        public Task<List<Order>> GetItemsAsync()
        {
            return _connection.Table<Order>().ToListAsync();
        }
        public Task<List<Order>> GetAllEmployees()
        {
           
            return _connection.QueryAsync<Order>("Select products From [Order]");
        }


        public Task<int> SaveItem(Order food)
        {

            if (food.Order_Id != 0)
            {
                return _connection.UpdateAsync(food);
            }
            //return _connection.InsertAllAsync((System.Collections.IEnumerable)food);
            return _connection.InsertAsync(food);
        }

        public Task<int> SaveItem(Order orders, ObservableCollection<Order> orderList)
        {
            if(orderList.Count!=0)
            {
                foreach (var oldorder in orderList)
                {
                    if (oldorder.products.Id == orders.products.Id)
                    {
                        oldorder.Quantity = oldorder.Quantity + 1;
                        return _connection.UpdateAsync(oldorder);
                    }
                }
              //  return  _connection.InsertAllAsync(orders);
                return _connection.InsertAsync(orders);
            }
            return _connection.InsertAsync(orders);
        }
    }
}
