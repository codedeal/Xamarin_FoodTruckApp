using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using FoodTruck.Model;
using Xamarin.Forms;

namespace FoodTruck.ViewModel.Admin
{
    public class ProductBaseViewModel: INotifyPropertyChanged
    {
        public Product product;

        public INavigation _navigation;

        ObservableCollection<Product> _productList;
        public ObservableCollection<Product> ProductList
        {
            get => _productList;
            set
            {
                _productList = value;
                NotifyPropertyChanged("ProductList");
            }
        }


        public string Name
        {
            get => product.Name;
            set
            {
                product.Name = value;
                NotifyPropertyChanged("Name");
            }
        }

        public string Category
        {
            get => product.Category;
            set
            {
                product.Category = value;
                NotifyPropertyChanged("Category");
            }
        }

        public string Image
        {
            get => product.Image;
            set
            {
                product.Image = value;
                NotifyPropertyChanged("Image");
            }
        }

        public double Price
        {
            get => product.Price;
            set
            {
                product.Price = value;
                NotifyPropertyChanged("Price");
            }
        }
        public string Description
        {
            get => product.Description;
            set
            {
                product.Description = value;
                NotifyPropertyChanged("Description");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
