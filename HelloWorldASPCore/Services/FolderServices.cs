using System.IO;
using System.Linq;
using System.Collections.Generic;
using HelloWorldASPCore.ResponseModels;

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
            List<string> files = Directory.GetFiles(pathString).ToList<string>();
            var pathResplist = new List<PathResponse>();

            foreach (var s in files)
            {
                FileInfo fileInf = new FileInfo(s);
                PathResponse pathResp = new PathResponse();
                pathResp.FullName = fileInf.FullName;
                pathResp.CreationTime = fileInf.CreationTime;
                pathResp.LastWriteTime = fileInf.LastWriteTime;
                pathResp.Length = fileInf.Length;
                pathResplist.Add(pathResp);
            }

            //если пользователь отметил и папки
            if (showFolder)
            {
                List<string> dirs = Directory.GetDirectories(pathString).ToList<string>();

                foreach (string s in dirs)
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(s);
                    PathResponse pathResp = new PathResponse();

                    pathResp.FullName = dirInfo.FullName;
                    pathResp.CreationTime = dirInfo.CreationTime;
                    pathResp.LastWriteTime = dirInfo.LastWriteTime;
                    pathResp.Length = FolderSizeService(s);
                    pathResplist.Add(pathResp);                    
                }               
            }            
            return pathResplist;            
        }
    }
}
