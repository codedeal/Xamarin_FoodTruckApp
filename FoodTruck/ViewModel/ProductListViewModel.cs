using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;
using FoodTruck.Model;
using FoodTruck.Service;
using FoodTruck.View;
using FoodTruck.ViewModel.Admin;
using Xamarin.Forms;


namespace FoodTruck.ViewModel
{  
    public class ProductListViewModel:ProductBaseViewModel
    {
       
        public Order orders;
        ObservableCollection<Order> _orderList;
        public ObservableCollection<Order> OrderList
        {
            get => _orderList;
            set
            {
                _orderList = value;
                NotifyPropertyChanged("OrderList");
            }
        }
       

        public  ObservableCollection<Order> CartOrder;
        public ICommand AddProductCommand { get; set; }
        public ICommand CartCommnad { get; set; }

        private IPageService pageService;
        public MasterDetailPageOperations operations;

        private  Dictionary<Product, Int32> _cartdictionary;
        private IList<ToolbarItem> toolbarItems;

        public ObservableCollection<Product> originalList;
        public  Dictionary<Product, Int32> CartDictionary
        {
            get
            {
                return _cartdictionary;
            }
            set
            {
                _cartdictionary = value;
               // NotifyPropertyChanged("CartDictionary");
            }
        }
        public ProductListViewModel()
        {
            FetchProducts();
            FetchOrders();
            //ToolbarItems = toolbarItems;
            orders = new Order();
            pageService = new PageService();
            CartDictionary = new Dictionary<Product, int>();
            //intializing all Commands
            AddProductCommand = new Command<Product>(AddProductToCart);
            CartCommnad = new Command(SelectedProduct);
            operations = new MasterDetailPageOperations();
            CartOrder = new ObservableCollection<Order>();

        }

       

        public void SelectedProduct()
        {
           if (CartDictionary == null || CartDictionary.Count == 0)
            {
                Debug.Write("List is empty mate");
                pageService.DisplayAlert("Empty Cart", "Please search some products", "OK", "Cancel");
                return;
            }
           
      
           
            operations.pushMaster(new CartPage(CartDictionary));
        }

        public void AddProductToCart(Product product)
        {
            Debug.WriteLine(product);
            orders.products=product;

            orders.Quantity = 1;
            //  App.OrdersDatabase.SaveItem(orders);

           
             //   DependencyService.Get<IToolbarItemBadgeService>().SetBadge(this, ToolbarItems.First(), $"{e.NewValue}", Color.Red, Color.White);
            if (CartDictionary == null)
            {
                CartDictionary.Add(product, 1);
                return;

            }
            if (CartDictionary.ContainsKey(product))
            {
                CartDictionary[product] = CartDictionary[product] + 1;
                return;
            }
            else
            {
                CartDictionary.Add(product, 1);
            }
        }

        public async void FetchProducts()
        {
            var prod = await App.Database.GetItemsAsync();
            ProductList = new ObservableCollection<Product>(prod);
            originalList = ProductList;
        }

        public async void FetchOrders()
        {
            var order = await App.OrdersDatabase.GetItemsAsync();
         
            OrderList = new ObservableCollection<Order>(order);
            CartOrder = OrderList;
        }

        public ObservableCollection<Product> searchTextChanged(String data)
        {

            if (string.IsNullOrWhiteSpace(data))
            {
                ProductList = originalList;
                return ProductList;
            }
            IEnumerable<Product> searchresult=ProductList.Where(c => c.Name.StartsWith(data));
            var Items = new ObservableCollection<Product>(searchresult);
            ProductList = Items;
            return Items;
        }
    }
}
