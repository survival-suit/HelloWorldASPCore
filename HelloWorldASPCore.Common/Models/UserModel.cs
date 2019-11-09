using System;
using System.ComponentModel.DataAnnotations;

namespace HelloWorldASPCore.Common.Models
{
    public class UserModel

    {
        /// <summary>
        /// GUID
        /// </summary>
        [Key]
        public Guid UserGuid { get; set; }

        /// <summary>
        /// имя
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// фамилия
        /// </summary>
        public string UserSecName { get; set; }

        /// <summary>
        /// емейл
        /// </summary>
        public string UserEmail { get; set; }

        /// <summary>
        /// пароль
        /// </summary>
        public string UserPassword { get; set; }

        public UserModel()
        {
            UserGuid = Guid.NewGuid();
        }

    }
}
