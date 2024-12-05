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
using LearnMe.Models;
using LearnMe.Utils;

namespace LearnMe.ViewModels
{

        public partial class CreateEventViewModel
        {
            private readonly EventService _eventService;
            private readonly UserSessionRepository _userSessionRepository;


            public CreateEventViewModel(EventService eventService)
            {
            _eventService = eventService;
            }

            //public int AddGroup(string name, string description)
            //{
            //    int userid = LearnMe.Utils.AppContext.CurrentUser.Id;
            //    return _groupsService.AddGroup(new Models.Group { 
            //        Name = name, 
            //        Description = description, 
            //        UserId=userid, 
            //        AccentColorEndString = "#c6502f", 
            //        AccentColorStartString= "#996237" });   

            //}

            public int AddEvent(string name, string description)
            {
                int userid = LearnMe.Utils.AppContext.CurrentUser.Id;
                return _eventService.AddEvent(new Models.Event(name, description, userid, "#353535", "#8d9098"));

            }
        }
    
}
