using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMe.Models
{
    public class AchievementsDatePicker
    {
        public DateTime Date { get; set; }
        public bool IsToday { get; set; }

        public Color BackgroundColor => IsToday ? Color.FromHex("#eb5757") : Color.FromHex("#FFFFFF");
    }
}
 
