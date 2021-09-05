Imports System.IO
Imports System.Net

Public Class ApiCall
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
