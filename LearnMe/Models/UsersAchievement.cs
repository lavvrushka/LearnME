using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMe.Models
{
    [Table("UsersAchievement")]
    public class UsersAchievement
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Column("AchievementId")]
        public int AchievementId { get; set; }

        [Column("UserId")]
        public int UserId { get; set; }
    }
}
