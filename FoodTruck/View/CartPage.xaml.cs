using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using FoodTruck.Model;
using FoodTruck.ViewModel;
using Xamarin.Forms;

namespace FoodTruck.View
{
    public partial class CartPage : ContentPage
    {
        Dictionary<Product, Int32> _cartList;
        public CartPage(Dictionary<Product, Int32> cartList)
        {
            InitializeComponent();
            _cartList = cartList;
            BindingContext = new CartViewModel(_cartList);
        }
    }
}
