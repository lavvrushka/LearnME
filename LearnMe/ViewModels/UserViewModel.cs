using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LearnMe.Models;
using LearnMe.Service;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace LearnMe.ViewModels
{
    public partial class UserViewModel : ObservableObject
    {
        private readonly UserService _userService;

        public UserViewModel(UserService userService)
        {
            _userService = userService;
        }

        [RelayCommand]
        public void UpdateUser(User user)
        {
           _userService.UpdateUser(user);
        }


        
    }
}
