using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

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

        public List<EventGroup> EventGroups { get; set; }

        public Group()
        {
            EventGroups = new List<EventGroup>();
        }

        [Column("AccentColorStartString")]
        public string AccentColorStartString { get; set; }

        [Column("AccentColorEndString")]
        public string AccentColorEndString { get; set; }

        
        


        public Group(int id, string name, string description, int userId, string accentColorStartString, string accentColorEndString)
        {
            Id = id;
            Name = name;
            Description = description;
            UserId = userId;
            AccentColorStartString = accentColorStartString;
            AccentColorEndString = accentColorEndString;
        }

        public Group(string name, string description, int userId, string accentColorStartString, string accentColorEndString)
        {
            Name = name;
            Description = description;
            UserId = userId;
            AccentColorStartString = accentColorStartString;
            AccentColorEndString = accentColorEndString;
        }
    }
}
