using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HelloWorldASPCore.Services;
using Microsoft.AspNetCore.Http;
using HelloWorldASPCore.Common.RequestModels;
using HelloWorldASPCore.Common.ResponseModels;


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
        [HttpGet]
        public List<PathResponse> GetPathContent([FromQuery]PathRequest pathRequest)
        {
            //try
            //{
                _logger.LogTrace("GetPathContent");
                ////PathRequest pathIntro =  new PathRequest(path, folder);
                ////var outList = new List<PathResponse>();

                ////outList = pathIntro.ScanFolder();
                return FolderServices.ScanFolderService(pathRequest.PathString, pathRequest.ShowFolder);

            //}
            //catch (Exception ex)
            //{
                ////NLog: catch setup errors
                //_logger.LogError(ex, "Stopped program because of exception");
                //throw;
            //}            
        }

        // POST     
        //Для директорий приходится вводить даблслеш, с @ неработает..
        [HttpPost]
        public List<PathResponse> PostPathContent([FromBody]PathRequest pathRequest)
        {
            //try
            //{
                _logger.LogTrace("PostPathContent");             
                return FolderServices.ScanFolderService(pathRequest.PathString, pathRequest.ShowFolder);
            //}
            //catch (Exception ex)
            //{
                ////NLog: catch setup errors
                //_logger.LogError(ex, "Stopped program because of exception");
                //throw;
            //}
        }

    }    
}