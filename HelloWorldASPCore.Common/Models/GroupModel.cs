using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HelloWorldASPCore.Common.Models
{
    public class GroupModel
    {
        /// <summary>
        /// GUID группы
        /// </summary>
        [Key] 
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

        //Конструктор по умолчаию создает пустой список юзеров чтобы при создании группы через АПИ он был а также GUID
        public GroupModel()
        {
            GroupUsers = new List<UserModel>();
            GroupGuid = Guid.NewGuid();
        }
    }
}
