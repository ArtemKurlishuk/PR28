using System;
using System.Collections.Generic;
using System.Text;

namespace PR28.Models
{
    public class Clubs
    {
        /// <summary>
        /// Код
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Адрес
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Время работы
        /// </summary>
        public string WorkTime { get; set; }
    }
}
