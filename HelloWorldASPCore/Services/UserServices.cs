using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorldASPCore.Common.UserModels;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace HelloWorldASPCore.Services
{
    public class UserServices
    {
        //Добавить юзера
        public static string PushUser( List<UserModel> userListModel, UserModel userModel)
        {
            //var userListModel = new List<UserModel>();
            /*
            var userModel = new UserModel
            {
                UserName = userName,
                UserSecName = userSecName,
                UserEmail = userEmail,
                UserPassword = userPassword
            };
            */
            userListModel.Add(userModel);

            return "User scssfl added";
        }

        //Удалить юзера
        public static string PopUser( List<UserModel> listUser, UserModel userModel)
        {
            listUser.Remove(userModel);
            return "User scssfl deleted";
        }

        //Показать весь список юзеров
        public static List<UserModel> ShowAllUsers(List<UserModel> listUser)
        {
            return listUser;
        }





    }
}
