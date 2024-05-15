using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearnMe.Models;
using Microsoft.EntityFrameworkCore;
using SQLite;
using LearnMe.Utils;

namespace LearnMe.Data
{
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlite("Filename=LearnMeDatabase.db");
            string connectionDb = $"Filename={PathDb.GetPath("learnme.db")}";
            optionsBuilder.UseSqlite(connectionDb);
        }
        public DbContext(DbContextOptions<DbContext> options) : base(options) 
        {
            Database.EnsureCreated();

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1, // Указываем отрицательное значение для Id
                Username = "admin",
                Password = "0ffe1abd1a08215353c233d6e009613e95eec4253832a761af28ff37ac5a150c",
                Email = "forinovegor@gmail.com",
                Role = Role.ADMIN
            });

            modelBuilder.Entity<Group>().ToTable("Groups");
            modelBuilder.Entity<UserSession>().ToTable("Sessions");
            modelBuilder.Entity<Card>().ToTable("Cards");
            modelBuilder.Entity<User>().ToTable("Users");

        }


        public DbSet<User> Users { get; set; }
        public DbSet<UserSession> Sessions { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Card> Cards { get; set; }
    }
}