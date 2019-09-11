using System;
using System.Collections.Generic;

namespace HelloWorldASPCore.Common.Models
{
    public class GroupModel
    {
        /// <summary>
        /// GUID группы
        /// </summary>
        public Guid GroupGuid { get; set; }

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
        public List<UserModel> GroupUsers  { get; set; }

        //Конструктор по уолчаию создает пустой список юзеров чтобы при создании группы через АПИ он был а также GUID
        public GroupModel()
        {
            GroupUsers = new List<UserModel>();
            GroupGuid = Guid.NewGuid();
        }
    }
}
