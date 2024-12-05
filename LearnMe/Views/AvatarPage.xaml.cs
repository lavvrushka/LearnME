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

            // ��������� ���� � �����������
            var selectedImage = (radioButton.Content as StackLayout)?.Children.OfType<Image>().FirstOrDefault()?.Source.ToString();

            if (!string.IsNullOrEmpty(selectedImage))
            {
                AvatarSelected?.Invoke(this, selectedImage);

                // ���������� ������� �������� ������������ � ����������� �� ���������
                Utils.AppContext.CurrentUser.Avatar = selectedImage;

                // ���������� ������������ ����� ViewModel, ���� ��� ���������
                _userViewModel.UpdateUser(Utils.AppContext.CurrentUser);
            }
        }


    }
}