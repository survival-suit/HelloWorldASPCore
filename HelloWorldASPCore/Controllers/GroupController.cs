using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HelloWorldASPCore.Common.Models;
using HelloWorldASPCore.Common.Context;
using HelloWorldASPCore.Common.Services;
using HelloWorldASPCore.Common.ViewModels;
using HelloWorldASPCore.Common.RequestModels;
using System.Linq;
using System.Collections.Generic;

namespace HelloWorldASPCore.Controllers
{
    public class GroupController : ControllerBase
    {
        private readonly ILogger _logger;
        private DataBaseMemory _dataBaseMemory;
        private DataBaseContext db;

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

            //_dataBaseMemory.GroupModelList.Add(groupModel);
            db.GroupModels.Add(groupModel);
            db.SaveChanges();

            return groupModel;
        }

        [HttpGet]
        [Route("Group/DeleteGroup")]
        public ActionResult DeleteGroup(Guid groupGuid)
        {
            /*
            var removeGroup = _dataBaseMemory.GroupModelList.Where(x => x.GroupGuid == groupGuid).FirstOrDefault();
            if (removeGroup != null)
                _dataBaseMemory.GroupModelList.Remove(removeGroup);
            return Ok();
            */
            var removeGroup = db.GroupModels.FirstOrDefault(x => x.GroupGuid == groupGuid);
            if (removeGroup != null)
                db.GroupModels.Remove(removeGroup);
            return Ok();
        }

        [HttpGet]
        [Route("Group/AddUsersToGroup")]
        public ActionResult AddUsersToGroup (Guid groupGuid, List<Guid> userGuidList)
        {
            //var writeGroup = _dataBaseMemory.GroupModelList.Where(x => x.GroupGuid == groupGuid).FirstOrDefault();
            var writeGroup = db.GroupModels.FirstOrDefault(x => x.GroupGuid == groupGuid);

            foreach (Guid guid in userGuidList)
            {
                //writeGroup.GroupUsers.Add(_dataBaseMemory.UserModelList.Where(x => x.UserGuid == guid).FirstOrDefault());  
                writeGroup.GroupUsers.Add(db.UserModels.FirstOrDefault(x => x.UserGuid == guid));
            }

            return Ok();
        }

        // GET       
        [HttpGet]
        [Route("Group/GetAllGroups")]
        public List<GroupViewModel> GetAllGroups()
        {
            //return ListFunctions.ListGroupMToListGroupMV(_dataBaseMemory.GroupModelList);
            List<GroupModel> groupModel = new List<GroupModel>();

            foreach (var group in db.GroupModels)
            {
                groupModel.Add(group);
            }
            return ListFunctions.ListGroupMToListGroupMV(groupModel);
        }
    }
}
