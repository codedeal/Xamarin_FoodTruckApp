using System;
using System.Collections.Generic;
using FoodTruck.ViewModel.Admin;
using Xamarin.Forms;

namespace FoodTruck.View.Admin
{
    public partial class ProductPage : ContentPage
    {
        public ProductPage()
        {
            InitializeComponent();

            BindingContext = new ProductViewModel(Navigation);
        }
    }
}
