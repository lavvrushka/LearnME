using LearnMe.ViewModels;
namespace LearnMe.Views;

public partial class SignUpPage : ContentPage
{
    public SignUpPage(SignUpViewModel signUpViewModel)
    {
        InitializeComponent();
        BindingContext = signUpViewModel;
    }
}