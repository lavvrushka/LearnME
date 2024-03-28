using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearnMe.Models;
using Microsoft.EntityFrameworkCore;
using SQLite;

namespace LearnMe.Data
{
    public class DbContext: Microsoft.EntityFrameworkCore.DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=LearnMeDatabase.db");
        }
        public DbContext()
        {
            Database.EnsureCreated();


            //var user = Users.FirstOrDefault(c => c.Username == "admin");
            //User user = null;
            //if (user == null)
            //{
            //    user = new User
            //    {
            //        Username = "admin",
            //        Password = "0ffe1abd1a08215353c233d6e009613e95eec4253832a761af28ff37ac5a150c",
            //        Email = "admin@admin.com",
            //        Role = Role.ADMIN
            //    };
            //    var dbItem = Users.Add(user);
            //    this.SaveChanges();
            //}
            var admin = new User
            {
                Username = "admin",
                Password = "0ffe1abd1a08215353c233d6e009613e95eec4253832a761af28ff37ac5a150c",
                Email = "forinovegor@gmail.com",
                Role = Role.ADMIN
            };
            Users.Add(admin);
            SaveChanges();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserSession> Sessions { get; set; }
    }
}