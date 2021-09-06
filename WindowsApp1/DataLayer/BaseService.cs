using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Nancy.Json;
using Newtonsoft.Json.Linq;

namespace DataLayer
{
    public class BaseService
    {
        public string ApiUrl { get; set; } = "https://localhost:44317/api";

        public string GetApi(string apiUrl)
        {
            string responceString = string.Empty;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(apiUrl);
            request.Method = "GET";
            request.ContentType = "application/json";
            using (var result = request.GetResponse())
            {
                using (var reader = new StreamReader(result.GetResponseStream()))
                {
                    responceString = reader.ReadToEnd();
                }
            }

            return responceString;
        }

        public string Read()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(ApiUrl);
            string responceString;
            request.Method = "GET";
            request.ContentType = "application/json";
            using (var result = request.GetResponse())
            {
                using (var reader = new StreamReader(result.GetResponseStream()))
                {
                    responceString = reader.ReadToEnd();
                }
            }

            return responceString;
        }

        public string Delete()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(ApiUrl);
            string responceString;
            request.Method = "DELETE";
            request.ContentType = "application/json";
            using (var result = request.GetResponse())
            {
                using (var reader = new StreamReader(result.GetResponseStream()))
                {
                    responceString = reader.ReadToEnd();
                }
            }

            return responceString;
        }

        public string Update<T>(T obj)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(ApiUrl);
            string responceString;
            string inputJson = new JavaScriptSerializer().Serialize(obj);
            var bytes = Encoding.UTF8.GetBytes(inputJson);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            request.ContentLength = bytes.Length;
            request.Expect = "application/json";
            request.GetRequestStream().Write(bytes, 0, bytes.Length);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                StreamReader reader;
                reader = new StreamReader(response.GetResponseStream());
                responceString = reader.ReadToEnd();
                reader.Close();
                response.Close();
                return responceString;
            }
        }

        public JArray Run<T>(T obj)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(ApiUrl);
            string inputJson = new JavaScriptSerializer().Serialize(obj);
            var bytes = Encoding.UTF8.GetBytes(inputJson);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            request.ContentLength = bytes.Length;
            request.Expect = "application/json";
            request.GetRequestStream().Write(bytes, 0, bytes.Length);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                StreamReader reader;
                var rawlistresp = new List<string>();
                reader = new StreamReader(response.GetResponseStream());
                string rawresp = reader.ReadToEnd();
                var array = JArray.Parse(rawresp);
                reader.Close();
                response.Close();
                return array;
            }
        }
    }
}
// Public Static Class ApiCall
// {  
// Public Static String GetApi(String ApiUrl)  
// {  

// var responseString = "";  
// var request = (HttpWebRequest)WebRequest.Create(ApiUrl);  
// request.Method = "GET";  
// request.ContentType = "application/json";  

// Using (var response1 = request.GetResponse())  
// {  
// Using (var reader = New StreamReader(response1.GetResponseStream()))  
// {  
// responseString = reader.ReadToEnd();  
// }  
// }  
// Return responseString;  

// }  



// Public Static String PostApi(String ApiUrl, String postData = "")  
// {  

// var request = (HttpWebRequest)WebRequest.Create(ApiUrl);  
// var data = Encoding.ASCII.GetBytes(postData);  
// request.Method = "POST";  
// request.ContentType = "application/x-www-form-urlencoded";  
// request.ContentLength = data.Length;  
// Using (var stream = request.GetRequestStream())  
// {  
// stream.Write(data, 0, data.Length);  
// }  
// var response = (HttpWebResponse)request.GetResponse();  
// var responseString = New StreamReader(response.GetResponseStream()).ReadToEnd();  
// Return responseString;  
// }  






// }
