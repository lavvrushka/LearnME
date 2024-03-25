using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMe.Models
{
    public class Achievement
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Condition { get; set; }
        public DateTime DateAchieved { get; set; }
    }
}
