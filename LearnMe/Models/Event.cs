using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Logging;

namespace LearnMe.Models
{
    [Table("Events")]
    public class Event
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Column("Name"), NotNull, Unique]
        public string Name { get; set; }

        [Column("Description"), NotNull]
        public string Description { get; set; }

        [Column("UserId")]
        public int UserId { get; set; }

        public List<EventGroup> EventGroups { get; set; }

        public Event()
        {
            EventGroups = new List<EventGroup>();
        }

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

        public Event(int id, string Name, string Description, int UserId, string AccentColorStartString, string AccentColorEndString)
        {
            this.Id = id;
            this.Name = Name;
            this.Description = Description;
            this.UserId = UserId;
            this.AccentColorEndString = AccentColorEndString;
            this.AccentColorStartString = AccentColorStartString;
        }


        public Event(string Name, string Description, int UserId, string AccentColorStartString, string AccentColorEndString)
        {
            this.Name = Name;
            this.Description = Description;
            this.UserId = UserId;
            this.AccentColorEndString = AccentColorEndString;
            this.AccentColorStartString = AccentColorStartString;
        }
    }

}
