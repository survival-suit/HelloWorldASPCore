using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HelloWorldASPCore.Common.Models;
using HelloWorldASPCore.Services;
using System.Linq;

namespace HelloWorldASPCore.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger _logger;
        private DataBaseMemory _dataBaseMemory;

        //List<UserModel> userList = new List<UserModel>();


        public UserController(ILogger<UserController> logger, DataBaseMemory dataBaseMemory)
        {
            _logger = logger;
            _dataBaseMemory = dataBaseMemory;
        }

        // GET 

        [HttpGet]
        [Route("User/AddUser")]
        public UserModel AddUser(string userName, string userSecName, string userEmail, string userPassword)
        {

            _logger.LogTrace("PushUser");

            var userModel = new UserModel
            {
                UserGuid = Guid.NewGuid(),
                UserName = userName,
                UserSecName = userSecName,
                UserEmail = userEmail,
                UserPassword = userPassword
            };

            _dataBaseMemory.UserModelList.Add(userModel);

            return userModel;

        }

        // GET       
        [HttpGet]
        [Route("User/ShowAllUsers")]
        public List<UserModel> ShowAllUsers() { return _dataBaseMemory.UserModelList; }

        [HttpGet]
        [Route("User/RemoveUser")]
        public ActionResult RemoveUser(Guid userGuid)
        {
            var removeUser = _dataBaseMemory.UserModelList.Where(x => x.UserGuid == userGuid).FirstOrDefault();
            if (removeUser != null)
                _dataBaseMemory.UserModelList.Remove(removeUser);
            return Ok();
        }

    }
}