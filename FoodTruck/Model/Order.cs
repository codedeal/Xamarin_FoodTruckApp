using System;
using System.Collections.Generic;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace FoodTruck.Model
{
    public class Order
    {
        [PrimaryKey, AutoIncrement]
        public int Order_Id { get; set; }
        [OneToMany]
        public Product products { get; set; }
        public int Quantity { get; set; }

       
    }
}
