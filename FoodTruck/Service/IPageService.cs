using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FoodTruck.Service
{
    public interface IPageService
    {
        Task PushAsync(Page page);
        Task PopAsync(Page page);
        Task<bool> DisplayAlert(string title, string message, string ok, string cancel);
    }
}
