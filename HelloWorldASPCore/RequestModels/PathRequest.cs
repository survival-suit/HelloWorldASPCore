using System.IO;
using System.Collections.Generic;
using System.Linq;
using HelloWorldASPCore.ResponseModels;
using HelloWorldASPCore.Services;

namespace HelloWorldASPCore.RequestModels
{
    /// <summary>
    /// Файл реквест содержит модель для запроса, Приватные переменные лучше заменить на свойства. Модель отвечает за данные
    /// Наполение модели может проходить извне
    /// </summary>
    public class PathRequest
    {
        
        
        public string PathString { get; set; }
        public bool ShowFolder { get; set; }
        //public PathRequest(string pS, bool sF) { PathString = pS; ShowFolder = sF; }
      //  public List<PathResponse> ScanFolder() { return FolderServices.ScanFolderService(PathString, ShowFolder); }            
    }
}
