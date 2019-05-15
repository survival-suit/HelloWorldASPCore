using System;
using RequestTester.Services;
using Microsoft.Extensions.Logging;

namespace RequestTester
{
    class Program
    {
        private readonly ILogger _logger;

        public Program(ILogger<Program> logger)
        {
            _logger = logger;
        }

        public static void Main(string[] args)
        {
            //_logger.LogTrace("MainStart");
            Console.ReadKey();
            RequestSendService.PostRequestAsync();
            Console.ReadKey();
            //_logger.LogTrace("MainTerminate");
        }
    }
}
