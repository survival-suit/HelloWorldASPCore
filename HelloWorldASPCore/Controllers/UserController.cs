using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HelloWorldASPCore.Common.UserModels;
using HelloWorldASPCore.Services;

namespace HelloWorldASPCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger _logger;
        List<UserModel> userList = new List<UserModel>();

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        // GET 
        [HttpGet("{userName}, {userSecName}, {userEmail}, {userPassword}")]
        public ActionResult<string> PushUser(string userName, string userSecName, string userEmail, string userPassword)
        {

            _logger.LogTrace("PushUser");

            var userModel = new UserModel
            {
                UserName = userName,
                UserSecName = userSecName,
                UserEmail = userEmail,
                UserPassword = userPassword
            };

            return UserServices.PushUser(userList, userModel);

            //return FolderServices.ScanFolderService(pathRequest.PathString, pathRequest.ShowFolder);                 

        }

        // GET
        [HttpGet]
        public ActionResult<List<UserModel>> ShowAllUsers(List<UserModel> userList)
        {
            return UserServices.ShowAllUsers(userList);
        }


        
    }
}