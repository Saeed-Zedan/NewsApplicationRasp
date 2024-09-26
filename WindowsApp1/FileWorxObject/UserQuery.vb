Imports System.Data.SqlClient

Public Class UserQuery
    Inherits BusinessQuery
    Private mTableName As String = "T_USER"
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
                Me.FullName.ColumnValue = reader.GetString(5)
                Me.Password.ColumnValue = reader.GetString(6)
                Me.PrivilegeLevel.ColumnValue = reader.GetBoolean(7)
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
        Dim Info As String = $"^_^{Me.FullName.ColumnValue}^_^{Me.Password.ColumnValue}^_^{Me.PrivilegeLevel.ColumnValue}"
        Return MyBase.ToString() & Info
    End Function

    Public Property FullName As New ColumnInformation(Of String) With {.ColumnName = "C_FullName", .SelectFlag = True}
    Public Property PrivilegeLevel As New ColumnInformation(Of Integer) With {.ColumnName = "C_PrivilegeLevel", .SelectFlag = True}
    Public Property Password As New ColumnInformation(Of String) With {.ColumnName = "C_Password", .SelectFlag = True}

    Protected Overrides Sub BuildQuery()
        MyBase.BuildQuery()

        Q_From &= $" {mTableName},"
        Q_Where &= $" and {Me.mTableName}.ID = {MyBase.GetTableName}.ID"

        AddColumn(FullName)
        AddColumn(Password)
        AddColumn(PrivilegeLevel)
    End Sub

    Protected Overrides Sub ClearProperties()
        MyBase.ClearProperties()

        FullName.Clear()
        Password.Clear()
        PrivilegeLevel.Clear()
    End Sub
End Class
