Imports System.Data.SqlClient
Public Class DBAccess
    Public Property ConnectionString As String
    Public Property Query As String
    Private Property Connection As SqlConnection = Nothing
    Public Sub New(Optional query As String = Nothing,
                  Optional connectionString As String = "Data Source=SAEED\MSSQLSERVER01;Initial Catalog=NewsApplicationDB;Integrated Security=True")
        Me.Query = query
        Me.ConnectionString = connectionString
    End Sub

    Public Sub OpenConnection()
        If Connection Is Nothing Then
            Connection = New SqlConnection(ConnectionString)
            Connection.Open()
        ElseIf Connection.State = ConnectionState.Closed Then
            Connection = New SqlConnection(ConnectionString)
            Connection.Open()
        End If
    End Sub
    Public Sub CloseConnection()
        If Connection.State = ConnectionState.Open Then
            Connection.Close()
        End If
    End Sub

    Public Function ExecScaler(Of T)() As T
        Try

            Dim command As SqlCommand = New SqlCommand(Query, Connection)
            Dim result = command.ExecuteScalar()

            Return result

        Catch ex As SqlException
            Throw New Exception("DB Crashed", ex)
        End Try
    End Function
    Public Function ExecNonQuery() As Boolean
        Try
            Dim command As SqlCommand = New SqlCommand(Query, Connection)
            Dim effectedRows = command.ExecuteNonQuery()

            If effectedRows > 0 Then
                Return True
            End If

            Return False
        Catch ex As SqlException
            Throw New Exception("DB Crashed", ex)
        End Try
    End Function
    Public Function ExecReader() As SqlDataReader
        Try
            Dim command As SqlCommand = New SqlCommand(Query, Connection)
            Dim reader As SqlDataReader
            reader = command.ExecuteReader()

            Return reader
        Catch ex As SqlException
            Throw New Exception("DB Crashed", ex)
        End Try

    End Function
End Class
