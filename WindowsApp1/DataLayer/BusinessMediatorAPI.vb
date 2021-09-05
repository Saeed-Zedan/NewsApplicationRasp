Imports System.IO
Imports System.Net
Imports System.Text
Imports FileWorxObject
Imports Nancy.Json
Imports Newtonsoft.Json.Linq

Public Class BusinessMediatorAPI
    Public Function Read(id As Integer) As String
        Dim apiUrl = $"https://localhost:44317/api/Business/{id}"
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

    Public Function Update(obj As BusinessObject) As String
        Dim apiUrl As String = "https://localhost:44317/api/Business"
        Dim responceString = String.Empty
        Dim request = CType(WebRequest.Create(apiUrl), HttpWebRequest)

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
            Dim rawresp As String
            reader = New StreamReader(response.GetResponseStream())
            rawresp = reader.ReadToEnd()
            reader.Close()
            response.Close()
            Return rawresp
        End Using

    End Function

    Public Function Delete(id As Integer) As String
        Dim apiUrl = $"https://localhost:44317/api/Business/{id}"
        Dim responceString = String.Empty
        Dim request = CType(WebRequest.Create(apiUrl), HttpWebRequest)
        request.Method = "DELETE"
        request.ContentType = "application/json"

        Using result = request.GetResponse()
            Using reader = New StreamReader(result.GetResponseStream())
                responceString = reader.ReadToEnd()
            End Using
        End Using

        Return responceString
    End Function

    Public Function Run(obj As BusinessQuery) As JArray
        Dim apiUrl As String = "https://localhost:44317/api/Business/Get"
        Dim request = CType(WebRequest.Create(apiUrl), HttpWebRequest)

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
