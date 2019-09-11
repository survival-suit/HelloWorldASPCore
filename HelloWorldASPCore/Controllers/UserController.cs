using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HelloWorldASPCore.Common.Models;
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

        public UserController(ILogger<UserController> logger, DataBaseMemory dataBaseMemory)
        {
            _logger = logger;
            _dataBaseMemory = dataBaseMemory;
        }

        // GET 

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

            return userModel;

        }

        // GET       
        [HttpGet]
        [Route("User/ShowAllUsers")]
        public List<UserModel> ShowAllUsers() { return _dataBaseMemory.UserModelList; }

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