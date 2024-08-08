using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PR28.Models;
using PR28.Classes.Common;

namespace PR28.Classes
{
    public class UserContext : DbContext
    {
        /// <summary>
        /// Данные о пльзователях из БД
        /// </summary>
        public DbSet<Users> Users { get; set; }
        public UserContext() =>
            Database.EnsureCreated();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseMySql(Config.ConnectionConfig, Config.Version);
    }
}
