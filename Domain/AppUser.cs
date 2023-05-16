using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain
{
    /// <summary>
    /// Класс пользователя
    /// </summary>
    public class AppUser
    {
        /// <summary>
        /// Key
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Email пользователя
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Адресс пользователя
        /// </summary>
        public string? Address { get; set; }

        [JsonIgnore]
        /// <summary>
        /// Хэш пароль пользователя
        /// </summary>
        public string PasswordHash { get; set; }
    }
}
