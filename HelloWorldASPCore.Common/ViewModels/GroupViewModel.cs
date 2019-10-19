using System;
using System.Collections.Generic;
using HelloWorldASPCore.Common.Services;
using HelloWorldASPCore.Common.Models;

namespace HelloWorldASPCore.Common.ViewModels
{
    public class GroupViewModel
    {
        /// <summary>
        /// имя группы
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// описание группы
        /// </summary>
        public string GroupDescription { get; set; }

        /// <summary>
        /// адиминистраторы
        /// </summary>
        public bool GroupAdmins { get; set; }

        /// <summary>
        /// пользователи
        /// </summary>
        public List<UserViewModel> GroupUsers { get; set; }

        public GroupViewModel(GroupModel groupModel)
        {
            GroupName = groupModel.GroupName;
            GroupDescription = groupModel.GroupDescription;
            GroupAdmins = groupModel.GroupAdmins;
            GroupUsers = ListFunctions.ListUserMToListUserMV(groupModel.GroupUsers);
        }
    }
}
