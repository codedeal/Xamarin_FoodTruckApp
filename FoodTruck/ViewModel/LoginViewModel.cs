using System;
using System.Diagnostics;
using System.Windows.Input;
using FoodTruck.Model;
using FoodTruck.Service;
using FoodTruck.View;
using Xamarin.Forms;

namespace FoodTruck.ViewModel
{
    public class LoginViewModel:BaseViewModel
    {
        public UserViewModel user { get; private set; }
        public ICommand LoginCommand { get; private set; }
        public ICommand SignUpCommand { get; private set; }
        private IPageService _pageService;
        public LoginViewModel()
        {
             user = new UserViewModel();
             LoginCommand = new Command(VerifyCreditionals);
            SignUpCommand = new Command(OnSignUp);
            _pageService = new PageService();
        }

        private void OnSignUp()
        {
            _pageService.PushAsync(new SignUpPage());
        }

        public void VerifyCreditionals()
        {
            Debug.Write(user.Email);
            Debug.Write(user.Password);

        }
    }
}
