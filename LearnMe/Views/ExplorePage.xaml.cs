using LearnMe.ViewModels;
namespace LearnMe.Views;
using LearnMe.Models;
using LearnMe.Service;


public partial class ExplorePage : ContentPage
{
    private readonly GroupsService _groupsService;
    private readonly CardService _cardService;
    public ExplorePage(ExploreViewModel viewModel, CardService cardService, GroupsService groupsService)
	{
		InitializeComponent();
        BindingContext = viewModel;
        _groupsService = groupsService;
        _cardService = cardService;
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

    async void Groups_SelectionChanged(System.Object sender, Microsoft.Maui.Controls.SelectionChangedEventArgs e)
    {
        var selectedGroup = e.CurrentSelection.FirstOrDefault() as ViewGroup;
        if (selectedGroup != null)
        {
            // Предполагая, что у вас есть доступ к ID группы из объекта ViewGroup
            int groupId = selectedGroup.Id;
            await Navigation.PushAsync(new GroupDetailsPage(groupId, selectedGroup, _cardService, _groupsService, new CollectionView()));
        }
    }
    async void GroupDelete_Clicked(object sender, EventArgs e)
    {
        bool result = await DisplayAlert("Confirm Action", "Do you want to delete the item?", "Yes", "No");
        await DisplayAlert("Notification", "You chose: " + (result ? "Delete" : "Cancel"), "OK");
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();


        List<ViewGroup> viewdbgroups = new List<ViewGroup>();

        var dbgroups = _groupsService.GetDbGroups();
        foreach (var group in dbgroups)
        {
            viewdbgroups.Add(new ViewGroup(group));
        }


        lstAllGroups.ItemsSource = viewdbgroups;

    }
}