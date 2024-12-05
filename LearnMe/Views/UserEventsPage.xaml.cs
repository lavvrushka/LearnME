using LearnMe.Models;
using LearnMe.Service;
using LearnMe.ViewModels;


namespace LearnMe.Views
{
    public partial class UserEventsPage : ContentPage
    {

        private readonly GroupsService _groupsService;
        private readonly EventService _eventService;
        public UserEventsPage(GroupsService groupsService, EventService eventService)
        {
            InitializeComponent();
            _groupsService = groupsService;
            _eventService = eventService;
        }

        async void BackButton_Clicked(System.Object sender, System.EventArgs e)
        {
            Shell.Current.GoToAsync("//user");
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();


            List<ViewEvent> viewcreateevents = new List<ViewEvent>();

            var lst = _eventService.GetCreatedEvents();
            foreach (var _event in lst)
            {
                viewcreateevents.Add(new ViewEvent(_event));
            }
            Youevents.ItemsSource = viewcreateevents;

        }
        async void Events_SelectionChanged(System.Object sender, Microsoft.Maui.Controls.SelectionChangedEventArgs e)
        {
            var selectedEvent = e.CurrentSelection.FirstOrDefault() as ViewEvent;
            if (selectedEvent != null)
            {
                // Предполагая, что у вас есть доступ к ID группы из объекта ViewGroup
                int eventId = selectedEvent.Id;
                await Navigation.PushAsync(new EventDetailsPage(eventId, selectedEvent,  _eventService, _groupsService, Youevents));
            }
        }

        
    }
}