using FileWorksObject;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    class UserQueryService
    {
        public string controllerName { get; private set; } = "UserQuery";

        public JArray Run(UserQuery obj)
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

            var objService = new BaseService();
            objService.ApiUrl += $"/{controllerName}/Run";
            var result = objService.Run(obj);
            return result;
        }
    }
}
