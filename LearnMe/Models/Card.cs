using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMe.Models
{
    public class Card
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public string Topic { get; set; }
        public DifficultyLevel DifficultyLevel { get; set; }
        public List<Note> Notes { get; set; }
        public DateTime CreationDate { get; set; }

    }
}
