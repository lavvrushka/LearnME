using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LearnMe.Models
{
    [Table("Groups")]
    public class Group
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Column("Name"), NotNull, Unique]
        public string Name { get; set; }

        [Column("Description"), NotNull]
        public string Description { get; set; }

        [Column("UserId")]
        public int UserId { get; set; }

        [Column("AccentColorStartString")]
        public string AccentColorStartString
        {
            get;
            set;
        }

        [Column("AccentColorEndString")]
        public string AccentColorEndString
        {
            get;
            set;
        }





       
    }
}
