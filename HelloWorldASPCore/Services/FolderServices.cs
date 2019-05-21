using System.IO;
using System.Linq;
using System.Collections.Generic;
using HelloWorldASPCore.Common.ResponseModels;
using System;

namespace HelloWorldASPCore.Services
{
    public class FolderServices
    {
        public static long FolderSizeService(string str)
        {   //считаем сколько весят все файлы в директории
            List<string> fls = Directory.GetFiles(str, "*.*", SearchOption.AllDirectories).ToList<string>();
            long sum = 0;            
            foreach (var s in fls)
            {
             FileInfo fileInf = new FileInfo(s);
                sum += fileInf.Length;
            }
            return sum;
        }

        public static List<PathResponse> ScanFolderService(string pathString, bool showFolder)
        {          
                List<string> files = Directory.GetFiles(pathString).ToList();
                var pathRespList = new List<PathResponse>();

                foreach (var s in files)
                {
                    FileInfo fileInf = new FileInfo(s);
                    //Использовать var и простой инициализатор
                    var pathResp = new PathResponse
                    {
                        FullName = fileInf.FullName,
                        CreationTime = fileInf.CreationTime,
                        LastWriteTime = fileInf.LastWriteTime,
                        Length = fileInf.Length,
                        IsDirectory = false
                    };
                    pathRespList.Add(pathResp);
                }

                //если пользователь отметил и папки
                if (showFolder)
                {
                    List<string> dirs = Directory.GetDirectories(pathString).ToList();
                    foreach (var s in dirs)
                    {
                        DirectoryInfo dirInfo = new DirectoryInfo(s);
                        //Использовать var и простой инициализатор
                        var pathResp = new PathResponse
                        {
                            FullName = dirInfo.FullName,
                            CreationTime = dirInfo.CreationTime,
                            LastWriteTime = dirInfo.LastWriteTime,
                            Length = FolderSizeService(s),
                            IsDirectory = true
                        };
                        pathRespList.Add(pathResp);
                    }
                }
                return pathRespList;              
        }
    }
}
