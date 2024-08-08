using System;
using System.Collections.Generic;
using System.Text;

namespace PR28.Models
{
    public class Users
    {
        /// <summary>
        /// Код пользователя
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Фамилия имя отчество
        /// </summary>
        public string FIO { get; set; }
        /// <summary>
        /// Дата аренды
        /// </summary>
        public DateTime RentStart { get; set; }
        /// <summary>
        /// Продолжительность аренды
        /// </summary>
        public int Duration { get; set; }
        /// <summary>
        /// Код клуба
        /// </summary>
        public int IdClub { get; set; }
    }
}
