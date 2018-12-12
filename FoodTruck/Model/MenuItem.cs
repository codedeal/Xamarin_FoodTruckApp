using System;
namespace FoodTruck.Model
{
    public class MenuItem
    {
        public string Title { get; set; }
        public string Icon { get; set; }
        public Type TargetType { get; set; }
        public Food CommandParameter { get; internal set; }
    }
}
