﻿Imports System.Data.SqlClient

Public Class PhotoQuery
    Inherits FileQuery
    Private mTableName As String = "T_PHOTO"
    Public Overrides Function Run() As List(Of String)
        Dim result As List(Of String) = New List(Of String)
        BuildQuery()
        Dim query = GenerateQuery()
        Dim record As String
        Dim reader As SqlDataReader

        Try
            dbManipulator.OpenConnection()
            dbManipulator.Query = query
            reader = dbManipulator.ExecReader()

            If Not reader.HasRows Then
                dbManipulator.CloseConnection()
                Return Nothing
            End If

            Do While reader.Read()
                Me.mID.ColumnValue = reader.GetInt32(0)
                Me.CreationDate.ColumnValue = reader.GetDateTime(1)
                Me.Name.ColumnValue = reader.GetString(2)
                Me.ClassID.ColumnValue = reader.GetInt32(3)
                Me.LastModifier.ColumnValue = reader.GetString(4)
                Me.Body.ColumnValue = reader.GetString(5)
                Me.Description.ColumnValue = If((reader.GetString(6) = Nothing), " ", reader.GetString(6))
                Me.Location.ColumnValue = reader.GetString(7)
                record = Me.ToString()
                result.Add(record)
            Loop

            dbManipulator.CloseConnection()
            Return result
        Catch ex As SqlException
            ClearProperties()
            Throw New Exception("Couldn't EXecute query", ex)
        End Try

        ClearProperties()
        Return result
    End Function


    Protected Overrides Function GetTableName() As String
        Return mTableName
    End Function

    Public Overrides Function ToString() As String
        Dim Info As String = $"^_^{Me.Location.ColumnValue}"
        Return MyBase.ToString() & Info
    End Function

    Public Property Location As New ColumnInformation(Of String) With {.ColumnName = "C_Location", .SelectFlag = True}

    Protected Overrides Sub BuildQuery()
        MyBase.BuildQuery()

        Q_From &= $" {mTableName},"
        Q_Where &= $" and {Me.mTableName}.ID = {MyBase.GetTableName}.ID"

        AddColumn(Location)
    End Sub

    Protected Overrides Sub ClearProperties()
        MyBase.ClearProperties()

        Location.Clear()
    End Sub
End Class
