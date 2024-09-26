Imports System.Data.SqlClient

Public Class File
    Inherits BusinessObject
    'Properties implementation
    Public Property Body As String
    Public Property Description As String


    Public Sub New(body As String, description As String,
                  creationDate As DateTime, name As String, classID As Integer, lastModifier As String, Optional ID As Integer = 0)
        MyBase.New(creationDate, name, classID, lastModifier, ID)
        Me.Body = body
        Me.Description = description
    End Sub
    Public Sub New()
        MyBase.New()
    End Sub


    'Methods Implementation
    Public Overrides Function Read() As Boolean
        Try
            Dim query As String = $"select C_BODY, C_Description 
                                    from  T_FILE
                                    where T_FILE.ID = {Me.ID}"
            Dim reader As SqlDataReader

            If MyBase.Read() Then

                dbManipulator.OpenConnection()
                dbManipulator.Query = query
                reader = dbManipulator.ExecReader()

                If Not reader.HasRows Then
                    Return False
                End If

                reader.Read()
                Me.Body = reader.GetString(0)
                Me.Description = reader.GetString(1)

                dbManipulator.CloseConnection()

                Return True
            End If

            Return False
        Catch ex As SqlException
            Throw New Exception("DB Crashed", ex)
        End Try
    End Function
    Public Overrides Function Update() As Integer
        Dim query As String
        Dim id = MyBase.Update()

        If id > 0 Then

            If Me.ID <> 0 Then
                query = $"update	T_FILE
                                set		C_BODY = N'{Me.Body}', C_Description = N'{Me.Description}'
                                where	ID = {Me.ID}"
            Else
                query = $"insert into T_FILE 
                       values({id}, N'{Me.Body}', N'{Me.Description}')"
            End If

            If ExecNonQuery(query) Then
                Return id
            End If

            Return 0
        Else
            Return 0
        End If

    End Function
    Public Overrides Function ToString() As String
        Dim Info As String = $"^_^{Me.Body}^_^{Me.Description}"
        Return MyBase.ToString() & Info
    End Function

    Public Overrides Sub FillData(data() As String)
        MyBase.FillData({data(0), data(1), data(2), data(3), data(4)})
        Me.Body = data(5)
        Me.Description = data(6)
    End Sub
End Class
