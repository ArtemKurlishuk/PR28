using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace PR28.Classes.Common
{
    public class Config
    {
        /// <summary>
        /// Строка подключения к базе данных
        /// </summary>
        public static string ConnectionConfig = "server=127.0.0.1;uid=root;pwd=;database=pcClub";
        /// <summary>
        /// Версия MySql сервера при подключении
        /// </summary>
        public static MySqlServerVersion Version = new MySqlServerVersion(new Version(8, 0, 11));
    }
}
