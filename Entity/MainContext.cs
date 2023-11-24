using LiteMassenger.Entity.Model;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LiteMassenger.Entity 
{
    public class MainContext:DbContext
    {
        private readonly string _connectionString = @"Data Source=192.168.221.12;Initial Catalog = LiteMassegerZT; User ID = user02; Password=02;TrustServerCertificate=True";
        private readonly string _connectionStringHome = @"Data Source=DESKTOP-RF9II86;Initial Catalog=LiteMassegerZT;Integrated Security=True;TrustServerCertificate=True";

        public DbSet<Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }

        public MainContext() {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
           
            
        }   

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionStringHome);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasData(
                new User[]
                {
                    new User { Id = 1,Name="Petrov", Email="Petrov@yandex.ru", Password="petrov1965"},
                    new User { Id = 2,Name="Perdunov", Email="Perdunov@yohoo.ru", Password="perdunov1978"}
                }
                );
            modelBuilder.Entity<Task>().HasData(
                new Task[]
                {
                    new Task{Id=1, Title = "Поесть", Description="Обед в 12 часов", Priority="Высокий", Status=1,DateTime=DateTime.Now,UserId=1},
                    new Task{Id=2,Title = "Поспать", Description="Поспать После Обеда", Priority="Высокий", Status=0,DateTime=DateTime.Now, UserId=2}
                }
                );
            
                
        }

    }
}
