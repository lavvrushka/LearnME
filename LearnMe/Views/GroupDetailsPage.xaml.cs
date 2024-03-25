using LearnMe.Models;

namespace LearnMe.Views;

public partial class GroupDetailsPage : ContentPage
{
    public GroupDetailsPage(Group group)
    {
        InitializeComponent();

        this.BindingContext = group;
    }

    async void BackButton_Clicked(System.Object sender, System.EventArgs e)
    {
        await Navigation.PopAsync();
    }
}