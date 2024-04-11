using LearnMe.Models;
using LearnMe.Service;
using LearnMe.ViewModels;


namespace LearnMe.Views
{
    public partial class MainPage : ContentPage
    {
        private const uint AnimationDuration = 800u;
        public MainPage(MainViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            lstPopularGroups.ItemsSource = GroupsService.GetFeaturedGroups();
            lstAllGroups.ItemsSource = GroupsService.GetAllGroups();
        }

        async void Groups_SelectionChanged(System.Object sender, Microsoft.Maui.Controls.SelectionChangedEventArgs e)
        {
            await Navigation.PushAsync(new GroupDetailsPage(e.CurrentSelection.First() as Group));
        }

        private void ExplorePage_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//explore");
        }

        private void CreateGroupPage_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//create_group");
        }
        private void ProfilePage_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//user");
        }

    }

}
