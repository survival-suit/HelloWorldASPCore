using System;
using Microsoft.Extensions.Logging;
using HelloWorldASPCore.Client.Services;

namespace HelloWorldASPCore.Client
{
    class Program
    {
        private readonly ILogger _logger;

        public Program(ILogger<Program> logger)
        {
            _logger = logger;
        }
        static void Main(string[] args)
        {
            Console.ReadKey();
            RequestSendService.PostRequestAsync();
            Console.ReadKey();
        }
    }
}
