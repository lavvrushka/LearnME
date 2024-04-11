namespace LearnMe.Views;

public partial class AvatarPage : ContentPage
{
	public AvatarPage()
	{
		InitializeComponent();
	}
    async void BackButton_Clicked(System.Object sender, System.EventArgs e)
    {
        Shell.Current.GoToAsync("//user");
    }

    public event EventHandler<string> AvatarSelected;

    private void RadioButton_Clicked(object sender, EventArgs e)
    {
        var radioButton = (RadioButton)sender;
        string selectedImage = (radioButton.Content as StackLayout).Children.OfType<Image>().FirstOrDefault()?.Source.ToString();
        AvatarSelected?.Invoke(this, selectedImage);
    }

}