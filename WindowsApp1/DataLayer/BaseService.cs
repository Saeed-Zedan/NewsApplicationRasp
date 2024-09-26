using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Nancy.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DataLayer
{
    public class BaseService
    {
        public string ApiUrl { get; set; } = "https://localhost:5001/api";

        public string Read()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(ApiUrl);
            string responceString;
            request.Method = "GET";
            request.ContentType = "application/json";
            try
            {
                using (var result = request.GetResponse())
                {
                    using (var reader = new StreamReader(result.GetResponseStream()))
                    {
                        responceString = reader.ReadToEnd();
                    }
                }

                return responceString;
            }
            catch (WebException e)
            {
                var code = ((int)((HttpWebResponse)e.Response).StatusCode);
                if (code == 404)
                    return "Not Found";
                return "Error";
            }
            
        }

        public string Delete()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(ApiUrl);
            string responceString;
            request.Method = "DELETE";
            request.ContentType = "application/json";

            try
            {
                using (var result = request.GetResponse())
                {
                    using (var reader = new StreamReader(result.GetResponseStream()))
                    {
                        responceString = reader.ReadToEnd();
                    }
                }
                return responceString;
            }
            catch (WebException e)
            {
                var code = ((int)((HttpWebResponse)e.Response).StatusCode);
                if (code == 404)
                    return "Not Found";
                return "Error";
            }
            
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
            }

            var busObj = JsonConvert.DeserializeObject<T>(responceString).ToString();
            return busObj;
        }

        public List<string> Run<T>(T obj)
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

            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    StreamReader reader;
                    var rawlistresp = new List<string>();
                    reader = new StreamReader(response.GetResponseStream());
                    string rawresp = reader.ReadToEnd();
                    var array = JArray.Parse(rawresp);
                    reader.Close();
                    response.Close();
                    return array.ToObject<List<string>>();
                }
            }
            catch (WebException e)
            {
                var code = ((int)((HttpWebResponse)e.Response).StatusCode);
                if (code == 404)
                    return null;
                return null;
            }
        }
    }
}