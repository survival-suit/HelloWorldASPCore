using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NLog.Web;

namespace HelloWorldASPCore.Controllers
{
    public class HelloWorldASPCore : ControllerBase
    {
        
        protected internal string Hello()
        {   
            return "Hello World!!!";
                        
        }
    }
}
