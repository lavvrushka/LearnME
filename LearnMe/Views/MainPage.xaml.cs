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

            //List<ViewGroup> viewdbgroups = new List<ViewGroup>();

            //var dbgroups = _groupsService.GetDbGroups();
            //foreach (var group in dbgroups)
            //{
            //    viewdbgroups.Add(new ViewGroup(group));
            //}

           
            //lstAllGroups.ItemsSource = viewdbgroups;
           

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
        private void ExplorePage_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//explore");
        }

        private void MainPage_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//main");
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
