using System;
using SQLite;

namespace FoodTruck.Model
{
    public class Product
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public string Image { get; set; }

        public double Price { get; set; }
        public string Description { get; set; }
    }
}
