using System;
using System.Collections.Generic;
using System.Linq;
using FoodTruck.Service;
using FoodTruck.ViewModel;
using Xamarin.Forms;

namespace FoodTruck.View
{
   
    public partial class ProductListPage : ContentPage
    {
        static int count = 0;
        public ProductListPage()
        {
            InitializeComponent();

            BindingContext = new ProductListViewModel();
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            count++;
            var newvalue = count.ToString();
            if (ToolbarItems.Count > 0)
            {
                DependencyService.Get<IToolbarItemBadgeService>().SetBadge(this, ToolbarItems.First(), newvalue, Color.Red, Color.White);
            }
        }

        void SearchTextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            (BindingContext as ProductListViewModel).searchTextChanged(e.NewTextValue);
        }
    }
}
