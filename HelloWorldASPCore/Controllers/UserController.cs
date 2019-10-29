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
        private DataBaseMemory _dataBaseMemory;
        private DataBaseContext db;

        public UserController(ILogger<UserController> logger, DataBaseMemory dataBaseMemory)
        {
            _logger = logger;
            _dataBaseMemory = dataBaseMemory;
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

            _dataBaseMemory.UserModelList.Add(userModel);
            //db.UserModels.Add(userModel);
            //db.SaveChangesAsync();
            return userModel;
        }


        [HttpGet]
        [Route("User/GetAllUsers")]
        public List<UserViewModel> GetAllUsers()
        {  
          return ListFunctions.ListUserMToListUserMV(_dataBaseMemory.UserModelList);
          //List<UserViewModel> userViewModel = new List<UserViewModel>();
          //return db.UserModels.ToList(userViewModel); 
        }
        

        [HttpGet]
        [Route("User/DeleteUser")]
        public ActionResult DeleteUser(Guid userGuid)
        {
            var removeUser = _dataBaseMemory.UserModelList.Where(x => x.UserGuid == userGuid).FirstOrDefault();
            if (removeUser != null)
                _dataBaseMemory.UserModelList.Remove(removeUser);
            return Ok();
        }

    }
}