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
    public class UserDatabase
    {
        private SQLiteAsyncConnection _connection;
        public UserDatabase()
        {
            Console.WriteLine("Creating Table ...");
            _connection = DependencyService.Get<ISQLite>().GetConnection();
            _connection.CreateTableAsync<User>().Wait();
        }
        public Task<int> SaveUser(User user)
        {
           /* if (UserList.Count!= 0)
            {
                foreach (var presentuser in UserList)
                {
                    if(presentuser.Email.Equals(user.Email))
                    return _connection.UpdateAsync(user);
                }
                return _connection.InsertAsync(user);
            }*/
            return _connection.InsertAsync(user);
        }
        public Task<List<User>> GetItemsAsync()
        {
            return  _connection.Table<User>().ToListAsync();
        }
    }
}
