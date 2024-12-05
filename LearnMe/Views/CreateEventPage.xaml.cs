using LearnMe.ViewModels;
using LearnMe.Models;
using LearnMe.Service;

namespace LearnMe.Views
{
    public partial class CreateEventPage : ContentPage
    {
        private readonly GroupsService _groupsService;
        private readonly EventGroupService _eventgroupService;
        private readonly CardService _cardService;
        private readonly CreateEventViewModel _viewModel;
        List<ViewGroup> viewdbgroups;

        public CreateEventPage(CreateEventViewModel viewModel, CardService cardService, GroupsService groupsService, EventGroupService eventgroupService)
        {
            InitializeComponent();
            _groupsService = groupsService;
            _cardService = cardService;
            _viewModel = viewModel;
            _eventgroupService= eventgroupService;
        }

        async void Groups_SelectionChanged(System.Object sender, Microsoft.Maui.Controls.SelectionChangedEventArgs e)
        {
            var selectedGroup = e.CurrentSelection.FirstOrDefault() as ViewGroup;
            if (selectedGroup != null)
            {
                int groupId = selectedGroup.Id;
                await Navigation.PushAsync(new GroupDetailsPage(groupId, selectedGroup, _cardService, _groupsService, new CollectionView()));
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewdbgroups = new List<ViewGroup>();
            var dbgroups = _groupsService.GetDbGroups();

            foreach (var group in dbgroups)
            {
                viewdbgroups.Add(new ViewGroup(group));
            }

            AllGroups.ItemsSource = viewdbgroups;
        }

        private void SaveEvent_Clicked(object sender, EventArgs e)
        {
            string name = EventEntry.Text;
            string description = DEventEntry.Text;
            int eventId = _viewModel.AddEvent(name, description);

            foreach (var viewGroup in viewdbgroups)
            {
                if (viewGroup.IsChecked)
                {
                    _eventgroupService.AddEventGroup(new EventGroup(eventId,viewGroup.Id));
                    viewGroup.EventId = eventId;
                    _groupsService.UpdateGroup(new Group(viewGroup.Id, viewGroup.Name, viewGroup.Description, viewGroup.UserId, viewGroup.AccentColorStart.ToHex(), viewGroup.AccentColorEnd.ToHex()));
                }
            }
            EventEntry.Text = string.Empty;
            DEventEntry.Text = string.Empty;
            Shell.Current.GoToAsync("//create");
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
}
