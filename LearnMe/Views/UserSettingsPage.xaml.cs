namespace LearnMe.Views;

public partial class UserSettingsPage : ContentPage
{
	public UserSettingsPage()
	{
		InitializeComponent();
	}
    async void BackButton_Clicked(System.Object sender, System.EventArgs e)
    {
        Shell.Current.GoToAsync("//user");
    }
    private bool _isPasswordVisible;

    private void OnShowPasswordButtonToggled(object sender, EventArgs e)
    {
        _isPasswordVisible = !_isPasswordVisible;
        passwordEntry.IsPassword = !_isPasswordVisible;
        confirmedPasswordEntry.IsPassword = !_isPasswordVisible;
    }
}