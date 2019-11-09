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

        public GroupController(ILogger<GroupController> logger, DataBaseMemory dataBaseMemory)
        {
            _logger = logger;
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
          
            using (var context = new DataBaseContext())
            {
                context.GroupModels.Add(groupModel);
                context.SaveChanges();
            }

            return groupModel;
        }

        [HttpGet]
        [Route("Group/DeleteGroup")]
        public ActionResult DeleteGroup(Guid groupGuid)
        {
            using (var context = new DataBaseContext())
            {
                var removeGroup = context.GroupModels.FirstOrDefault(x => x.GroupGuid == groupGuid);
                if (removeGroup != null)
                    context.GroupModels.Remove(removeGroup);
                context.SaveChanges();
            }

            return Ok();
        }

        [HttpGet]
        [Route("Group/AddUsersToGroup")]
        public ActionResult AddUsersToGroup (Guid groupGuid, List<Guid> userGuidList)
        {
            using (var context = new DataBaseContext())
            {
                var writeGroup = context.GroupModels.FirstOrDefault(x => x.GroupGuid == groupGuid);

                foreach (Guid guid in userGuidList)
                {
                    writeGroup.GroupUsers.Add(context.UserModels.FirstOrDefault(x => x.UserGuid == guid));
                }
                context.SaveChanges();
            }

            return Ok();
        }

        // GET       
        [HttpGet]
        [Route("Group/GetAllGroups")]
        public List<GroupViewModel> GetAllGroups()
        {
            List<GroupModel> groupModel = new List<GroupModel>();

            using (var context = new DataBaseContext())
            {
                foreach (var group in context.GroupModels)
                {
                    groupModel.Add(group);
                }
            }
            return ListFunctions.ListGroupMToListGroupMV(groupModel);
        }
    }
}
