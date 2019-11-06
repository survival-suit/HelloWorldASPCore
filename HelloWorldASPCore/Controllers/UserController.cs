using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HelloWorldASPCore.Common.Models;
using HelloWorldASPCore.Common.Context;
using HelloWorldASPCore.Common.ViewModels;
using HelloWorldASPCore.Common.Services;
using HelloWorldASPCore.Common.RequestModels;
using System.Linq;

namespace HelloWorldASPCore.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger _logger;

        //Ты объявил переменную, но она никак не была создана, но в данном случае надо через юзинг каждый раз делать
        //Вероятно ты немного запутался в DI и после обявления думал что она как то создаться, но как то создается через конструторы
        //private DataBaseMemory _dataBaseMemory;

        public UserController(ILogger<UserController> logger, DataBaseMemory dataBaseMemory)
        {
            _logger = logger;
            //_dataBaseMemory = dataBaseMemory;
        }


        [HttpPost]
        [Route("User/AddUser")]
        public UserModel AddUser ([FromBody] RequestUserModel usrRqstMdl)
        {

            _logger.LogTrace("AddUser");

            var userModel = new UserModel
            {
                UserName = usrRqstMdl.UserName,
                UserSecName = usrRqstMdl.UserSecName,
                UserEmail = usrRqstMdl.UserEmail,
                UserPassword = usrRqstMdl.UserPassword
            };

            using (var contexc = new DataBaseContext())
            {
                contexc.UserModels.Add(userModel);
                contexc.SaveChanges();
            }

            return userModel;
        }


        [HttpGet]
        [Route("User/GetAllUsers")]
        public List<UserViewModel> GetAllUsers()
        {
            List<UserModel> userModel = new List<UserModel>();

            //foreach (var user in db.UserModels)
            //{
            //    userModel.Add(user);
            //}
            //return ListFunctions.ListUserMToListUserMV(userModel);
            //return ListFunctions.ListUserMToListUserMV(_dataBaseMemory.UserModelList);
            throw new NotImplementedException();
        }


        [HttpGet]
        [Route("User/DeleteUser")]
        public ActionResult DeleteUser(Guid userGuid)
        {
            /*
            var removeUser = _dataBaseMemory.UserModelList.Where(x => x.UserGuid == userGuid).FirstOrDefault();
            if (removeUser != null)
                _dataBaseMemory.UserModelList.Remove(removeUser);
            return Ok();
            */
            //var removeUser = db.UserModels.FirstOrDefault(x => x.UserGuid == userGuid);
            //if (removeUser != null)
            //    db.UserModels.Remove (removeUser);
            return Ok();
        }

    }
}