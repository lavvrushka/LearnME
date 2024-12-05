using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearnMe.Models;
using Microsoft.EntityFrameworkCore;

namespace LearnMe.Data
{
    public class EventRepository
    {


        private readonly DbContext _dbContext;

        public EventRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int AddEvent(Event _event)
        {
            _dbContext.Events.Add(_event);
            _dbContext.SaveChanges();
            return GetEventByName(_event.Name).Id;
        }

        public Event GetEventByName(string Name)
        {
            return _dbContext.Events.FirstOrDefault(g => g.Name == Name);
        }

        public List<Event> GetAllEvents()
        {
            return [.. _dbContext.Events];
        }

        public void DelEvent(int groupid)
        {
            _dbContext.Events.Remove(_dbContext.Events.FirstOrDefault(g => g.Id == groupid));
            _dbContext.SaveChanges();
        }

        public IEnumerable<Event> GetCreatedEvents()
        {
            foreach (Event _event in _dbContext.Events)
            {
                if (_event.UserId == LearnMe.Utils.AppContext.CurrentUser.Id)
                {
                    yield return _event;
                }
            }
        }

        public void UpdateEvent(Event _event)
        { 
            // Detach the entity if it's already being tracked
            var existingEntity = _dbContext.Events.Local.FirstOrDefault(e => e.Id == _event.Id);
            if (existingEntity != null)
            {
                _dbContext.Entry(existingEntity).State = EntityState.Detached;
            }

            // Attach the entity and set its state to Modified
            _dbContext.Events.Attach(_event);
            _dbContext.Entry(_event).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
