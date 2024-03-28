using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LearnMe.Service;

namespace LearnMe.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {

        private readonly AuthenticationService _authenticationService;

        public LoginViewModel(AuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [ObservableProperty]
        string username;

        [ObservableProperty]
        string password;

        [ObservableProperty]
        bool rememberMe;

        [RelayCommand]
        void SignUpPage()
        {
            Shell.Current.GoToAsync("//auth_signup");
        }

        [RelayCommand]
        void Login()
        {
            try
            {
                _authenticationService.Login(Username, Password, RememberMe);
                Shell.Current.GoToAsync("//main");
                Shell.Current.FlyoutBehavior = FlyoutBehavior.Flyout;
            }
            catch (Exception e)
            {
                Shell.Current.DisplayAlert("Error", e.Message, "Ok");
            }
        }
    }
}
