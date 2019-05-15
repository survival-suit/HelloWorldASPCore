using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RequestTester.RequestModels
{
    class RequestSend
    {
        public static async Task PostRequestAsync()
        {            
            try
            {
                /*
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:58195/api/FileSystem");
                request.Method = "POST";                
                byte[] byteArray = Encoding.GetEncoding("UTF-8").GetBytes("{ \"pathString\": \"C:\\blkmstr\", \"showFolder\": true}");
                request.ContentType = "application/json-patch+json";
                request.Accept = "text/plain";



                Stream dataStream = request.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);


                WebResponse response = await request.GetResponseAsync();
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                Console.WriteLine(reader.ReadToEnd());

                response.Close();
                Console.WriteLine("End Request");
                Console.ReadKey();*/

                string url = "http://localhost:58195/api/FileSystem";

                using (var webClient = new WebClient())
                {
                    var pars = new NameValueCollection();
                    pars.Add("pathString", "C:\\blkmstr");
                    pars.Add("showFolder", "true");
                    var response = webClient.UploadValues(url, pars);
                }
            }
            catch (Exception ex)
            {
              Console.WriteLine(ex);
            }
        }
    }
}
