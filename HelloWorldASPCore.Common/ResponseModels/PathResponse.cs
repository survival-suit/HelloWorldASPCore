using System;

namespace HelloWorldASPCore.Common.ResponseModels
{
    public class PathResponse
    {
        /// <summary>
        /// полное имя
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime CreationTime { get; set; }
        /// <summary>
        /// Дата изменения
        /// </summary>
        public DateTime LastWriteTime { get; set; }
        /// <summary>
        /// Размер
        /// </summary>
        public long Length { get; set; }
        /// <summary>
        /// Тип объекта
        /// </summary>
        public bool IsDirectory { get; set; }
    }
}
