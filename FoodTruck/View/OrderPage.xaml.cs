using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using FoodTruck.Model;
using FoodTruck.ViewModel;
using Xamarin.Forms;

namespace FoodTruck.View
{
    public partial class OrderPage : ContentPage
    {
        public ObservableCollection<Order> OrderList;
        Dictionary<Product, int> cartValues;
        public OrderPage(ObservableCollection<Order> orderList)
        {
            InitializeComponent();
            OrderList = orderList;
            cartValues = ConvertToDictionary(orderList);
            
            orderlistview.ItemsSource = cartValues;
            //orderlistview.ItemsSource = orderList;
            
            BindingContext =new ProductListViewModel();
        }

        public Dictionary<Product, int> ConvertToDictionary(ObservableCollection<Order> OrderList)
        {
            Dictionary<Product, int> cart = new Dictionary<Product, int>();
            foreach(var order in OrderList)
            {
                cart.Add(order.products, order.Quantity);
            }
            return cart;
        }
    }
}
