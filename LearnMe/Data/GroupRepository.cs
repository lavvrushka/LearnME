using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearnMe.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LearnMe.Data
{
    public class GroupRepository
    {
        private readonly DbContext _dbContext;

        public GroupRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int AddGroup(Group group)
        {
            _dbContext.Groups.Add(group);
            _dbContext.SaveChanges();
            return GetGroupByName(group.Name).Id;
        }

        public Group GetGroupByName(string Name)
        {
            return _dbContext.Groups.FirstOrDefault(g => g.Name == Name);
        }

        public List<Group> GetAllGroups()
        {
            return [.. _dbContext.Groups];
        }

        public void DelGroup(int groupid)
        {
            _dbContext.Groups.Remove(_dbContext.Groups.FirstOrDefault(g=>g.Id==groupid));
            _dbContext.SaveChanges();
        }

        public IEnumerable<Group> GetCreatedGroups()
        {
            foreach (Group group in _dbContext.Groups)
            {
                if (group.UserId == LearnMe.Utils.AppContext.CurrentUser.Id)
                {
                    yield return group;
                }
            }
        }

        public void UpdateGroup(Group group)
        {
            // Detach the entity if it's already being tracked
            var existingEntity = _dbContext.Groups.Local.FirstOrDefault(e => e.Id == group.Id);
            if (existingEntity != null)
            {
                _dbContext.Entry(existingEntity).State = EntityState.Detached;
            }

            // Attach the entity and set its state to Modified
            _dbContext.Groups.Attach(group);
            _dbContext.Entry(group).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }


        public List<Group> GetGroupByEventId(int id)
        {
            var eventGroups = _dbContext.EventGroups.Where(eg => eg.EventId == id).ToList();
            var groupIds = eventGroups.Select(eg => eg.GroupId).ToList();
            var groups = _dbContext.Groups.Where(g => groupIds.Contains(g.Id)).ToList();
            return groups;
        }
    }
}
