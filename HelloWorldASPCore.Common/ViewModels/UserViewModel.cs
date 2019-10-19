using System;
using System.Collections.Generic;
using HelloWorldASPCore.Common.Models;
using System.Text;

namespace HelloWorldASPCore.Common.ViewModels
{
    public class UserViewModel
    {
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
        /// констпуктор копирования
        /// </summary>
        public UserViewModel(UserModel userModel)
        {
            UserName = userModel.UserName;
            UserSecName = userModel.UserSecName;
            UserEmail = userModel.UserEmail;
        }

    }
}
