using Microsoft.AspNetCore.Mvc;

namespace HelloWorldASPCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelloWorldASPCore : ControllerBase
    {
        [HttpGet]
        public  string Hello()
        {   
            return "Hello World!!!";

        }
    }
}
