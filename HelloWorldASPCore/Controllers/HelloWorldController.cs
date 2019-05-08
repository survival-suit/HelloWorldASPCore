using Microsoft.AspNetCore.Mvc;

namespace HelloWorldASPCore.Controllers
{
    public class HelloWorldASPCore : ControllerBase
    {
        
        protected internal string Hello()
        {   
            return "Hello World!!!";

            var nlogConfig = new NLog.Config.LoggingConfiguration();
            var nlogFileTarget = new NLog.Targets.FileTarget("logfile") { FileName = "myNLog.txt" };
            nlogConfig.AddRuleForAllLevels(nlogFileTarget);
            var logger = NLog.Web.NLogBuilder.ConfigureNLog(nlogConfig).GetCurrentClassLogger();

        }
    }
}
