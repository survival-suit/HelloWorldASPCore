using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HelloWorldASPCore.Common.Models;
using HelloWorldASPCore.Common.RequestModels;
using System.Linq;
using System.Collections.Generic;

namespace HelloWorldASPCore.Controllers
{
    public class GroupController : ControllerBase
    {
        private readonly ILogger _logger;
        private DataBaseMemory _dataBaseMemory;

        public GroupController(ILogger<GroupController> logger, DataBaseMemory dataBaseMemory)
        {
            _logger = logger;
            _dataBaseMemory = dataBaseMemory;
        }

        [HttpPost]
        [Route("Group/AddGroup")]
        public GroupModel AddGroup([FromBody] RequestGroupModel grpRqstMdl)
        {
            _logger.LogTrace("PushUser");

            var groupModel = new GroupModel
            {
                GroupName = grpRqstMdl.GroupName,
                GroupDescription = grpRqstMdl.GroupDescription,
                GroupAdmins = grpRqstMdl.GroupAdmins
            };

            _dataBaseMemory.GroupModelList.Add(groupModel);
            return groupModel;
        }

        [HttpGet]
        [Route("Group/DeleteGroup")]
        public ActionResult DeleteGroup(Guid groupGuid)
        {
            var removeGroup = _dataBaseMemory.GroupModelList.Where(x => x.GroupGuid == groupGuid).FirstOrDefault();
            if (removeGroup != null)
                _dataBaseMemory.GroupModelList.Remove(removeGroup);
            return Ok();
        }

        [HttpGet]
        [Route("Group/AddUsersToGroup")]
        public ActionResult AddUsersToGroup (Guid groupGuid, List<Guid> userGuidList)
        {
            var writeGroup = _dataBaseMemory.GroupModelList.Where(x => x.GroupGuid == groupGuid).FirstOrDefault();
            //var currentUser = new UserModel();

            foreach (Guid guid in userGuidList)
            {
                //currentUser = _dataBaseMemory.UserModelList.Where(x => x.UserGuid == guid).FirstOrDefault();
                writeGroup.GroupUsers.Add(_dataBaseMemory.UserModelList.Where(x => x.UserGuid == guid).FirstOrDefault());
            }

            if (writeGroup != null)
                _dataBaseMemory.GroupModelList.Remove(writeGroup);
            return Ok();
        }

        // GET       
        [HttpGet]
        [Route("Group/ShowAllGroups")]
        public List<GroupModel> ShowAllGroups() { return _dataBaseMemory.GroupModelList; }
    }
}
