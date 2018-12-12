using System;
using System.Collections.Generic;
using Badge.Plugin;
using FoodTruck.Model;
using FoodTruck.ViewModel;
using Xamarin.Forms;
using MenuItem = FoodTruck.Model.MenuItem;

namespace FoodTruck.View
{
    public partial class FoodListPage : ContentPage
    {
        public List<MenuItem> menuList { get; set; }
        public FoodListPage()
        {
            InitializeComponent();
           
            BindingContext = new FoodListViewModel();


          /*  foodListView.ItemsSource = new List<Food>()
            {
                new Food{Id=1,Name="Choclate Cake",Category="Burger",Image="http://lorempixel.com/200/100/food/10/",Description="Spice of Choclate"},
                new Food{Id=1,Name="Tofu Salad",Category="Juice",Image="http://lorempixel.com/200/100/food/2/",Description="Tofu with a Twist"},
               new Food{Id=1,Name="Green Omelete",Category="Fruits",Image="http://lorempixel.com/200/100/food/3/",Description="Healthy Duck Egg with Wheat Bread"},
               new Food{Id=1,Name="Organic Salad",Category="Juice",Image="http://lorempixel.com/200/100/food/4/",Description="From Fresh Farm"},
                new Food{Id=1,Name="Fruit Salad",Category="Beverages",Image="http://lorempixel.com/200/100/food/5/",Description="Good as New"},
               new Food{Id=1,Name="Sushi",Category="Chicken Wing",Image="http://lorempixel.com/200/100/food/6/",Description="Ting Wih Sushi"}
            };*/
        }



      
      void OnFoodSelected(object sender, System.EventArgs e)
        {
            var item = sender as MenuItem;
            var food= item.CommandParameter as Food;
            DisplayAlert("food selected", food.Name, "OK");
        }
    }
}
