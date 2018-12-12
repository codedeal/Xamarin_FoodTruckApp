using System;
using FoodTruck.Data;
using FoodTruck.View;
using FoodTruck.View.Admin;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace FoodTruck
{
    public partial class App : Application
    {
        static FoodTruckDatabase dataAccess;
        static OrderDatabase orderDatabase;
        static UserDatabase userDatabase;
        public App()
        {
            InitializeComponent();

              MainPage = new HomePage();

            //  MainPage = new NavigationPage(new ProductPage());
           // MainPage = new ProductListPage();
        }
        public static FoodTruckDatabase Database
        {

            get
            {
                if (dataAccess == null)
                {
                    dataAccess = new FoodTruckDatabase();

                }
                return dataAccess;
            }
        }
        public static OrderDatabase OrdersDatabase
        {
            get
            {
                if (orderDatabase == null)
                {
                    orderDatabase = new OrderDatabase();

                }
                return orderDatabase;
            }
        }
        public static UserDatabase UserDatabase
        {
            get{
                if(userDatabase==null)
                {
                    userDatabase = new UserDatabase();
                }
                return userDatabase;
            }
        }
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
