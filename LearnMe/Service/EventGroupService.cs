using LearnMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearnMe.Data;

namespace LearnMe.Service
{
    public class EventGroupService
    {
        private readonly EventGroupRepository _eventgroupRepository;

        public EventGroupService(EventGroupRepository eventgroupRepository)
        {
            _eventgroupRepository = eventgroupRepository;
        }
        public List<Group> GetGroupsByEventId(int eventId)
        => _eventgroupRepository.GetGroupsByEventId(eventId).ToList();

        public void AddEventGroup(EventGroup eventgroup)
        {
            _eventgroupRepository.AddEventGroup(eventgroup);
        }
    }
}

