using LearnMe.ViewModels;

namespace LearnMe.Views;


public partial class AuthenticationPage : ContentPage
{
    private readonly AuthenticationViewModel _viewModel;

    public AuthenticationPage(AuthenticationViewModel viewModel)
	{
        _viewModel = viewModel;
        InitializeComponent();
        BindingContext = viewModel;

    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();


        if (this.AnimationIsRunning("TransitionAnimation"))
            return;

        var parentAnimation = new Animation();

        //Planets Animation
        parentAnimation.Add(0, 0.2, new Animation(v => imgMercury.Opacity = v, 0, 1, Easing.CubicIn));
        parentAnimation.Add(0.1, 0.3, new Animation(v => imgVenus.Opacity = v, 0, 1, Easing.CubicIn));
        parentAnimation.Add(0.2, 0.4, new Animation(v => imgEarth.Opacity = v, 0, 1, Easing.CubicIn));
        parentAnimation.Add(0.3, 0.5, new Animation(v => imgMars.Opacity = v, 0, 1, Easing.CubicIn));
        parentAnimation.Add(0.4, 0.6, new Animation(v => imgJupiter.Opacity = v, 0, 1, Easing.CubicIn));
        parentAnimation.Add(0.5, 0.7, new Animation(v => imgSaturn.Opacity = v, 0, 1, Easing.CubicIn));
        parentAnimation.Add(0.6, 0.8, new Animation(v => imgNeptune.Opacity = v, 0, 1, Easing.CubicIn));
        parentAnimation.Add(0.7, 0.9, new Animation(v => imgUranus.Opacity = v, 0, 1, Easing.CubicIn));

        parentAnimation.Add(0.8000, 1.0, new Animation(v => imgMee.Opacity = v, 0, 1, Easing.CubicIn));
        parentAnimation.Add(0.8000, 1.0, new Animation(v => frmIntro.Opacity = v, 0, 1, Easing.CubicIn));

        //Commit the animation
        parentAnimation.Commit(this, "TransitionAnimation", 16, 2500, null, null);


        if (_viewModel.isLoggedIn())
        {
            await Task.Delay(5);
            await Shell.Current.GoToAsync("//home/main");
            Shell.Current.FlyoutBehavior = FlyoutBehavior.Flyout;
        }
   
}


}