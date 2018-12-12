using System;
using System.Collections.Generic;
using FoodTruck.ViewModel;
using Xamarin.Forms;

namespace FoodTruck.View
{
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            InitializeComponent();
          
            BindingContext = new SignUpViewModel();
        }
    }
}
