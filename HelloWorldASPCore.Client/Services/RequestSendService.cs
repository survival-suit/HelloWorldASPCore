using System;
using System.Text;
using System.Net;
using System.IO;
using HelloWorldASPCore.Common.RequestModels;
using HelloWorldASPCore.Common.ResponseModels;
using Newtonsoft.Json;
using System.Collections.Generic;
namespace HelloWorldASPCore.Client.Services
{
    public class RequestSendService
    {
        //public static async Task PostRequestAsync()
        public static void PostRequestSync(int val)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:58195/api/FileSystem"); 

                if (val == 1)
                {
                    //объявляем экземпляр класса с инициализацией
                    var pathRequest = new PathRequest()
                    {
                        PathString = "C:\\BOTS",
                        ShowFolder = true
                    };                    

                    var message = JsonConvert.SerializeObject(pathRequest);
                    byte[] byteArray = Encoding.UTF8.GetBytes(message);
                    request.Proxy = null;
                    request.Method = "POST";
                    request.ContentType = "application/json-patch+json";
                    request.Accept = "text/plain";
                    request.ContentLength = byteArray.Length;

                    using (Stream dataStream = request.GetRequestStream())
                    {
                        dataStream.Write(byteArray, 0, byteArray.Length);
                    }

                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    /*
                    using (Stream stream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            List<PathResponse> pathRespList = JsonConvert.DeserializeObject<List<PathResponse>>(reader.ReadToEnd());                                
                            foreach (var obj in pathRespList)
                            {
                                Console.WriteLine(JsonConvert.SerializeObject(obj));
                                Console.WriteLine("----------------");
                            }                           
                        }                                                                       
                    } */  
                    
                    using (Stream stream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            int statusCode = (int)response.StatusCode;
                            if (statusCode == 200)
                            {
                                List<PathResponse> pathRespList = JsonConvert.DeserializeObject<List<PathResponse>>(reader.ReadToEnd());
                                foreach (var obj in pathRespList)
                                {
                                    Console.WriteLine(JsonConvert.SerializeObject(obj));
                                    Console.WriteLine("----------------");
                                }
                            }
                            else if (statusCode == 500)
                            {
                                HttpResponseException httpRespExept = JsonConvert.DeserializeObject<HttpResponseException>(reader.ReadToEnd());
                                Console.WriteLine(JsonConvert.SerializeObject(httpRespExept));
                                Console.WriteLine("----------------");
                            }
                        }
                    }  
                    Console.WriteLine("----------------");
                    Console.WriteLine("End Request");
                }
                else if (val == 2)
                {
                    string message = "{ \"pathString\": \"C:\\\\BOTS\", \"showFolder\": true}";                    
                    byte[] byteArray = Encoding.UTF8.GetBytes(message);
                    request.Proxy = null;
                    request.Method = "POST";
                    request.ContentType = "application/json-patch+json";
                    request.Accept = "text/plain";
                    request.ContentLength = byteArray.Length;

                    using (Stream dataStream = request.GetRequestStream())
                    {
                        dataStream.Write(byteArray, 0, byteArray.Length);
                    }

                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
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
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }            
        }
    }
}