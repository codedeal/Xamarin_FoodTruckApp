using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using FoodTruck.Model;
using FoodTruck.Service;
using FoodTruck.View;
using Xamarin.Forms;

namespace FoodTruck.ViewModel
{
    public class CartViewModel:BaseViewModel
    {
        private Dictionary<Product,Int32> _cartList;
        MasterDetailPageOperations operations;
        public IPageService pageService;
        public Dictionary<Product, Int32> CartList{
            get {
                return _cartList;
            }
            set
            {
                _cartList = value;
            }
        }
        public ICommand HomeCommand { get; private set; }
        public ICommand CheckOutCommand { get; private set; }
        public CartViewModel(Dictionary<Product, Int32> foodlist)
        {
            CartList = foodlist;
            operations = new MasterDetailPageOperations();
            pageService = new PageService();
            HomeCommand = new Command(BackToHome);
            CheckOutCommand = new Command<Food>(CheckOutCustomer);

        }

        private void CheckOutCustomer(Food obj)
        {
            pageService.DisplayAlert("Thanks", "for Choosing us your bill is ...", "Ok", "Cancel");
        }

        private void BackToHome()
        {
            operations.pushAsync(new HomePage());
        }
    }
}
