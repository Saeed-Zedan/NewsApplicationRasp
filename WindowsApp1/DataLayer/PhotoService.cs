using FileWorksObject;
using Newtonsoft.Json.Linq;

namespace DataLayer
{
    public class PhotoService
    {
        private object apiUrl = "https://localhost:44317/api/Photo";
        private string controllerName = "Photo";

        public string Read(int id)
        {
            // Dim apiUrl = $"https://localhost:44317/api/User/{id}"
            // Dim apiUrl = Me.apiUrl & $"/{id}"
            // Dim request = CType(WebRequest.Create(apiUrl), HttpWebRequest)

            // Dim responceString As String
            // request.Method = "GET"
            // request.ContentType = "application/json"

            // Try
            // Using result = request.GetResponse()
            // Using reader = New StreamReader(result.GetResponseStream())
            // responceString = reader.ReadToEnd()
            // End Using
            // End Using

            // Return responceString

            // Catch e As WebException
            // Return e.Message

            // End Try

            var objService = new BaseService();
            objService.ApiUrl += $"/{controllerName}/{id}";
            string result = objService.Read();
            return result;
        }

        public string Update(Photo obj)
        {
            // Dim apiUrl As String = "https://localhost:44317/api/User"
            // Dim request = CType(WebRequest.Create(apiUrl), HttpWebRequest)

            // Dim responceString As String
            // Dim inputJson = (New JavaScriptSerializer()).Serialize(obj)
            // Dim bytes As Byte() = Encoding.UTF8.GetBytes(inputJson)

            // request.Method = "POST"
            // request.ContentType = "application/json"
            // request.Accept = "application/json"
            // request.ContentLength = bytes.Length
            // request.Expect = "application/json"
            // request.GetRequestStream().Write(bytes, 0, bytes.Length)

            // Try
            // Using response As HttpWebResponse = DirectCast(request.GetResponse(), HttpWebResponse)
            // Dim reader As StreamReader
            // reader = New StreamReader(response.GetResponseStream())
            // responceString = reader.ReadToEnd()
            // reader.Close()
            // response.Close()
            // Return responceString
            // End Using
            // Catch e As WebException
            // Return e.Message

            // End Try

            var objService = new BaseService();
            objService.ApiUrl += $"/{controllerName}";
            string result = objService.Update(obj);
            return result;
        }

        public string Delete(int id)
        {
            // Dim apiUrl = $"https://localhost:44317/api/User/{id}"
            // Dim apiUrl = Me.apiUrl & $"/{id}"
            // Dim request = CType(WebRequest.Create(apiUrl), HttpWebRequest)

            // Dim responceString As String
            // request.Method = "DELETE"
            // request.ContentType = "application/json"
            // Try
            // Using result = request.GetResponse()
            // Using reader = New StreamReader(result.GetResponseStream())
            // responceString = reader.ReadToEnd()
            // End Using
            // End Using
            // Catch e As WebException
            // Return e.Message

            // End Try

            // Return responceString

            var objService = new BaseService();
            objService.ApiUrl += $"/{controllerName}/{id}";
            string result = objService.Delete();
            return result;
        }

        public JArray Run(PhotoQuery obj)
        {
            // Dim apiUrl As String = Me.apiUrl & "/Get"
            // Dim request = CType(WebRequest.Create(apiUrl), HttpWebRequest)

            // Dim inputJson = (New JavaScriptSerializer()).Serialize(obj)
            // Dim bytes As Byte() = Encoding.UTF8.GetBytes(inputJson)

            // request.Method = "POST"
            // request.ContentType = "application/json"
            // request.Accept = "application/json"
            // request.ContentLength = bytes.Length
            // request.Expect = "application/json"
            // request.GetRequestStream().Write(bytes, 0, bytes.Length)
            // Try
            // Using response As HttpWebResponse = DirectCast(request.GetResponse(), HttpWebResponse)
            // Dim reader As StreamReader
            // Dim rawlistresp As List(Of String) = New List(Of String)
            // reader = New StreamReader(response.GetResponseStream())
            // Dim rawresp = reader.ReadToEnd()
            // Dim array As JArray = JArray.Parse(rawresp)
            // reader.Close()
            // response.Close()
            // Return array
            // End Using
            // Catch e As WebException
            // Return e.Message

            // End Try

            var objService = new BaseService();
            objService.ApiUrl += $"/{controllerName}/Get";
            var result = objService.Run(obj);
            return result;
        }
    }
}