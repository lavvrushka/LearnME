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
        Shell.Current.GoToAsync("//main");
    }

    async void CreateCardButton_Clicked(System.Object sender, System.EventArgs e)
    {
        string answer = CardAnswer.Text;
        string question = CardQuestion.Text;

        //счетчик
        string labelText = CardCountLabel.Text;
        int currentCount = int.Parse(labelText.Substring(labelText.IndexOf(':') + 2));
        currentCount++;
        CardCountLabel.Text = "Card: " + currentCount.ToString();

        cards.Add(new Tuple<string, string>(answer, question));
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

        Shell.Current.GoToAsync("//main");
    }


    async void Color_Clicked(object sender, EventArgs e)
    {
        var action = await DisplayActionSheet("Выбрать цвет", "Отмена", "Ок",  "серый", "оранжевый","голубой", "красный","","");
       
    }

    private void CreateGroupPage_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//create_group");
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