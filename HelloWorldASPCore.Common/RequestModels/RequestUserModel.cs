//модель создана для заполнения юзеров чтобы не заполнять гуид, тк он генерится вручную
namespace HelloWorldASPCore.Common.RequestModels
{
    public class RequestUserModel
    {
        /// <summary>
        /// имя
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// фамилия
        /// </summary>
        public string UserSecName { get; set; }

        /// <summary>
        /// емейл
        /// </summary>
        public string UserEmail { get; set; }

        /// <summary>
        /// пароль
        /// </summary>
        public string UserPassword { get; set; }
    }
}
