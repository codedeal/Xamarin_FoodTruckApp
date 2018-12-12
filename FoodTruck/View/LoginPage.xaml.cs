using System;
using System.Collections.Generic;
using FoodTruck.ViewModel;
using Xamarin.Forms;

namespace FoodTruck.View
{
    public partial class LoginPage : ContentPage
    {

        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new UserViewModel();
        }
    }
}
