using System;
using System.Collections.Generic;
using FoodTruck.Service;
using Xamarin.Forms;
using FoodTruck.Model;
using MenuItem = FoodTruck.Model.MenuItem;

namespace FoodTruck.View
{
    public partial class HomePage : MasterDetailPage
    {
        String email;
        MenuPage masterPage;
        public HomePage(string user=null)
        {

            email = user;
            masterPage = new MenuPage(user);
            Master = masterPage;
            Detail = new NavigationPage(new ProductListPage());
            MasterDetailPageOperations operations = new MasterDetailPageOperations();
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            masterPage.navigationDrawerList.ItemSelected += OnItemSelected;
           

        }
        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MenuItem;
            if (item != null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                masterPage.navigationDrawerList.SelectedItem = null;
                IsPresented = false;
            }
        }

    }
}
