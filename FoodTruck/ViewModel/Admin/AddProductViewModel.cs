using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using FoodTruck.Model;
using FoodTruck.View.Admin;
using Xamarin.Forms;

namespace FoodTruck.ViewModel.Admin
{
    public class AddProductViewModel:ProductBaseViewModel
    {
        public ICommand SaveCommand { get; private set; }
        public AddProductViewModel(INavigation navigation,Product prod)
        {
            _navigation = navigation;
            if (prod != null)
            { product = prod; }
            else
            { product = new Product(); }
            ProductList = new ObservableCollection<Product>();
            SaveCommand = new Command(SaveProduct);
        }

        public async void SaveProduct()
        {
            await  App.Database.SaveItem(product);
            await _navigation.PushAsync(new ProductPage());
        }
    }
}
