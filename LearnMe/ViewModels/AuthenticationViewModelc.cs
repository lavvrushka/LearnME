using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LearnMe.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMe.ViewModels
{
    public partial class AuthenticationViewModel : ObservableObject
    {
        private readonly AuthenticationService _authenticationService;

        public AuthenticationViewModel(AuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }


        [RelayCommand]
        void LoginPage() => Shell.Current.GoToAsync("//auth_login");

        [RelayCommand]
        void SignUpPage() => Shell.Current.GoToAsync("//auth_signup");

        public bool isLoggedIn()
        {
            return _authenticationService.TryAutoLogin();
        }
    }
}
