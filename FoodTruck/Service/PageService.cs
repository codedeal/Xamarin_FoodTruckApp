﻿using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FoodTruck.Service
{
    public class PageService:IPageService
    {
        public async Task<bool> DisplayAlert(string title, string message, string ok, string cancel)
        {
            return await  Application.Current.MainPage.DisplayAlert(title, message, ok, cancel);
        }

        public async Task PopAsync(Page page)
        {
            await Application.Current.MainPage.Navigation.PopAsync();

        }

        public async Task PushAsync(Page page)
        {

             await Application.Current.MainPage.Navigation.PushAsync(page);
        }
    }
}
