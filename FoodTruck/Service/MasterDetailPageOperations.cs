using System;
using Xamarin.Forms;

namespace FoodTruck.Service
{
    public class MasterDetailPageOperations:MasterDetailPage
    {
       

        public void pushAsync(Page page)
        {
           

            Application.Current.MainPage = new View.HomePage();
            IsPresented = false;
        }
        public void pushMaster(Page page)
        {


            // Application.Current.MainPage =  page;
            Application.Current.MainPage = new NavigationPage(page);
            IsPresented = false;
        }
        public void setDetailPage(Page page)
        {
            Detail = new NavigationPage(page);
        }
    }
}
