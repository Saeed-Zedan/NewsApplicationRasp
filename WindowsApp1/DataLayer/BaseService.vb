Imports System.IO
Imports System.Net
Imports System.Text
Imports Nancy.Json
Imports Newtonsoft.Json.Linq

Public Class BaseService
    Public Property ApiUrl As String = "https://localhost:44317/api"

    Public Function GetApi(apiUrl As String) As String
        Dim responceString = String.Empty
        Dim request = CType(WebRequest.Create(apiUrl), HttpWebRequest)
        request.Method = "GET"
        request.ContentType = "application/json"

        Using result = request.GetResponse()
            Using reader = New StreamReader(result.GetResponseStream())
                responceString = reader.ReadToEnd()
            End Using
        End Using

        Return responceString
    End Function

    Public Function Read() As String
        Dim request = CType(WebRequest.Create(ApiUrl), HttpWebRequest)

        Dim responceString As String
        request.Method = "GET"
        request.ContentType = "application/json"

        Using result = request.GetResponse()
            Using reader = New StreamReader(result.GetResponseStream())
                responceString = reader.ReadToEnd()
            End Using
        End Using

        Return responceString
    End Function

    Public Function Delete() As String
        Dim request = CType(WebRequest.Create(ApiUrl), HttpWebRequest)

        Dim responceString As String
        request.Method = "DELETE"
        request.ContentType = "application/json"

        Using result = request.GetResponse()
            Using reader = New StreamReader(result.GetResponseStream())
                responceString = reader.ReadToEnd()
            End Using
        End Using

        Return responceString
    End Function

    Public Function Update(Of T)(obj As T) As String
        Dim request = CType(WebRequest.Create(ApiUrl), HttpWebRequest)

        Dim responceString As String
        Dim inputJson = (New JavaScriptSerializer()).Serialize(obj)
        Dim bytes As Byte() = Encoding.UTF8.GetBytes(inputJson)

        request.Method = "POST"
        request.ContentType = "application/json"
        request.Accept = "application/json"
        request.ContentLength = bytes.Length
        request.Expect = "application/json"
        request.GetRequestStream().Write(bytes, 0, bytes.Length)

        Using response As HttpWebResponse = DirectCast(request.GetResponse(), HttpWebResponse)
            Dim reader As StreamReader
            reader = New StreamReader(response.GetResponseStream())
            responceString = reader.ReadToEnd()
            reader.Close()
            response.Close()
            Return responceString
        End Using

    End Function

    Public Function Run(Of T)(obj As T) As JArray
        Dim request = CType(WebRequest.Create(ApiUrl), HttpWebRequest)

        Dim inputJson = (New JavaScriptSerializer()).Serialize(obj)
        Dim bytes As Byte() = Encoding.UTF8.GetBytes(inputJson)

        request.Method = "POST"
        request.ContentType = "application/json"
        request.Accept = "application/json"
        request.ContentLength = bytes.Length
        request.Expect = "application/json"
        request.GetRequestStream().Write(bytes, 0, bytes.Length)

        Using response As HttpWebResponse = DirectCast(request.GetResponse(), HttpWebResponse)
            Dim reader As StreamReader
            Dim rawlistresp As List(Of String) = New List(Of String)
            reader = New StreamReader(response.GetResponseStream())
            Dim rawresp = reader.ReadToEnd()
            Dim array As JArray = JArray.Parse(rawresp)
            reader.Close()
            response.Close()
            Return array
        End Using

    End Function
End Class
'Public Static Class ApiCall
'    {  
'        Public Static String GetApi(String ApiUrl)  
'        {  

'            var responseString = "";  
'            var request = (HttpWebRequest)WebRequest.Create(ApiUrl);  
'            request.Method = "GET";  
'            request.ContentType = "application/json";  

'            Using (var response1 = request.GetResponse())  
'            {  
'                Using (var reader = New StreamReader(response1.GetResponseStream()))  
'                {  
'                    responseString = reader.ReadToEnd();  
'                }  
'            }  
'            Return responseString;  

'        }  



'        Public Static String PostApi(String ApiUrl, String postData = "")  
'        {  

'            var request = (HttpWebRequest)WebRequest.Create(ApiUrl);  
'            var data = Encoding.ASCII.GetBytes(postData);  
'            request.Method = "POST";  
'            request.ContentType = "application/x-www-form-urlencoded";  
'            request.ContentLength = data.Length;  
'            Using (var stream = request.GetRequestStream())  
'            {  
'                stream.Write(data, 0, data.Length);  
'            }  
'            var response = (HttpWebResponse)request.GetResponse();  
'            var responseString = New StreamReader(response.GetResponseStream()).ReadToEnd();  
'            Return responseString;  
'        }  






'    }
