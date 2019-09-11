using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HelloWorldASPCore.Common.Models;
using HelloWorldASPCore.Common.RequestModels;
using System.Linq;



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

        [HttpGet]
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
            var removeGroup = _dataBaseMemory.GroupModelList.Where( x=> x.GroupGuid == groupGuid).FirstOrDefault();
            if (removeGroup != null)
                _dataBaseMemory.GroupModelList.Remove(removeGroup);
            return Ok();
        }

    }
}
