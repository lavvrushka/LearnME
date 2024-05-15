using LearnMe.Models;
using LearnMe.Service;
using LearnMe.ViewModels;


namespace LearnMe.Views
{
    public partial class UserGroupsPage : ContentPage
    {

        private readonly GroupsService _groupsService;
        private readonly CardService _cardService;
        public UserGroupsPage(GroupsService groupsService, CardService cardService)
        {
            InitializeComponent();
            _groupsService = groupsService;
            _cardService = cardService;
        }

        async void BackButton_Clicked(System.Object sender, System.EventArgs e)
        {
            Shell.Current.GoToAsync("//user");
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();


            List<ViewGroup> viewcreategroups = new List<ViewGroup>();

            var lst = _groupsService.GetCreatedGroups();
            foreach (var group in lst)
            {
                viewcreategroups.Add(new ViewGroup(group));
            }
            YouGroups.ItemsSource = viewcreategroups;

        }
        async void Groups_SelectionChanged(System.Object sender, Microsoft.Maui.Controls.SelectionChangedEventArgs e)
        {
            var selectedGroup = e.CurrentSelection.FirstOrDefault() as ViewGroup;
            if (selectedGroup != null)
            {
                // Предполагая, что у вас есть доступ к ID группы из объекта ViewGroup
                int groupId = selectedGroup.Id;
                await Navigation.PushAsync(new GroupDetailsPage(groupId, selectedGroup, _cardService));
            }
        }
        async void GroupDelete_Clicked(object sender, EventArgs e)
        {
            bool result = await DisplayAlert("Confirm Action", "Do you want to delete the item?", "Yes", "No");
            await DisplayAlert("Notification", "You chose: " + (result ? "Delete" : "Cancel"), "OK");
        }
    }
}