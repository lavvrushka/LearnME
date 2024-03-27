using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMe.Models
{
    [Table("Achievement")]
    public class Achievement
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Column("Name"), NotNull, Unique]
        public string Name { get; set; }

        [Column("Name"), NotNull, Unique]
        public string Condition { get; set; }
        public DateTime DateAchieved { get; set; }

    }
}
