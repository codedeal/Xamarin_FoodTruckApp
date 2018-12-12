using System;
using SQLite;

namespace FoodTruck.Model
{
    public class User
    {  
        [PrimaryKey]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
