using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using SQLite;


namespace LearnMe.Models
{
    [Table("Users")] // Указываем имя таблицы в базе данных SQLite
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
        private string avatar;


        [Column("Avatar")]
        public string Avatar
        {
            get => avatar;
            set
            {
                if (avatar != value)
                {
                    avatar = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
