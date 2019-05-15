using System;
using System.Text;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using NLog.Web.AspNetCore;
using Microsoft.Extensions.Logging;

namespace RequestTester.Services
{
    public class RequestSendService
    {
        private readonly ILogger _logger;

        public RequestSendService(ILogger<RequestSendService> logger)
        {
            _logger = logger;
        }

        public static async Task PostRequestAsync()
        {
            try
            {
                //_logger.LogTrace("PostRequestAsyncStart");
                byte[] byteArray = Encoding.UTF8.GetBytes("{ \"pathString\": \"C:\\\\BOTS\", \"showFolder\": true}");
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:58195/api/FileSystem");
                request.Method = "POST";
                request.ContentType = "application/json-patch+json";
                request.Accept = "text/plain";               
                request.ContentLength = byteArray.Length;

                using (Stream dataStream = request.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                }

                HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync();
                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        Console.WriteLine(reader.ReadToEnd());
                    }
                }
                response.Close();
                Console.WriteLine("End Request");                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
