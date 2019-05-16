using System;
namespace HelloWorldASPCore.Common.RequestModels
{
    /// <summary>
    /// Файл реквест содержит модель для запроса, Приватные переменные лучше заменить на свойства. Модель отвечает за данные
    /// Наполение модели может проходить извне
    /// </summary>
    public class PathRequest
    {                
        public string PathString { get; set; }
        public bool ShowFolder { get; set; }                  
    }
}
