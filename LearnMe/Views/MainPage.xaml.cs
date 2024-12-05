using LearnMe.Models;
using LearnMe.Service;
using LearnMe.ViewModels;



namespace LearnMe.Views
{
    public partial class MainPage : ContentPage
    {
        private const uint AnimationDuration = 800u;

        private readonly GroupsService _groupsService;
        private readonly CardService _cardService;
        public MainPage(MainViewModel viewModel, GroupsService groupsService, CardService cardService)
        {
            InitializeComponent();
            this.BindingContext = viewModel;
            _groupsService = groupsService;
            _cardService = cardService;
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
                
                int groupId = selectedGroup.Id;
                await Navigation.PushAsync(new GroupDetailsPage(groupId, selectedGroup, _cardService, _groupsService, YouGroups));
            }
        }


        async void GroupDelete_Clicked(object sender, EventArgs e)
        {
            var selectedGroup = (sender as ImageButton).BindingContext as ViewGroup;
            bool result = await DisplayAlert("Confirm Action", "Do you want to delete the item?", "Yes", "No");

            if (result)
            {
                _groupsService.RemoveGroup(selectedGroup.Id);
                _cardService.DeleteCardsByGroupId(selectedGroup.Id);
                await DisplayAlert("Notification", "Group deleted successfully!", "OK");

                RefreshGroupList();
            }
        }

        private void RefreshGroupList()
        {
            var lst = _groupsService.GetCreatedGroups();
            var viewcreategroups = lst.Select(group => new ViewGroup(group)).ToList();
            YouGroups.ItemsSource = viewcreategroups;
        }

        private void ExplorePage_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//explore");
        }

        private void MainPage_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//main");
        }
        private void CreatePage_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//create");
        }
        private void ProfilePage_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//user");
        }
    }
}
