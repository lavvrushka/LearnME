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
    public partial class SignUpViewModel : ObservableObject
    {
        private readonly AuthenticationService _authenticationService;

        public SignUpViewModel(AuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [ObservableProperty]
        string username;

        [ObservableProperty]
        string password;

        [ObservableProperty]
        string confirmedPassword;

        [ObservableProperty]
        string email;

        [RelayCommand]
        void SignUp()
        {
            if (_authenticationService.SignUp(Username, Password, Email))
            {
                Shell.Current.GoToAsync("//auth_login");
            }
        }

        [RelayCommand]
        void LoginPage()
        {
            Shell.Current.GoToAsync("//auth_login");
        }

    }
}
