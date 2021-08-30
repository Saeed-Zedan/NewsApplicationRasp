Imports System.Data.SqlClient

Public Class FileQuery
    Inherits BusinessQuery
    Private mTableName As String = "T_FILE"
    Public Overrides Function Run() As List(Of String)
        Dim result As List(Of String) = New List(Of String)
        BuildingQuery()
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
                Me.ID = reader.GetInt32(0)
                Me.C_CreationDate = reader.GetDateTime(1)
                Me.C_Name = reader.GetString(2)
                Me.C_ClassID = reader.GetInt32(3)
                Me.C_LastModifier = reader.GetString(4)
                Me.C_Body = reader.GetString(5)
                Me.C_Description = If((reader.GetString(6) = Nothing), " ", reader.GetString(6))
                record = Me.ToString()
                result.Add(record)
            Loop

            dbManipulator.CloseConnection()
            Return result
        Catch ex As SqlException
            ResetProperties()
            Throw New Exception("Couldn't EXecute query", ex)
        End Try

        ResetProperties()
        Return result
    End Function

    Protected Overrides Sub BuildingQuery()
        MyBase.BuildingQuery()

        Dim C_Body As String = "C_Body"
        Dim C_Description As String = "C_Description"

        Q_From &= $" {mTableName},"
        Q_Where &= $" and {Me.mTableName}.ID = {MyBase.GetTableName}.ID"

        AddingCol(C_Body, Me.C_Body)
        AddingCol(C_Description, Me.C_Description)

    End Sub
    Protected Overrides Function GetTableName() As String
        Return mTableName
    End Function
    Protected Overrides Sub ResetProperties()
        MyBase.ResetProperties()
        C_Body = Nothing
        C_Description = Nothing
    End Sub
    Public Overrides Function ToString() As String
        Dim Info As String = $"^_^{Me.C_Body}^_^{Me.C_Description}"
        Return MyBase.ToString() & Info
    End Function
    Public Property C_Body As String = Nothing
    Public Property C_Description As String = Nothing
End Class
