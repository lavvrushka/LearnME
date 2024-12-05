using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearnMe.Models;
using Microsoft.EntityFrameworkCore;

namespace LearnMe.Data
{


    public class EventGroupRepository
    {
        private readonly DbContext _dbContext;
        public EventGroupRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Group> GetGroupsByEventId(int eventId)
        {
            var eventGroups = _dbContext.EventGroups.Where(eg => eg.Id == eventId).ToList();
            var groupIds = eventGroups.Select(eg => eg.Id).ToList();
            var groups = _dbContext.Groups.Where(g => groupIds.Contains(g.Id)).ToList();
            return groups;
        }

        public void AddEventGroup(EventGroup eventgroups) {
            _dbContext.EventGroups.Add(eventgroups);
            _dbContext.SaveChanges();
        }

    }
}
