using System;
using System.Collections.Generic;
using System.Linq;
using LearnMe.Models;
using LearnMe.Service;

namespace LearnMe.Views
{
    public partial class EventDetailsPage : ContentPage
    {
        private readonly EventService _eventService;
        private readonly GroupsService _groupService;
        private readonly int _eventId;
        private readonly CollectionView _youevents;

        public EventDetailsPage(int eventId, ViewEvent viewevent, EventService eventService, GroupsService groupService, CollectionView youevents)
        {
            InitializeComponent();
            BindingContext = viewevent;
            _eventService = eventService;
            _eventId = eventId;
            _groupService = groupService;
            _youevents = youevents;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            RefreshGroupsList();

        }

        private void RefreshGroupsList()
        {
            var eventGroups = _groupService.GetGroupsByEventId(_eventId).ToList();
            EventGroup.ItemsSource = eventGroups;
        }
        async void BackButton_Clicked(System.Object sender, System.EventArgs e)
        {
            Shell.Current.GoToAsync("//user_events");
        }

        async void Events_SelectionChanged(System.Object sender, Microsoft.Maui.Controls.SelectionChangedEventArgs e)
        {
            var selectedEvent = e.CurrentSelection.FirstOrDefault() as ViewEvent ;
            if (selectedEvent != null)
            {
                // Предполагая, что у вас есть доступ к ID группы из объекта ViewGroup
                int eventId = selectedEvent.Id;
                await Navigation.PushAsync(new EventDetailsPage(eventId, selectedEvent, _eventService, _groupService, new CollectionView()));
            }
        }
    }
}
