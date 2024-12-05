using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMe.Models
{
    [Table("Cards")]
    public class Card
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Column("Question"), NotNull, Unique]
        public string Question { get; set; }

        [Column("Answer"), NotNull, Unique]
        public string Answer { get; set; }

        [Column("DifficultyLevel")]
        [EnumDataType(typeof(DifficultyLevel))]
        public DifficultyLevel DifficultyLevel { get; set; }
        public DateTime CreationDate { get; set; }

        [Column("GroupId")]
        public int GroupId { get; set; }

    }
}
