﻿Imports System.Data.SqlClient

Public Class FileQuery
    Inherits File
    Public Function Run() As List(Of String())
        Dim connectionString As String = "Data Source=SAEED\MSSQLSERVER01;Initial Catalog=NewsApplicationDB;Integrated Security=True"
        Dim record As String
        Dim result As List(Of String()) = New List(Of String())
        Try
            Using connection As New SqlConnection(connectionString)

                Dim query As String = $"select *
                                        from T_BUSINESSOBJECT, T_FILE
                                        where T_BUSINESSOBJECT.ID = T_FILE.ID"

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
                        Me.CreationDate = reader.GetDateTime(1)
                        Me.Name = reader.GetString(2)
                        Me.ClassID = CChar(reader.GetString(3))
                        Me.LastModifier = reader.GetString(4)
                        Me.Body = reader.GetString(6)
                        Me.Tagged = CChar(reader.GetString(7))
                        Me.Description = reader.GetString(8)
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
    Public Function RetrieveTag() As Char
        Dim connectionString As String = "Data Source=SAEED\MSSQLSERVER01;Initial Catalog=NewsApplicationDB;Integrated Security=True"
        Try
            Dim connection As SqlConnection = New SqlConnection(connectionString)
            Dim query As String = $"select C_TAGGED
                                    from T_BUSINESSOBJECT, T_FILE
                                    where T_BUSINESSOBJECT.ID = T_FILE.ID and C_NAME = '{Me.Name}'"

            Dim command As SqlCommand = New SqlCommand(query, connection)
            connection.Open()
            Dim reader As SqlDataReader
            reader = command.ExecuteReader()
            If Not reader.HasRows Then
                Return "E"
            End If
            reader.Read()
            Me.Tagged = CChar(reader.GetString(0))
            connection.Close()

            Return Me.Tagged
        Catch ex As SqlException
            Return "X"
        End Try
    End Function
    Public Function RetreiveByName() As String
        Dim connectionString As String = "Data Source=SAEED\MSSQLSERVER01;Initial Catalog=NewsApplicationDB;Integrated Security=True"
        Try
            Dim connection As SqlConnection = New SqlConnection(connectionString)
            Dim query As String = $"select *
                                    from T_BUSINESSOBJECT, T_FILE, T_NEWS
                                    where T_BUSINESSOBJECT.ID = T_FILE.ID and T_FILE.ID = T_NEWS.ID and C_NAME = '{Me.Name}'"

            Dim command As SqlCommand = New SqlCommand(query, connection)
            connection.Open()
            Dim reader As SqlDataReader
            reader = command.ExecuteReader()
            If Not reader.HasRows Then
                Return "No Rows"
            End If
            reader.Read()
            Me.ID = reader.GetInt32(0)
            Me.CreationDate = reader.GetDateTime(1)
            Me.Name = reader.GetString(2)
            Me.ClassID = CChar(reader.GetString(3))
            Me.LastModifier = reader.GetString(4)
            Me.Body = reader.GetString(6)
            Me.Tagged = CChar(reader.GetString(7))
            Me.Description = reader.GetString(8)
            connection.Close()

            Return Me.ToString()
        Catch ex As SqlException
            Return "Failed"
        End Try
    End Function
End Class
