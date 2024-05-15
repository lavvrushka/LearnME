using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearnMe.Models;

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

        public void DelGroup(Group group)
        {
            _dbContext.Groups.Remove(group);
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

    }
}
