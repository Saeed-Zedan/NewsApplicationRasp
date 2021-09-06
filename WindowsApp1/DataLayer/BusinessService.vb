Imports System.IO
Imports System.Net
Imports System.Text
Imports FileWorksObject
Imports Nancy.Json
Imports Newtonsoft.Json.Linq

Public Class BusinessService
    Private controllerName As String = "Business"
    Public Function Read(id As Integer) As String
        Dim objService As BaseService = New BaseService()
        objService.ApiUrl &= $"/{controllerName}/{id}"
        Dim result = objService.Read()

        Return result
    End Function

    Public Function Update(obj As BusinessObject) As String
        'Dim apiUrl As String = "https://localhost:44317/api/Business"
        'Dim request = CType(WebRequest.Create(apiUrl), HttpWebRequest)

        'Dim responceString As String
        'Dim inputJson = (New JavaScriptSerializer()).Serialize(obj)
        'Dim bytes As Byte() = Encoding.UTF8.GetBytes(inputJson)

        'request.Method = "POST"
        'request.ContentType = "application/json"
        'request.Accept = "application/json"
        'request.ContentLength = bytes.Length
        'request.Expect = "application/json"
        'request.GetRequestStream().Write(bytes, 0, bytes.Length)

        'Using response As HttpWebResponse = DirectCast(request.GetResponse(), HttpWebResponse)
        '    Dim reader As StreamReader
        '    reader = New StreamReader(response.GetResponseStream())
        '    responceString = reader.ReadToEnd()
        '    reader.Close()
        '    response.Close()
        '    Return responceString
        'End Using
        Dim objService As BaseService = New BaseService()
        objService.ApiUrl &= $"/{controllerName}"
        Dim result = objService.Update(Of BusinessObject)(obj)

        Return result
    End Function

    Public Function Delete(id As Integer) As String
        'Dim apiUrl = $"https://localhost:44317/api/Business/{id}"
        'Dim request = CType(WebRequest.Create(apiUrl), HttpWebRequest)

        'Dim responceString As String
        'request.Method = "DELETE"
        'request.ContentType = "application/json"

        'Using result = request.GetResponse()
        '    Using reader = New StreamReader(result.GetResponseStream())
        '        responceString = reader.ReadToEnd()
        '    End Using
        'End Using

        'Return responceString
        Dim objService As BaseService = New BaseService()
        objService.ApiUrl &= $"/{controllerName}/{id}"
        Dim result = objService.Delete()

        Return result
    End Function

    Public Function Run(obj As BusinessQuery) As JArray
        'Dim apiUrl As String = "https://localhost:44317/api/Business/Get"
        'Dim request = CType(WebRequest.Create(apiUrl), HttpWebRequest)

        'Dim inputJson = (New JavaScriptSerializer()).Serialize(obj)
        'Dim bytes As Byte() = Encoding.UTF8.GetBytes(inputJson)

        'request.Method = "POST"
        'request.ContentType = "application/json"
        'request.Accept = "application/json"
        'request.ContentLength = bytes.Length
        'request.Expect = "application/json"
        'request.GetRequestStream().Write(bytes, 0, bytes.Length)

        'Using response As HttpWebResponse = DirectCast(request.GetResponse(), HttpWebResponse)
        '    Dim reader As StreamReader
        '    Dim rawlistresp As List(Of String) = New List(Of String)
        '    reader = New StreamReader(response.GetResponseStream())
        '    Dim rawresp = reader.ReadToEnd()
        '    Dim array As JArray = JArray.Parse(rawresp)
        '    reader.Close()
        '    response.Close()
        '    Return array
        'End Using
        Dim objService As BaseService = New BaseService()
        objService.ApiUrl &= $"/{controllerName}/Get"
        Dim result = objService.Run(Of BusinessQuery)(obj)

        Return result
    End Function

End Class
