using System;
using HelloWorldASPCore.Client.Services;

namespace HelloWorldASPCore.Client
{
    class Program
    {        
        static void Main(string[] args)
        {
            bool contin = true;

            while (contin)
{
                Console.WriteLine("POST method /api/FileSystem Serializable (1)");
                Console.WriteLine("POST method /api/FileSystem String (2)");
                Console.WriteLine("exit (e)");

                string menu = Console.ReadLine();

                switch (menu)
                {
                    case "1":
                        RequestSendService.PostRequestSync(1);
                        break;

                    case "2":
                        RequestSendService.PostRequestSync(2);
                        break;

                    case "e":
                    default:
                        contin = false;
                        break;
                }
            }            
        }
    }
}
