using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using FoodTruck.Model;
using FoodTruck.Service;
using FoodTruck.View;
using FoodTruck.ViewModel.Admin;
using Xamarin.Forms;

namespace FoodTruck.ViewModel
{
    public class SignUpViewModel:ProductBaseViewModel
    {
        private IPageService _pageService;
 
        public User user;

        private ObservableCollection<User> _userList;

        MasterDetailPageOperations operations;
        public ObservableCollection<User>UserList{
            get => _userList;
            set
            {
                _userList = value;
                NotifyPropertyChanged("UserList");
            }
        }
       // private string _email;
        public string Email
        {
            get { return user.Email; }
            set
            {
                user.Email = value;
                NotifyPropertyChanged("Email");

            }
        }
       // private string _password;
        public string Password
        {
            get { return user.Password; }
            set
            {
                user.Password = value;
                NotifyPropertyChanged("Password");
            }
        }
        private string _confirmpassword;
        public string ConfirmPassword
        {
            get { return _confirmpassword; }
            set
            {
                _confirmpassword = value;
                NotifyPropertyChanged("ConfirmPassword");
            }
        }
        public ICommand SignUpCommand { get; private set; }
        public ICommand UserCommand { get; private set; }
        public ICommand BackCommand { get; private set; }
        public SignUpViewModel()
        {
            user = new User();
            FetchUser();
            UserCommand = new Command(GoUserPage);
            SignUpCommand = new Command(OnSignUp);
            BackCommand = new Command(OnBack);
            _pageService = new PageService();
            operations = new MasterDetailPageOperations();
        }

        public  void OnBack(object obj)
        {
            //   await _pageService.PushAsync(new LoginPage());
            operations.pushAsync(new LoginPage());
           
        }

        public async void FetchUser()
        {
            var users = await App.UserDatabase.GetItemsAsync();
            UserList = new ObservableCollection<User>(users);

        }
        public async void GoUserPage(object obj)
        {
            await _pageService.PushAsync(new UserListPage(UserList));
        }

        public async void OnSignUp()
        {
           /* if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(ConfirmPassword))
            {
                _pageService.DisplayAlert("OOPS", "Seems like mandatory fields are vacant fill them", "Ok", "Cancel");
                return;
            }
            if(!Email.Contains("@")&&!Email.Contains(".com"))
            {
                _pageService.DisplayAlert("OOPS", "Invalid Email Provide Correct Email", "Ok", "Cancel");
                return;
            }
            if(!Password.Equals(ConfirmPassword))
            {
                _pageService.DisplayAlert("OOPS", "Password and Confirm Password not match", "Ok", "Cancel");
                return;
            }*/
            await App.UserDatabase.SaveUser(user);
            await _pageService.PushAsync(new HomePage());
        }
    }
}
