using System;
using RequestTester.RequestModels;

namespace RequestTester
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadKey();
            RequestSend.PostRequestAsync();
            Console.ReadKey();
        }
    }
}
