using System;
using System.Collections.Generic;

using Xamarin.Forms;
using FoodTruck.Model;
using MenuItem = FoodTruck.Model.MenuItem;
using System.Diagnostics;
using FoodTruck.Service;

namespace FoodTruck.View
{
    public partial class MenuPage : ContentPage
    {
        string email;
        public List<MenuItem> menuList { get; set; }
      
        MasterDetailPageOperations master = new MasterDetailPageOperations();
        public MenuPage(string user=null)
        {

            InitializeComponent();

            email = user;
            if(email!=null)
            {
                string []word = email.Split('@');
                email = word[0];
            }

            menuList = new List<MenuItem>();

            // Creating our pages for menu navigation
            // Here you can define title for item, 
            // icon on the left side, and page that you want to open after selection
            var page5 = new MenuItem();
            var page1 = new MenuItem() { Title = "Burgers", Icon = "ham.png",TargetType=typeof(BurgerPage) };
            var page2 = new MenuItem() { Title = "Chick Wings", Icon = "chicken.png", TargetType = typeof(ChickenPage) };
            var page3 = new MenuItem() { Title = "Fruits", Icon = "fruit.png", TargetType = typeof(FruitsPage) };
            var page4 = new MenuItem() { Title = "Beverages", Icon = "juice.png",TargetType=typeof(BeveragesPage) };

            page5 =new MenuItem() { Title = email!=null?"Welcome "+email:"Login", Icon = "bat.png",TargetType=typeof(LoginPage) };
         
          //  page5 = new MenuItem() { Title = "Login", Icon = "bat.png", TargetType = typeof(LoginPage) };
            var page6 = new MenuItem() { Title = "Top Picks", Icon = "top.png", TargetType = typeof(ProductListPage) };


            // Adding menu items to menuList
            menuList.Add(page1);
            menuList.Add(page2);
            menuList.Add(page3);
            menuList.Add(page4);
            menuList.Add(page5);
            menuList.Add(page6);

            // Setting our list to be ItemSource for ListView in MainPage.xaml
            navigationDrawerList.ItemsSource = menuList;

           
        
        }

        void Handle_TextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

    
    }
}
