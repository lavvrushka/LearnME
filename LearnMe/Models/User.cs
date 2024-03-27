using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;


namespace LearnMe.Models
{
    [Table("User")] // Указываем имя таблицы в базе данных SQLite
    public class User
    {
        [PrimaryKey, AutoIncrement] // Указываем, что поле Id является первичным ключом и автоматически генерируемым
        public int Id { get; set; }

        [Column("Username"), NotNull, Unique]
        public string Username { get; set; }

        [Column("Password"), NotNull, Unique]
        public string Password { get; set; }

        [Column("Email"), NotNull, Unique]
        public string Email { get; set; }


        [Column("Role")] // Указываем имя поля, которое будет использоваться для связи с таблицей Role
        [EnumDataType(typeof(Role))]
        public Role Role { get; set; }

       
    }
}
