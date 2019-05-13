using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Threading;

namespace HelloWorldASPCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileSystemController : ControllerBase
    {
        private readonly ILogger _logger;

        public FileSystemController(ILogger<FileSystemController> logger)
        {
            _logger = logger;
        }

        // GET 
        [HttpGet("{path},{folder}")]
        public ActionResult<PathOutro[]> Getdata(string path, bool folder)
        {
            try
            {
                _logger.LogTrace("Getdata");
                PathIntro pathIntro=  new PathIntro(path, folder);
                PathOutro[] outMass;

                outMass = pathIntro.GetInfo();

                return outMass;
            }
            catch (Exception ex)
            {
                //NLog: catch setup errors
                _logger.LogError(ex, "Stopped program because of exception");
                throw;
            }
            /*finally
            {
                // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
                NLog.LogManager.Shutdown();
            }*/
        }

    }

    //для входных данных
    public class PathIntro
    {       
        public string pathString;
        public bool showFolder;

        public PathIntro(string pS, bool sF) { pathString = pS; showFolder = sF; }

        public long WeightFolder(string s)
            {//считаем сколько весят все файлы в директории
                string[] fls = System.IO.Directory.GetFiles(s, "*.*", System.IO.SearchOption.AllDirectories);
                long sum = 0;
                for (int j = 0; j < fls.Length; j++)
                {
                    FileInfo fi = new FileInfo(fls[j]);
                    sum += fi.Length;
                }
                return sum;
            }

        public PathOutro[] GetInfo()
            {
            int i = 0;            
            //если пользователь отметил и папки
            if (showFolder)
            {
                List<string> dirs = Directory.GetDirectories(pathString).ToList<string>();
                List<string> files = Directory.GetFiles(pathString).ToList<string>();
                PathOutro[] pathOutros = new PathOutro[files.Count()+dirs.Count()];

                foreach (var s in files)
                {
                    FileInfo fileInf = new FileInfo(s);
                    PathOutro PO = new PathOutro();
                    PO.fullName = fileInf.FullName;
                    PO.creationTime = fileInf.CreationTime;
                    PO.lastWriteTime = fileInf.LastWriteTime;
                    PO.length = fileInf.Length;
                    pathOutros[i] = PO;
                    i++;
                }

                foreach (string s in dirs)
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(s);
                    PathOutro PO = new PathOutro();

                    PO.fullName = dirInfo.FullName;
                    PO.creationTime = dirInfo.CreationTime;
                    PO.lastWriteTime = dirInfo.LastWriteTime;
                    PO.length = WeightFolder(s);
                    pathOutros[i] = PO;
                    i++;
                }
                return pathOutros;
            }
            else
            {
                List<string> files = Directory.GetFiles(pathString).ToList<string>();

                PathOutro[] pathOutros = new PathOutro[files.Count()];
                foreach (var s in files)
                {
                    FileInfo fileInf = new FileInfo(s);
                    PathOutro PO = new PathOutro();
                    PO.fullName = fileInf.FullName;
                    PO.creationTime = fileInf.CreationTime;
                    PO.lastWriteTime = fileInf.LastWriteTime;
                    PO.length = fileInf.Length;
                    pathOutros[i] = PO;
                    i++;
                }
                return pathOutros;
            }
            
        }
    }

    //для выходных данных
    public struct PathOutro
    {
        public string fullName; //полное имя
        public DateTime creationTime; //Дата создания
        public DateTime lastWriteTime; //Дата изменения
        public long length; //Размер
    }
}