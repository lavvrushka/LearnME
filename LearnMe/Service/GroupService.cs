using LearnMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearnMe.Data;

namespace LearnMe.Service
{
    public class GroupsService
    {
        private readonly GroupRepository _groupRepository;

        public GroupsService(GroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        private static List<Group> groups = new(){ };

        public List<Group> GetDbGroups()
            => _groupRepository.GetAllGroups();

        public Group GetGroup(string groupName)
            => groups.Where(_group => _group.Name == groupName).FirstOrDefault();

        public List<Group> GetCreatedGroups()
        {
            return _groupRepository.GetCreatedGroups().ToList();
        }

        public int AddGroup(Group group)
        {
            return _groupRepository.AddGroup(group);
        }

        public void RemoveGroup(int groupid) {
          _groupRepository.DelGroup(groupid);
        }
        public void UpdateGroup(Group group)
        {
            _groupRepository.UpdateGroup(group);
        }


        public List<Group> GetGroupsByEventId(int eventId)
    => _groupRepository.GetGroupByEventId(eventId).ToList();
    }
}
