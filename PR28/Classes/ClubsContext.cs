using System;
using System.Collections.Generic;
using System.Text;
using PR28.Classes.Common;
using PR28.Models;
using Microsoft.EntityFrameworkCore;


namespace PR28.Classes
{
    public class ClubsContext : DbContext
    {
        /// <summary>
        /// Данные из БД
        /// </summary>
        public DbSet<Clubs> Clubs { get; set; }
        /// <summary>
        /// Констурктор для контекста
        /// </summary>
        public ClubsContext() =>
            //Проверяем создано ли покдлючение, если не создано, создаём
            Database.EnsureCreated();
        /// <summary>
        /// Переотпределённый метод конфигурнации
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            //Говорим что используем подключение MySql, со следующими настройками из Config
            optionsBuilder.UseMySql(Config.ConnectionConfig, Config.Version);
    }
}
