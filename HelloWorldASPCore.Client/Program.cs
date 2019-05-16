using System;
using HelloWorldASPCore.Client.Services;

namespace HelloWorldASPCore.Client
{
    class Program
    {        
        static void Main(string[] args)
        {
            Console.ReadKey();
            RequestSendService.PostRequestAsync();
            Console.ReadKey();
        }
    }
}
