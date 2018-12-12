using System;
using System.Collections.Generic;
using FoodTruck.Model;
using FoodTruck.ViewModel.Admin;
using Xamarin.Forms;

namespace FoodTruck.View.Admin
{
    public partial class AddProductPage : ContentPage
    {
        public AddProductPage(Product product=null)
        {
            InitializeComponent();
            BindingContext = new AddProductViewModel(Navigation,product);

        }
    }
}
