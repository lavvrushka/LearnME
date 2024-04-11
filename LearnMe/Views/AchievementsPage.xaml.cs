using LearnMe.CustomControls;
using System.Collections.ObjectModel;

namespace LearnMe.Views;

public partial class AchievementsPage : ContentPage
{
	public AchievementsPage()
	{
		InitializeComponent();
	}

    async void BackButton_Clicked(System.Object sender, System.EventArgs e)
    {
        Shell.Current.GoToAsync("//user");
    }

}