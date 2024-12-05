namespace LearnMe.Views;

public partial class CreatePage : ContentPage
{
	public CreatePage()
	{
		InitializeComponent();

    }
    

    async void CreateGroup_Clicked(System.Object sender, System.EventArgs e)
    {
        await Shell.Current.GoToAsync("//create_group");
    }

    async void CreateEvent_Clicked(System.Object sender, System.EventArgs e)
    {
        await Shell.Current.GoToAsync("//create_event");
    }
    private void CreatePage_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//create");
    }
    private void ProfilePage_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//user");
    }

    private void MainPage_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//main");
    }

    private void ExplorePage_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//explore");
    }
}