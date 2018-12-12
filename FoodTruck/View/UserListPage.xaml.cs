using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using FoodTruck.Model;
using Xamarin.Forms;

namespace FoodTruck.View
{
    public partial class UserListPage : ContentPage
    {
        public UserListPage( ObservableCollection<User>UserList)
        {
            InitializeComponent();
            userListView.ItemsSource = UserList;
        }
    }
}
