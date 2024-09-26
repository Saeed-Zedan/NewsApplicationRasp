Imports System.IO
Imports System.Net
Imports System.Text
Imports FileWorksObject
Imports Nancy.Json
Imports Newtonsoft.Json.Linq

Public Class PhotoService
    Private apiUrl = "https://localhost:44317/api/Photo"
    Private controllerName As String = "Photo"
    Public Function Read(id As Integer) As String
        'Dim apiUrl = $"https://localhost:44317/api/User/{id}"
        'Dim apiUrl = Me.apiUrl & $"/{id}"
        'Dim request = CType(WebRequest.Create(apiUrl), HttpWebRequest)

        'Dim responceString As String
        'request.Method = "GET"
        'request.ContentType = "application/json"

        'Try
        '    Using result = request.GetResponse()
        '        Using reader = New StreamReader(result.GetResponseStream())
        '            responceString = reader.ReadToEnd()
        '        End Using
        '    End Using

        '    Return responceString

        'Catch e As WebException
        '    Return e.Message

        'End Try

        Dim objService As BaseService = New BaseService()
        objService.ApiUrl &= $"/{controllerName}/{id}"
        Dim result = objService.Read()

        Return result
    End Function

    Public Function Update(obj As FileWorksObject.Photo) As String
        'Dim apiUrl As String = "https://localhost:44317/api/User"
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

        'Try
        '    Using response As HttpWebResponse = DirectCast(request.GetResponse(), HttpWebResponse)
        '        Dim reader As StreamReader
        '        reader = New StreamReader(response.GetResponseStream())
        '        responceString = reader.ReadToEnd()
        '        reader.Close()
        '        response.Close()
        '        Return responceString
        '    End Using
        'Catch e As WebException
        '    Return e.Message

        'End Try

        Dim objService As BaseService = New BaseService()
        objService.ApiUrl &= $"/{controllerName}"
        Dim result = objService.Update(Of Photo)(obj)

        Return result
    End Function

    Public Function Delete(id As Integer) As String
        'Dim apiUrl = $"https://localhost:44317/api/User/{id}"
        'Dim apiUrl = Me.apiUrl & $"/{id}"
        'Dim request = CType(WebRequest.Create(apiUrl), HttpWebRequest)

        'Dim responceString As String
        'request.Method = "DELETE"
        'request.ContentType = "application/json"
        'Try
        '    Using result = request.GetResponse()
        '        Using reader = New StreamReader(result.GetResponseStream())
        '            responceString = reader.ReadToEnd()
        '        End Using
        '    End Using
        'Catch e As WebException
        '    Return e.Message

        'End Try

        'Return responceString

        Dim objService As BaseService = New BaseService()
        objService.ApiUrl &= $"/{controllerName}/{id}"
        Dim result = objService.Delete()

        Return result
    End Function

    Public Function Run(obj As PhotoQuery) As JArray
        'Dim apiUrl As String = Me.apiUrl & "/Get"
        'Dim request = CType(WebRequest.Create(apiUrl), HttpWebRequest)

        'Dim inputJson = (New JavaScriptSerializer()).Serialize(obj)
        'Dim bytes As Byte() = Encoding.UTF8.GetBytes(inputJson)

        'request.Method = "POST"
        'request.ContentType = "application/json"
        'request.Accept = "application/json"
        'request.ContentLength = bytes.Length
        'request.Expect = "application/json"
        'request.GetRequestStream().Write(bytes, 0, bytes.Length)
        'Try
        '    Using response As HttpWebResponse = DirectCast(request.GetResponse(), HttpWebResponse)
        '        Dim reader As StreamReader
        '        Dim rawlistresp As List(Of String) = New List(Of String)
        '        reader = New StreamReader(response.GetResponseStream())
        '        Dim rawresp = reader.ReadToEnd()
        '        Dim array As JArray = JArray.Parse(rawresp)
        '        reader.Close()
        '        response.Close()
        '        Return array
        '    End Using
        'Catch e As WebException
        '    Return e.Message

        'End Try

        Dim objService As BaseService = New BaseService()
        objService.ApiUrl &= $"/{controllerName}/Get"
        Dim result = objService.Run(Of PhotoQuery)(obj)

        Return result
    End Function
End Class
