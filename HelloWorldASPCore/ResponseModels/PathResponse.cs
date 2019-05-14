using System;

namespace HelloWorldASPCore.ResponseModels
{
    public class PathResponse
    {
        public string FullName { get; set; } //полное имя
        public DateTime CreationTime { get; set; } //Дата создания
        public DateTime LastWriteTime { get; set; } //Дата изменения
        public long Length { get; set; } //Размер
    }
}
