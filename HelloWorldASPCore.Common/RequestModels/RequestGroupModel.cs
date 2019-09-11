using System.Collections.Generic;
using HelloWorldASPCore.Common.Models;
using System;

//модель создана для заполнения групп чтобы не заполнять гуид, тк он генерится программно
namespace HelloWorldASPCore.Common.RequestModels
{
    public class RequestGroupModel
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
        /// список GUID-ов пользователей
        /// </summary>
        //public List<Guid> GroupUsers { get; set; }
    }
}
