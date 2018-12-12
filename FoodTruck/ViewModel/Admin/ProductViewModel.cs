using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using FoodTruck.Model;
using FoodTruck.View;
using FoodTruck.View.Admin;
using Xamarin.Forms;

namespace FoodTruck.ViewModel.Admin
{
    public class ProductViewModel:ProductBaseViewModel
    {

        public ICommand AddProductCommand { get; private set; }
        public ICommand UpdateCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }
        public ICommand LogoutCommand { get; private set; }
        public ProductViewModel(INavigation navigation)
        {
           
            _navigation = navigation;
            AddProductCommand = new Command(OnAddProduct);
            UpdateCommand = new Command<Product>(OnUpdateProduct);
            DeleteCommand = new Command<Product>(DeleteProduct);
            LogoutCommand = new Command(Logout);
            FetchProducts();
        }

        public async void Logout()
        {
            await _navigation.PushAsync(new HomePage());
        }

        public async void DeleteProduct(Product product)
        {
            await App.Database.DeleteProduct(product);
            ProductList.Remove(product);
        }

        public async void OnUpdateProduct(Product product)
        {
            await _navigation.PushAsync(new AddProductPage(product));
        }

        public async void OnAddProduct(object obj)
        {
            await _navigation.PushAsync(new AddProductPage());

        }
        public async void FetchProducts()
        {
            var prod = await App.Database.GetItemsAsync();
            ProductList = new ObservableCollection<Product>(prod);
        }
    }
}
