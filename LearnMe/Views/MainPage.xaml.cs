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

        async void ProfilePic_Clicked(System.Object sender, System.EventArgs e)
        {
            // Reveal our menu and move the main content out of the view
            _ = MainContentGrid.TranslateTo(-this.Width * 0.5, this.Height * 0.1, AnimationDuration, Easing.CubicIn);
            await MainContentGrid.ScaleTo(0.8, AnimationDuration);
            _ = MainContentGrid.FadeTo(0.8, AnimationDuration);
        }

        async void GridArea_Tapped(System.Object sender, System.EventArgs e)
        {
            await CloseMenu();
        }

        private async Task CloseMenu()
        {
            //Close the menu and bring back back the main content
            _ = MainContentGrid.FadeTo(1, AnimationDuration);
            _ = MainContentGrid.ScaleTo(1, AnimationDuration);
            await MainContentGrid.TranslateTo(0, 0, AnimationDuration, Easing.CubicIn);
        }
    }

}
