using LearnMe.ViewModels;
using LearnMe.Models;

namespace LearnMe.Views;

public partial class CreateGroupPage : ContentPage
{
    private readonly CreateGroupViewModel _viewModel;
    private readonly CreateCardViewModel _createCardViewModel;
    private List<Tuple<string, string>> cards = new();

    public CreateGroupPage(CreateGroupViewModel viewModel, CreateCardViewModel createCardViewModel)
    {
        _viewModel = viewModel;
        InitializeComponent();
        BindingContext = viewModel;
        _createCardViewModel = createCardViewModel;
    }

    async void BackButton_Clicked(System.Object sender, System.EventArgs e)
    {
        await Shell.Current.GoToAsync("//main");
    }

    async void CreateCardButton_Clicked(System.Object sender, System.EventArgs e)
    {
        string answer = CardAnswer.Text;
        string question = CardQuestion.Text;

        // Increment card counter
        string labelText = CardCountLabel.Text;
        int currentCount = int.Parse(labelText.Substring(labelText.IndexOf(':') + 2));
        currentCount++;
        CardCountLabel.Text = "Card: " + currentCount.ToString();

        cards.Add(new Tuple<string, string>(answer, question));

        // Clear input fields
        CardAnswer.Text = string.Empty;
        CardQuestion.Text = string.Empty;
    }

    private void SaveGroup_Clicked(object sender, EventArgs e)
    {
        string name = NameGroupEntry.Text;
        string description = DescriptionGroupEntry.Text;
        int groupId = _viewModel.AddGroup(name, description);

        foreach (var card in cards)
        {
            _createCardViewModel.AddCard(groupId, card.Item1, card.Item2);
        }

        // Reset card counter and clear fields
        CardCountLabel.Text = "Card: 0";
        NameGroupEntry.Text = string.Empty;
        DescriptionGroupEntry.Text = string.Empty;
        CardAnswer.Text = string.Empty;
        CardQuestion.Text = string.Empty;
        cards.Clear();

        Shell.Current.GoToAsync("//main");
    }

    async void Color_Clicked(object sender, EventArgs e)
    {
        var action = await DisplayActionSheet("Выбрать цвет", "Отмена", "Ок", "серый", "оранжевый", "голубой", "красный", "", "");
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
