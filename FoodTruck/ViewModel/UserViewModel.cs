using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using FoodTruck.Model;
using FoodTruck.Service;
using FoodTruck.View;
using FoodTruck.View.Admin;
using FoodTruck.ViewModel.Admin;
using Xamarin.Forms;

namespace FoodTruck.ViewModel
{
    public class UserViewModel:ProductBaseViewModel
    {

        public ICommand LoginCommand { get; private set; }
        public ICommand SignUpCommand { get; private set; }
        private IPageService _pageService;
        public User user;
        public ObservableCollection<User> UserList;
        MasterDetailPageOperations operations;
        public UserViewModel()
        {
            _pageService = new PageService();
            user = new User();
            FetchUser();
            operations = new MasterDetailPageOperations();
            LoginCommand = new Command(VerifyCreditionals);
            SignUpCommand = new Command(OnSignUp);
        }
        public async void FetchUser()
        {
            var users= await App.UserDatabase.GetItemsAsync();
            UserList = new ObservableCollection<User>(users);

        }
      //  private string _email;
        public string Email{
            get { return user.Email; }
            set{
                user.Email = value;
                NotifyPropertyChanged("Email");

            }
        }
      //  private string _password;
        public string Password{
            get { return user.Password; }
            set{
                user.Password = value;
                NotifyPropertyChanged("Password");
            }
        }

        public void VerifyCreditionals()
        {
            bool check = false;
            if(UserList!=null)
            {
                foreach(var users in UserList)
                {
                    if (users.Email == user.Email && users.Password == user.Password)
                    {
                        check = true;
                        if(user.Email.Contains("Admin"))
                        operations.pushMaster(new ProductPage());
                        else
                            operations.pushMaster(new HomePage(user.Email));

                    }

                }
                if(!check)
                _pageService.DisplayAlert("Error", "Inavalid User Name and Password", "Ok", "Cancel");
            }
     

        }
        private void OnSignUp()
        {
             operations.pushMaster(new SignUpPage());
         
        }
    }
}
