using LearnMe.ViewModels;
using LearnMe.Data;
using LearnMe.Models;
namespace LearnMe.Views;


public partial class UserPage : ContentPage
{
    private readonly UserViewModel _userViewModel;
    private string[] imagePaths = { "achone.jpg", "achtri.jpg", "achchet.jpg", "achpiat.jpg", "achshest.jpg", "achdva.jpg" }; // Пути к вашим изображениям
    private int currentIndex = 0;
    private readonly TimeSpan interval = TimeSpan.FromSeconds(10); // Интервал в секундах между сменой изображений
    private bool isTimerRunning = false;

    public UserPage(UserViewModel userViewModel)
    {
        InitializeComponent();
        _userViewModel = userViewModel;
        BindingContext = this;
        CurrentUser = Utils.AppContext.CurrentUser;
    }

    private User currentUser;
    public User CurrentUser
    {
        get => currentUser;
        set
        {
            if (currentUser != value)
            {
                currentUser = value;
                OnPropertyChanged();
            }
        }
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

    async void Settings_Clicked(System.Object sender, System.EventArgs e)
    {
        await Shell.Current.GoToAsync("//user_settings");
    }

    async void Groups_Clicked(System.Object sender, System.EventArgs e)
    {
        await Shell.Current.GoToAsync("//user_events");
    }

    async void Achievements_Clicked(System.Object sender, System.EventArgs e)
    {
        await Shell.Current.GoToAsync("//achievements");
    }

    async void SeeAll_Clicked(System.Object sender, System.EventArgs e)
    {
        await Shell.Current.GoToAsync("//auth_signup");
    }

    private async void Avatar_Clicked(object sender, EventArgs e)
    {
        var avatarPage = new AvatarPage(_userViewModel);
        avatarPage.AvatarSelected += (s, selectedImage) =>
        {
            // Установка выбранной картинки в кнопку AvatarButton
            CurrentUser.Avatar = selectedImage;
        };
        await Navigation.PushAsync(avatarPage);
    }

    private void ExplorePage_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//explore");
    }

    private void MainPage_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//main");
    }

    private void CreatePage_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//create");
    }

    private void ProfilePage_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//user");
    }
}

