using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMe.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }



        public int UserId { get; set; }
        public User User { get; set; }

    }
}
