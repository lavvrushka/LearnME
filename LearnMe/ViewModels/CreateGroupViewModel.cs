using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LearnMe.Data;
using LearnMe.Service;
using LearnMe.Utils;


namespace LearnMe.ViewModels
{
    public partial class CreateGroupViewModel
    {
        private readonly GroupsService _groupsService;
        private readonly UserSessionRepository _userSessionRepository;


        public CreateGroupViewModel(GroupsService groupsService)
        {
            _groupsService = groupsService;
        }

        public int AddGroup(string name, string description)
        {
            int userid = LearnMe.Utils.AppContext.CurrentUser.Id;
           return _groupsService.AddGroup(new Models.Group { Name = name, Description = description, UserId=userid, AccentColorEndString = "#c6502f", AccentColorStartString= "#996237" });   


        }
    }
}
