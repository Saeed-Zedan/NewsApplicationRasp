Imports System.Data.SqlClient
Imports Microsoft.SqlServer
Public Class UserQuery
    Inherits User
    Public Function Run() As List(Of String())
        Dim connectionString As String = "Data Source=SAEED\MSSQLSERVER01;Initial Catalog=NewsApplicationDB;Integrated Security=True"
        Dim record As String
        Dim result As List(Of String()) = New List(Of String())
        Try
            Using connection As New SqlConnection(connectionString)

                Dim query As String = $"select * 
                                    from T_USER, T_BUSINESSOBJECT
                                    where T_BUSINESSOBJECT.ID = T_USER.ID"

                Using command As SqlCommand = New SqlCommand(query, connection)

                    connection.Open()
                    Dim reader As SqlDataReader
                    reader = command.ExecuteReader()
                    If Not reader.HasRows Then
                        connection.Close()
                        Return Nothing
                    End If
                    Do While reader.Read()
                        Me.ID = reader.GetInt32(0)
                        Me.CreationDate = reader.GetDateTime(5)
                        Me.Name = reader.GetString(6)
                        Me.ClassID = CChar(reader.GetString(7))
                        Me.LastModifier = reader.GetString(8)
                        Me.FullName = reader.GetString(1)
                        Me.AssignPasswordDirectly(reader.GetString(2))
                        Me.PrivilegeLevel = reader.GetBoolean(3)
                        record = Me.ToString()
                        result.Add(Strings.Split(record, "^_^"))
                    Loop


                End Using
            End Using

            Return result
        Catch ex As SqlException
            Return Nothing
        End Try
    End Function
    Public Function Search(Name As String) As Int32
        Dim connectionString As String = "Data Source=SAEED\MSSQLSERVER01;Initial Catalog=NewsApplicationDB;Integrated Security=True"
        Try
            Dim connection As SqlConnection = New SqlConnection(connectionString)
            Dim query As String = $"select * 
                                    from T_USER, T_BUSINESSOBJECT
                                    where T_BUSINESSOBJECT.ID = T_USER.ID and T_BUSINESSOBJECT.C_NAME = '{Name}'"

            Dim command As SqlCommand = New SqlCommand(query, connection)
            connection.Open()
            Dim reader As SqlDataReader
            reader = command.ExecuteReader()
            If reader.HasRows = True Then
                Return 1
            Else
                Return 0
            End If
        Catch ex As SqlException
            Return -1
        End Try
    End Function
    Public Function ValidatingUser() As Int32
        Dim connectionString As String = "Data Source=SAEED\MSSQLSERVER01;Initial Catalog=NewsApplicationDB;Integrated Security=True"
        Try
            Dim connection As SqlConnection = New SqlConnection(connectionString)
            Dim query As String = $"select T_USER.ID, C_Password 
                                    from T_USER, T_BUSINESSOBJECT
                                    where T_BUSINESSOBJECT.ID = T_USER.ID and T_BUSINESSOBJECT.C_NAME = '{Name}'"

            Dim command As SqlCommand = New SqlCommand(query, connection)
            connection.Open()
            Dim reader As SqlDataReader
            reader = command.ExecuteReader()
            If reader.HasRows = True Then
                reader.Read()
                If Me.Password = reader.GetString(1) Then
                    Me.ID = reader.GetInt32(0)
                    Return 1
                Else
                    Return 0
                End If
            Else
                    Return 0
            End If
        Catch ex As SqlException
            Return -1
        End Try
    End Function

    Public Overrides Function ToString() As String
        Return MyBase.ToString()
    End Function
End Class
