using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace LearnMe.Models
{
    [Table("Sessions")]
    public class UserSession
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Column("Token")]
        public string Token { get; set; }
        [Column("Expiration")]
        public DateTime Expiration { get; set; }
        [Column("UserId")]
        public int UserId { get; set; }
    }
}
