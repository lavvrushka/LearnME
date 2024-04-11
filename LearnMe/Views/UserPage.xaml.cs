using LearnMe.ViewModels;
namespace LearnMe.Views;

public partial class UserPage : ContentPage
{
    private string[] imagePaths = { "achone.jpg", "achtri.jpg", "achchet.jpg", "achpiat.jpg", "achshest.jpg", "achdva.jpg" }; // Пути к вашим изображениям
    private int currentIndex = 0;
    private readonly TimeSpan interval = TimeSpan.FromSeconds(10); // Интервал в секундах между сменой изображений
    private bool isTimerRunning = false;

    public UserPage(UserViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        StartTimer();
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        StopTimer();
    }

    private void StartTimer()
    {
        Device.StartTimer(interval, () =>
        {
            ChangeImage();
            return isTimerRunning; // Возвращаемое значение указывает, продолжать ли таймер
        });
        isTimerRunning = true;
    }

    private void StopTimer()
    {
        isTimerRunning = false;
    }

    private void ChangeImage()
    {
        currentIndex = (currentIndex + 1) % imagePaths.Length;
        AchievementsButton.Source = imagePaths[currentIndex];
    }
    async void BackButton_Clicked(System.Object sender, System.EventArgs e)
    {
        Shell.Current.GoToAsync("//main");
    }

    async void Settings_Clicked(System.Object sender, System.EventArgs e)
    {
        Shell.Current.GoToAsync("//user_settings");
    }
    async void Groups_Clicked(System.Object sender, System.EventArgs e)
    {
        Shell.Current.GoToAsync("//user_groups");
    }

    async void Achievements_Clicked(System.Object sender, System.EventArgs e)
    {
        Shell.Current.GoToAsync("//achievements");
    }
    async void SeeAll_Clicked(System.Object sender, System.EventArgs e)
    {
        Shell.Current.GoToAsync("//achievements");
    }

    private async void Avatar_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//avatar");

        var avatarPage = new AvatarPage();
        avatarPage.AvatarSelected += (s, selectedImage) =>
        {
            // Установка выбранной картинки в кнопку AvatarButton
            AvatarButton.Source = selectedImage;
        };
        await Navigation.PushAsync(avatarPage);
    }

}
