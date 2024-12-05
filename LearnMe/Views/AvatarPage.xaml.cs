using LearnMe.Utils;
using LearnMe.ViewModels;

namespace LearnMe.Views {


    public partial class AvatarPage : ContentPage
    {
       private readonly UserViewModel _userViewModel;
        public AvatarPage(UserViewModel userViewMode)
        {
            InitializeComponent();
            _userViewModel = userViewMode;
        }
        async void BackButton_Clicked(System.Object sender, System.EventArgs e)
        {
            Shell.Current.GoToAsync("//user");
        }

        public event EventHandler<string> AvatarSelected;

        private void RadioButton_Clicked(object sender, EventArgs e)
        {
            var radioButton = (RadioButton)sender;

            // ѕолучение пути к изображению
            var selectedImage = (radioButton.Content as StackLayout)?.Children.OfType<Image>().FirstOrDefault()?.Source.ToString();

            if (!string.IsNullOrEmpty(selectedImage))
            {
                AvatarSelected?.Invoke(this, selectedImage);

                // ќбновление аватара текущего пользовател€ и уведомление об изменении
                Utils.AppContext.CurrentUser.Avatar = selectedImage;

                // ќбновление пользовател€ через ViewModel, если оно требуетс€
                _userViewModel.UpdateUser(Utils.AppContext.CurrentUser);
            }
        }


    }
}