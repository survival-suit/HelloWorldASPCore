using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace HelloWorldASPCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelloWorldASPCore : ControllerBase
    {
        private readonly ILogger _logger;
        public HelloWorldASPCore(ILogger<HelloWorldASPCore> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Hello()
        {
            _logger.LogTrace("Hello World!!!");
            return "Hello World!!!";            
        }

        // GET 
        [HttpGet("{hours}")]
        public ActionResult<string> Getdate(double hours)
        {
            try
            {
                  _logger.LogTrace("Getdate");
                  DateTime utcDateTime = new DateTime();
                  utcDateTime = DateTime.UtcNow.AddHours(hours);
                  return utcDateTime.ToString("dd.MM.yyyy");
            }
            catch (Exception ex)
            {
                //NLog: catch setup errors
                _logger.LogError(ex, "Stopped program because of exception");
                throw;
            }
            finally
            {
                // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
                NLog.LogManager.Shutdown();
            }
        }

    }
}

