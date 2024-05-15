using LearnMe.Models;
using LearnMe.Service;
namespace LearnMe.Views;

public partial class GroupDetailsPage : ContentPage
{
    private readonly CardService _cardService;
    private readonly int _groupId;
    public GroupDetailsPage(int groupId, ViewGroup viewgroup, CardService cardService)
    {
        InitializeComponent();
        this.BindingContext = viewgroup;
        _cardService= cardService;
        _groupId = groupId;
    }

    async void BackButton_Clicked(System.Object sender, System.EventArgs e)
    {
        await Navigation.PopAsync();
    }

    async void GroupDelete_Clicked(object sender, EventArgs e)
    {
        bool result = await DisplayAlert("Confirm Action", "Do you want to delete the item?", "Yes", "No");
        await DisplayAlert("Notification", "You chose: " + (result ? "Delete" : "Cancel"), "OK");
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        List<Card> groupcards = new List<Card>();

        var dbgroupcards = _cardService.GetCardByGroupId(_groupId);
        foreach (var card in dbgroupcards)
        {
            groupcards.Add(card);
        }


        Cards.ItemsSource = groupcards;
    }


    async void CreateCardButton_Clicked(System.Object sender, System.EventArgs e)
    {
        await Navigation.PopAsync();
    }

    //Режимы
    async void Flip_Cards_Clicked(System.Object sender, System.EventArgs e)
    {
        await Navigation.PopAsync();
    }
    async void Memorization_Clicked(System.Object sender, System.EventArgs e)
    {
        await Navigation.PopAsync();
    }

    async void Blitz_Clicked(object sender, EventArgs e)
    {
        var blitzPage = new BlitzPage(this); 
        await Navigation.PushAsync(blitzPage);
    }
}