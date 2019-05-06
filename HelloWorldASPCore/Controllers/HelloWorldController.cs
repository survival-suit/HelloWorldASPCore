using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
