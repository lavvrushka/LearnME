using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearnMe.Models;

namespace LearnMe.Utils
{ 
    public static class AppContext
    {
        public static User CurrentUser { get; set; }
    }
}
