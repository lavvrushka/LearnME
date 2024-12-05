using LearnMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearnMe.Data;
using System.Text.RegularExpressions;


namespace LearnMe.Service
{
    public class EventService
    {
        private readonly EventRepository _eventRepository;

        public EventService(EventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        private static List<Event> _events = new() { };
        public List<Event> GetDbEvents()
          => _eventRepository.GetAllEvents();

        public Event GetEvent(string eventName)
            => _events.Where(_event => _event.Name == eventName).FirstOrDefault();

        public List<Event> GetCreatedEvents()
        {
            return _eventRepository.GetCreatedEvents().ToList();
        }

        public int AddEvent(Event _event)
        {
            return _eventRepository.AddEvent(_event);
        }

        public void RemoveEvent(int eventid)
        {
            _eventRepository.DelEvent(eventid);
        }
        public void UpdateEvent(Event _event)
        {
            _eventRepository.UpdateEvent(_event);
        }
    }
}
