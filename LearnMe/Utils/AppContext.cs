using LearnMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMe.Utils
{
    public static class AppContext
    {
        public static User CurrentUser { get; set; }
    }
}
