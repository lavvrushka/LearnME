using LearnMe.Models;
using LearnMe.Service;

namespace LearnMe.Views
{
    public partial class MainPage : ContentPage
    {
        private const uint AnimationDuration = 800u;
        public MainPage()
        {
            InitializeComponent();
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

    }

}
