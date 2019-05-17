using System;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Specialized;

namespace HelloWorldASPCore.Client.Services
{
    public class RequestSendService
    {
        //public static async Task PostRequestAsync()
        public static void PostRequestAsync()
        {
            
                try
                {                
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

                //HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync();
                HttpWebResponse response = (HttpWebResponse) request.GetResponse();
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
